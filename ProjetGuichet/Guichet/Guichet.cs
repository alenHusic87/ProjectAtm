using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guichet
{

    public class Guichet
    {
        // montat depart 10 000$;
        // voir la liste de compte

        private bool isON = true;
        private decimal montatnDuGuichet;
        private decimal montantMaximum = 10000;
        
        private const int maxMauvaisEsai = 3;
        
        private CompteClient selectedAccount;
        private CompteEpargne ab;
       
        public bool IsON { get => isON; set => isON = value; }
        public decimal GetMontatnDuGuichet { get => montatnDuGuichet; set => montatnDuGuichet = value; }

        private List<CompteClient> listeClients = new List<CompteClient>();


        public Guichet()
        {
            
            montatnDuGuichet = 1000;
            /*VoirSoldeGuichet();
            Console.Write("Test si le motant se ajoute au sold du guichet : ");
            decimal test = Convert.ToDecimal(Console.ReadLine());
            RemplirGuichet(test);
            VoirSoldeGuichet();*/

            //Initialise les 5 clients avce l'Admin
            /* listeClients = new List<CompteClient>
             {

                new CompteCheque() { Nom= "Djavo", GetNumeroCompte ="12345678" ,GetMotPasse ="a123", GetBalance =150.50M , IsLocked=false },
                new CompteCheque() { Nom= "Alen", GetNumeroCompte ="22334455" ,GetMotPasse ="!bthi", GetBalance =150.50M , IsLocked=false},

                new CompteEpargne() { Nom="Nancy" , GetNumeroCompte ="44556677" ,GetMotPasse="^ujik", GetBalance =503.09M ,IsLocked=false},
                new CompteEpargne() { Nom= "Jean-Simon", GetNumeroCompte ="55667788" ,GetMotPasse ="5556", GetBalance =550.50M , IsLocked=false}

             };*/


            CompteCheque client1 = new CompteCheque("alen", "1111", "1", 104, true, ab);
            CompteCheque client2 = new CompteCheque("alen", "2222", "2", 10132, false, ab);
            CompteCheque client3 = new CompteCheque("Nancy", "3333", "3", 10542, false, ab);
            CompteCheque client4 = new CompteCheque("Jean-Simon", "4444", "4", 1063, false, ab);
            listeClients.Add(client1);
            listeClients.Add(client2);
            listeClients.Add(client3);
            listeClients.Add(client4);


            client1.ChangeMotPass();
            Console.WriteLine(client1.GetMotPasse);
            
           // listeClients.Add(client3);
            //listeClients.Add(client4);

            Console.WriteLine("-----le motant a vire-----\n");

            decimal a = Convert.ToDecimal(Console.ReadLine());

            //client1.VirmentEntreCompte(client2, a);
            /*client2.Retrait(a);
            Console.WriteLine(montatnDuGuichet);
            decimal total= montatnDuGuichet -a;

            if (total == 0)
            {
                Console.WriteLine(montatnDuGuichet);
                Console.WriteLine("panneee");
            }*/
            //Console.WriteLine(total);
            CompteClient.VirmentCompte(client1, client2, a);

            AfficherLlisteComptes();

            Console.WriteLine(client1.AfficherSolde());
            
            Console.WriteLine(client2.AfficherSolde());
            //a.ChangeMotPass();
            AfficherLlisteComptes();
            //Console.WriteLine(a.GetMotPasse);
            Login();

        }


        public void ClientLogin()
        {
            Menu menua = new Menu();
            Console.WriteLine("-----Accès client-----\n" +
            "Entrer numero de compte & mot de passe");
            bool goTonext = false;
            int mauvaisEsai = 0;

            while (!goTonext)
            {
                
                string numerocompte;
                string motpasse;
                Console.Write("Utilisateur: ");
                numerocompte = Console.ReadLine();
                Console.Write("Mot de passe: ");
                motpasse = Console.ReadLine();
                IsCompteExiste(numerocompte);
             

                foreach (CompteClient account in listeClients)
                {
                    //if(IsLoginExist(numerocompte))
                   if (account.GetNumeroCompte.Equals(numerocompte) )
                    {

                        
                        selectedAccount = account;

                        if (account.GetMotPasse.Equals(motpasse))
                        {
                            //Si le account actuel est Verouilles alors il vous affiche le message que le accoute il est verouille 
                            if (selectedAccount.IsLocked)
                            {
                                CompteClient.LockAccount();
                                CompteClient.PrintMessage("compte verouille!", false);
                            }
                            else
                            {
                                //menua.Menuclient();
                                //selectedAccount.VirmentEntreCompte(account., 100);
                                // Ici Devrai affcihe le Menu du Client 
                                goTonext = true;
                            }
                        }
                        else
                        {
                            goTonext = false;
                            mauvaisEsai++;

                            if (mauvaisEsai >= maxMauvaisEsai)
                            {
                                selectedAccount.IsLocked = true;
                                CompteClient.LockAccount();
                            }

                        }
                    }
                }

                if (!goTonext)
                    CompteClient.PrintMessage("Données incorrect!", false);
            }
        }

        public void Login()
        {
            Console.WriteLine("Veuillez choisir l'une des actions suivantes:\n" +
            "1- Se connecter à votre compte\n" +
            "2- Se connecter comme administrateur\n" +
            "3- Quitter\n");
            try
            {
                string user = Console.ReadLine();
                // Checking if input is correct
                if (user == "1" || user == "2" || user == "3")
                {
                    switch (user)
                    {
                        // Case 1 pour Client Login
                        case "1":
                            ClientLogin();
                            break;
                        // Case 2 pour Admin Login
                        case "2":
                            AdminLogin();
                            break;
                        case "3":
                                Environment.Exit(0);
                            break;
                    }
                }
                else if (user != "1" || user != "2" || user != "3")
                {
                    Console.WriteLine("Choix non-valide");
                    Login();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("S.v.p essayer encore");
            }
        }


        public bool IsCompteExiste(string compte)
        {
           
            foreach (CompteClient acount in listeClients)
            {
                if (acount.GetNumeroCompte.Equals(compte))
                {
                    
                    return true;
                }
            }
            CompteClient.PrintMessage("ne existe pas !", false);

            return false;
        }

        /// <summary>
        /// Section  Admin 
        /// </summary>
        /// <param"></param>
        /// <returns></returns>

        public void AdminLogin()
        {
            Console.WriteLine("-----Accès admin-----\n" +
                            " Entrer numéro de compte & mot de passe");

            //Declare a Admin object
            //  Admin admin = new Admin();
            bool isSignedin = false;
            while (!isSignedin)
            {
                // Lire le userName du admin
                Console.Write("Utilisateur: ");
                // admin.GetAdminuser = Console.ReadLine();
            }
        }
        public decimal RemplirGuichet(decimal montant)
        {
            decimal soldeTemp = montatnDuGuichet + montant;

            if (soldeTemp > montantMaximum)
            {
                throw new Exception($"Le montant excède la valeur maximum permis {montantMaximum}.");
               
            }
            return AdminDepot(montant);
        }

        public void VoirSoldeGuichet()
        {
            Console.WriteLine(GetMontatnDuGuichet);

        }

        public decimal AdminDepot(decimal montant)
        {
            return montatnDuGuichet = montatnDuGuichet + montant;
        }
        //Affiche les Liste de tout le Comptes 
        public void AfficherLlisteComptes()
        {

            foreach (CompteClient account in listeClients)
            {
                
                Console.WriteLine($" Nom: {account.Nom}   Numero du Compte: { account.GetNumeroCompte}  Solde du Compte: {account.GetBalance}   Etat du Compte:{account.IsLocked}");

            }
        }

        //Admin peux chosire de alle au menu Principal 
        public void RetournerMenuPrincipal()
        {

        }
        //Admin peux remetre le Guichet  A  ON
        public void RemettreGuichetFonction() 
        { 

        }
    }
}