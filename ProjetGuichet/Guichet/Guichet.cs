using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace Guichet
{
    enum EtatGuichet
    {
        ACTIF,
        PANNE,


    }

    public class Guichet
    {
        private  EtatGuichet myvar = EtatGuichet.ACTIF;
        
        private bool isON = true;
        private static decimal montatnDuGuichet;
        private decimal montantMaximum = 10000;
        
        private const int maxMauvaisEsai = 3;
        
        private CompteClient selectedAccount;
        private CompteEpargne ab;
       
        public bool IsON { get => isON; set => isON = value; }
        public static decimal GetMontatnDuGuichet { get => montatnDuGuichet; set => montatnDuGuichet = value; }
        internal EtatGuichet Myvar { get => myvar; set => myvar = value; }

        private List<CompteClient> listeClients = new List<CompteClient>();
        private List<CompteCheque> listeClientsCheque= new List<CompteCheque>();
        private List<CompteEpargne> listeClientsEpargne = new List<CompteEpargne>();
        private List<Facture> listeFacture = new List<Facture>();

        public static ConsoleKeyInfo keyInfo;
        CompteCheque admin;
        public Guichet()
        {
            admin = new CompteCheque("admin", "admin", "123456", 0, false);
            Console.WriteLine(myvar);
            montatnDuGuichet = 1000;
            Console.WriteLine(montatnDuGuichet);
            
            CompteCheque clientCompteChequeAlen = new CompteCheque("Alen Cheque", "1111", "1", 20.00M, false);
            CompteEpargne clientCompteEpargneAlen = new CompteEpargne("Alen Epargne", "2222", "2", 40.00M, false);
            CompteCheque clientCompteChequeNancy = new CompteCheque("Nancy Cheque", "3333", "1", 1010.00M, false);
            CompteEpargne clientCompteEpargneNancy = new CompteEpargne("Nancy Epargne", "4444", "2", 500.00M, false);
            CompteCheque clientCompteChequeJeanSimon = new CompteCheque("JeanSimon Cheque", "5555", "1", 4567.00M, false);
            CompteEpargne clientCompteEpargneJeanSimon = new CompteEpargne("JeanSimon Epargne", "6666", "2", 3230.00M, false);

            Facture facture1 = new Facture("Bell", 50, "Amazon", 60, "Videotron", 90);

            listeFacture.Add(facture1);

            listeClients.Add(clientCompteChequeAlen);
            listeClients.Add(clientCompteEpargneAlen);
            listeClients.Add(clientCompteChequeNancy);
            listeClients.Add(clientCompteEpargneNancy);
            listeClients.Add(clientCompteChequeJeanSimon);
            listeClients.Add(clientCompteEpargneJeanSimon);


            listeClientsCheque.Add(clientCompteChequeAlen);
            listeClientsCheque.Add(clientCompteChequeNancy);
            listeClientsCheque.Add(clientCompteChequeJeanSimon);

            listeClientsEpargne.Add(clientCompteEpargneAlen);
            listeClientsEpargne.Add(clientCompteEpargneNancy);
            listeClientsEpargne.Add(clientCompteEpargneJeanSimon);

            Login();
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
                            if (!selectedAccount.IsLocked)
                            {
                                MenuA(selectedAccount);
                                goTonext = true;

                            }
                            else
                            {
                                CompteClient.LockAccount();
                               
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
                                ClientLogin();

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
                Console.WriteLine();
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
                        MenuChoixEpargneChequeDepot(a);
                        break;
                    case "3":
                        MenuChoixEpargneChequeRaitrait(a);
                        break;
                    case "4":
                        MenuChoixAffichageEpargneCheque();
                        break;
                    case "7":
                        //quitter();
                       
                        break;

                }

            } while (!options.Equals("7"));

        }
        public void AficheBalanceDeCheque() 
        {
            foreach (CompteCheque acount in listeClientsCheque)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t" + acount.Nom + "\t" + "#" + acount.GetNumeroCompte + "\t"+ acount.GetBalance +"$");

                Console.WriteLine();
                Console.ResetColor();

            }

        }
        public void AficheBalanceDeEpargne()
        {
            foreach (CompteEpargne acount in listeClientsEpargne)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t" + acount.Nom + "\t" + "#" + acount.GetNumeroCompte + "\t" + acount.GetBalance + "$");

                Console.WriteLine();
                Console.ResetColor();

            }

        }
        public void AficheCompteCheque() 
        {
            foreach (CompteCheque acount in listeClientsCheque)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t" + acount.Nom + "\t" + "#" + acount.GetNumeroCompte);
                
                Console.WriteLine();
                Console.ResetColor();

            }
        }
        public void AficheCompteEpargne()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (CompteEpargne acount in listeClientsEpargne)
            {
                Console.WriteLine("\t" + acount.Nom + "\t" + "#" + acount.GetNumeroCompte);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        public void MenuChoixAffichageEpargneCheque()
        {

            string options = "";


            Console.WriteLine("Dans quel compte Vous voulez Voire le solde  ?");
            Console.WriteLine();
            Console.WriteLine("1- Checking");
            Console.WriteLine("2- Epargne");
            Console.WriteLine("Faite votre choix?");
            options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    AficheBalanceDeCheque();
                    break;
                case "2":
                    AficheBalanceDeEpargne();
                    break;
                case "3":
                    ///retur au menu 
                    break;
                default:
                    CompteClient.PrintMessage("Operation  invalide", false);
                    break;

            }

        }
        public void MenuChoixEpargneChequeDepot(CompteClient a) 
        {

            string options = "";


                Console.WriteLine("Dans quel compte Vous voulez Depoze ?");
                Console.WriteLine();
                Console.WriteLine("1- Checking");
                Console.WriteLine("2- Epargne");
                Console.WriteLine("Faite votre choix?");
                options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        AficheCompteCheque();
                        CompteCheque.DepotDansleCompteCheque(a, listeClientsCheque);
                        break;
                    case "2":
                        AficheCompteEpargne();
                        CompteEpargne.DepotDansleCompteEpargne(a, listeClientsEpargne);
                        break;
                    case "3":
                        ///retur au menu 
                        break;
                    default:
                        CompteClient.PrintMessage("Operation  invalide", false);
                        break;

                }
            
        }
        public void MenuChoixEpargneChequeRaitrait(CompteClient a)
        {

            string options = "";


            Console.WriteLine("Dans quel compte Vous voulez Retire ?");
            Console.WriteLine();
            Console.WriteLine("1- Checking");
            Console.WriteLine("2- Epargne");
            Console.WriteLine("Faite votre choix?");
            options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    AficheCompteCheque();
                    CompteCheque.RaitraitDansleCompteCheque(a, listeClientsCheque);
                    Console.WriteLine(montatnDuGuichet);
                    break;
                case "2":
                    AficheCompteEpargne();
                   CompteEpargne.RaitraitDansleCompteEpargne(a, listeClientsEpargne);
                    break;
                case "3":
                    ///retur au menu 
                    break;
                default:
                    CompteClient.PrintMessage("Operation  invalide", false);
                    break;

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
        public CompteClient AdminLogin()
        {
            //CompteCheque admin = new CompteCheque("admin", "admin", "123456", 0, false );
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
            Console.WriteLine("Voulez-vous remettre le systeme en fonction (O/N)?");
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "O":
                    break;
                case "N":
                    
                    CompteClient.PrintMessage("Hors Service  "+ EtatGuichet.PANNE, false);
                    admin.IsLocked = false ;
                    //CompteClient.LockAccount();
                    MenuAdmin();

                    // Login();
                    break;
                default:
                    
                    CompteClient.PrintMessage("Operation invalide", false); ;
                    break;
            }
            

        }

    }
}