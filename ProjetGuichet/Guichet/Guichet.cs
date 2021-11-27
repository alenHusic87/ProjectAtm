using System;
using System.Collections;
using System.Collections.Generic;
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
        private Guichet guichet;
      
        private const int maxMauvaisEsai = 3;
        
        private CompteClient selectedAccount;

       
        public bool IsON { get => isON; set => isON = value; }
        public decimal GetMontatnDuGuichet { get => montatnDuGuichet; set => montatnDuGuichet = value; }

        private List<CompteClient> listeClients = new List<CompteClient>();


        public Guichet()
        {
            
            montatnDuGuichet = 1000;
            VoirSoldeGuichet();
            Console.Write("sdfdsfdsfsdfsdfsdf: ");
            decimal test = Convert.ToDecimal(Console.ReadLine());
            RemplirGuichet(test);
            VoirSoldeGuichet();
            //Initialise les 5 clients avce l'Admin
            listeClients = new List<CompteClient>
            {
                
               new CompteCheque() { Nom= "Djavo", GetNumeroCompte ="12345678" ,GetMotPasse ="a123", GetBalance =150.50M , IsLocked=false},
               new CompteCheque() { Nom= "Alen", GetNumeroCompte ="22334455" ,GetMotPasse ="!bthi", GetBalance =150.50M , IsLocked=false},

               new CompteEpargne() { Nom="Nancy" , GetNumeroCompte ="44556677" ,GetMotPasse="^ujik", GetBalance =503.09M ,IsLocked=false},
               new CompteEpargne() { Nom= "Jean-Simon", GetNumeroCompte ="55667788" ,GetMotPasse ="555", GetBalance =550.50M , IsLocked=false}

            };
            //Login();

            AfficherLlisteComptes();

        }

        public void ClientLogin()
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
                
                foreach (CompteClient account in listeClients)
                {
                    if (account.GetNumeroCompte.Equals(numerocompte))
                    {
                        selectedAccount = account;

                        if (account.GetMotPasse.Equals(motpasse))
                        {
                            if (selectedAccount.IsLocked)
                                CompteClient.LockAccount();
                            else
                                goTonext = true;
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