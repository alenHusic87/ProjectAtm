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

            CompteCheque client1 = new CompteCheque("alen", "1111", "1", 1010, false, ab);
            CompteCheque client2 = new CompteCheque("alen", "2222", "2", 10132, false, ab);
            CompteCheque client3 = new CompteCheque("Nancy", "3333", "3", 10542, false, ab);
            CompteCheque client4 = new CompteCheque("Jean-Simon", "4444", "4", 1063, false, ab);

            listeClients.Add(client1);
            listeClients.Add(client2);
            listeClients.Add(client3);
            listeClients.Add(client4);

        

           
            
          /*  Console.WriteLine("-----le motant a vire-----\n");
               decimal a;


        test:
            if (Decimal.TryParse(Console.ReadLine(), out a))
            {
                // valid showingSelect
                CompteClient.VirmentCompte(client1, client2, a);
            }
            else
            {
                // invalid input  
                
                CompteClient.PrintMessage("please input valid number", false);
                goto test;  // continue loop. 
            }*/



           // AfficherLlisteComptes();

           /// Console.WriteLine(client1.AfficherSolde());
            
           // Console.WriteLine(client2.AfficherSolde());
            //a.ChangeMotPass();
           // AfficherLlisteComptes();
            //Console.WriteLine(a.GetMotPasse);
            Login();

            Facture a = new Facture(100, 200, 300);



        }
       


        public CompteClient ClientLogin()
        {
            
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
                               
                            }
                            else
                            {
                                // selectedAccount.ChangeMotPass();
                                // selectedAccount.ChangeMotPass();
                                //menua.Menuclient();
                                MenuA(selectedAccount);
                                Console.WriteLine(selectedAccount.GetMotPasse);
                                //selectedAccount.ChangeMotPass();
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
            return selectedAccount;
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

   
      public void MenuA(CompteClient a) 
      {
            string options = "";

            do
            {
                Console.WriteLine("1- Changer le mot de passe");
                Console.WriteLine("2- Déposer un montant dans un compte");
                Console.WriteLine("3- Retirer un montant dans un compte");
                Console.WriteLine("4- Afficher le solde du compte chèque ou épargne");
                Console.WriteLine("5- Effectuer un virement entre les comptes");
                Console.WriteLine("6- Payer une facture");
                Console.WriteLine("7- Fermer session");


                options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        a.ChangeMotPass();
                        break;
                    case "2":
                        Console.WriteLine("ecri de quoi");
                        decimal test2 = Convert.ToDecimal(Console.ReadLine());
                        a.Depot(test2);
                        Console.WriteLine(a.AfficherSolde());
                        break;
                    case "7":
                        //quitter();
                        break;

                }

            } while (!options.Equals("7"));

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

        public CompteClient AdminLogin()
        {
            CompteCheque admin = new CompteCheque("admin", "admin", "123456", 0, false, null );
            Console.WriteLine("-----Admin client-----\n" +
            "Entrer numero de compte & mot de passe");
            bool goTonext = false;
            int mauvaisEsai = 0;

            while (!goTonext)
            {

                string numerocompte;
                string motpasse;
                Console.Write("Admin: ");
                numerocompte = Console.ReadLine();
                Console.Write("Mot de passe: ");
                motpasse = Console.ReadLine();
              // IsCompteExiste(numerocompte);


                    //if(IsLoginExist(numerocompte))
                    if (admin.GetNumeroCompte.Equals(numerocompte))
                    {

                        selectedAccount = admin;

                        if (admin.GetMotPasse.Equals(motpasse))
                        {
                            //Si le account actuel est Verouilles alors il vous affiche le message que le accoute il est verouille 
                            if (selectedAccount.IsLocked)
                            {
                                CompteClient.LockAccount();

                            }
                            else
                            {
                                goTonext = true;
                                MenuAdmin();

                            }
                        }
                        else
                        {
                            goTonext = false;
                            mauvaisEsai++;
                          // CompteClient.PrintMessage("Données incorrect!", false);

                        if (mauvaisEsai >= maxMauvaisEsai)
                            {
                                selectedAccount.IsLocked = true;
                                CompteClient.LockAccount();

                            }

                        }
                    }
                if (!goTonext)
                    CompteClient.PrintMessage("Données incorrect!", false);
            }
            return selectedAccount;

        }
           

        public void MenuAdmin()
        {
            string admin = "";



            do
            {
                Console.WriteLine("1- Remettre le guichet en fonction");
                Console.WriteLine("2- Déposer de l'argent dans le guichet");
                Console.WriteLine("3- Voir le solde du guichet");
                Console.WriteLine("4- Afficher la liste des comptes");
                Console.WriteLine("5- Retourner au menu principal");



                admin = Console.ReadLine();

                switch (admin)
                {
                    case "1":
                        RemettreGuichetFonction();
                        break;
                    case "2":
                        RemplirGuichet(10);
                        break;
                    case "3":
                        VoirSoldeGuichet();
                        break;
                    case "4":
                        AfficherLlisteComptes();
                        break;
                    case "5":
                        RetournerMenuPrincipal();
                        break;
                }

            } while (!admin.Equals("5"));


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
            Login();
        }
        //Admin peux remetre le Guichet  A  ON
        public void RemettreGuichetFonction() 
        { 

        }
    }
}