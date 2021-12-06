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
        private EtatGuichet myvar = EtatGuichet.ACTIF;

        private bool isON = true;
        private static decimal montatnDuGuichet;
        private decimal montantMaximum = 10000;

        private const int maxMauvaisEsai = 3;

        private CompteClient selectedAccount;
        public bool IsON { get => isON; set => isON = value; }
        public static decimal GetMontatnDuGuichet { get => montatnDuGuichet; set => montatnDuGuichet = value; }
        internal EtatGuichet Myvar { get => myvar; set => myvar = value; }

        public static List<CompteClient> listeClients = new List<CompteClient>();
       

        public static Facture amazon = new Facture(145, "Amazon", 100);
        public static Facture bell = new Facture(146, "Bell", 100);
        public static Facture videotron = new Facture(147, "Videotron", 100);

        CompteCheque admin;
        public Guichet()
        {


            admin = new CompteCheque("admin", "admin", "123456", 0, 0,false, "ACTIVE");     
            montatnDuGuichet = 10000;
        

            CompteCheque clientCompteChequeAlen = new CompteCheque("Alen", "1111", "1alen", 200.00M,500.08M ,false,"ACTIVE");
            CompteCheque clientCompteEpargneAlen = new CompteCheque("Alen", "2222", "2alen", 4000.00M,600.05m, false, "ACTIVE");
            CompteCheque clientCompteChequeNancy = new CompteCheque("Nancy ", "3333", "alen", 1010.00M,500.0M ,false, "ACTIVE");
            CompteCheque clientCompteEpargneNancy = new CompteCheque("Nancy ", "4444", "alen23", 5000.00M,790.0M ,false, "ACTIVE");
            CompteCheque clientCompteChequeJeanSimon = new CompteCheque("J-Simon ", "5555", "alen2", 4567.00M,689.08M, false, "ACTIVE");
            CompteCheque clientCompteEpargneJeanSimon = new CompteCheque("J-Simon ", "6666", "2", 3230.00M,897.09m,false, "ACTIVE");



            listeClients.Add(clientCompteChequeAlen);
            listeClients.Add(clientCompteEpargneAlen);
            listeClients.Add(clientCompteChequeNancy);
            listeClients.Add(clientCompteEpargneNancy);
            listeClients.Add(clientCompteChequeJeanSimon);
            listeClients.Add(clientCompteEpargneJeanSimon);

            Login();
        }
        public  CompteClient ClientLogin()
        {

            Console.WriteLine("-----Accès client-----\n" +
            "Entrer le numero de compte & mot de passe");
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
                    if (account.GetNumeroCompte.Equals(numerocompte))
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
                                selectedAccount.GetEtatcompote = "NON-ACTIF";

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
                                selectedAccount.GetEtatcompote = "NON-ACTIF";
                                Login();

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
            Console.WriteLine("Veuillez choisir l'une des options suivantes:\n" +
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
                Console.WriteLine("S.v.p réessayer");
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
                         Login();
                        break;
                    case "2":
                        DeposerMontant(a);
                        break;
                    case "3":
                        RetireMontant(a);
                        break;
                    case "4":
                        MenuChoixAffichageEpargneCheque(a);
                        break;
                    case "5":
                        VireMoneyEntreDeuxCompte();
                        break;
                    case "6":
                        PayerFacture();
                        break;
                    case "7":
                        Console.WriteLine("Voulez-vous allez au menu principal (O/N)?");
                        string choix = Console.ReadLine();
                        switch (choix)
                        {
                            case "O":
                                Login();
                             break;
                            case "N":
                                Environment.Exit(0);
                                break;                       
                        }
                       
                        break;
                }

            } while (!options.Equals("7"));

        }
        public void VireMoneyEntreDeuxCompte()
        {
            InternalClass inter = new InternalClass();
            CompteClient destintaire;
            CompteClient reciver;

            AfficherLlisteComptesSansBalance();


            string userdestintaire = inter.EnterUser("Destinataire");
            destintaire = inter.GetByNumeroCompte(userdestintaire, listeClients);
    

            string userreciver = inter.EnterUser("Receveur");
            reciver = inter.GetByNumeroCompte(userreciver, listeClients);
            while (destintaire == null || reciver == null )
            {

                CompteClient.PrintMessage("Un des compte n'existe pas   ", false);
                userdestintaire = inter.EnterUser("Destinataire");
                destintaire = inter.GetByNumeroCompte(userdestintaire, listeClients);
                userreciver = inter.EnterUser("Receveur");
                reciver = inter.GetByNumeroCompte(userreciver, listeClients);

            }
            if (destintaire.Equals(reciver))
            {
                CompteClient.PrintMessage("Le compte est le même  ", false);
              
                VireMoneyEntreDeuxCompte();

            }


            CompteClient.VirmentCompte(destintaire, reciver, inter.AmountToRetire());
        }
        public void DeposerMontant(CompteClient aba)
        {
            InternalClass rv = new InternalClass();
            decimal montant = rv.AmountToDeposit();
            while (montant <= 0 || montant.Equals(10000))
            {
                Console.WriteLine("Montant invalide ");
                montant = 0;
                montant = rv.AmountToDeposit();
            }

            Console.WriteLine("Dans quel compte vous voulez deposer");
            Console.WriteLine("1:Chèque");
            Console.WriteLine("2:Epargne");
            string compte = Console.ReadLine();
            switch (compte)
            {
                case "1":
                    aba.DepotparDefaut(montant);
                    Console.WriteLine("Nouveau Solde du compte chèque : " + aba.GetBalance);
                    break;
                case "2":
                    aba.DepotparDefautDansEpargne(montant);
                    Console.WriteLine("Nouveau Solde du compte épargne : " + aba.GetBalanceEpargne);
                    break;
                default:
                    Console.WriteLine("Opération  invalide");
                    break;
            }
            Console.WriteLine();

        }
        public void RetireMontant(CompteClient aba)
        {
            InternalClass rv = new InternalClass();
            decimal montant = rv.AmountToRetire();

            Console.WriteLine("À partir de quel compte vous voulez retirer");
            Console.WriteLine("1:Chèque");
            Console.WriteLine("2:Epargne");
            string compte = Console.ReadLine();
            switch (compte)
            {
                case "1":
                    while (aba.GetBalance < montant || montant.Equals(10000))
                    {
                        CompteClient.PrintMessage("montant insufisant ", false);
                        montant = 0;
                        montant = rv.AmountToRetire();

                    }
                    aba.Retrait(montant);
                    Console.WriteLine("Nouveau solde du compte chèque : " + aba.GetBalance);
                    break;
                case "2":
                    while (aba.GetBalanceEpargne < montant || montant.Equals(10000))
                    {
                        CompteClient.PrintMessage("Montant insufisant ", false);
                        montant = 0;
                        montant = rv.AmountToRetire();

                    }
                    aba.RetraitDeCompteEpargne(montant);
                    Console.WriteLine("Nouveau solde du compte epargne : " + aba.GetBalanceEpargne);
                    break;
                default:
                    Console.WriteLine("Opération  invalide");
                    break;
            }
            Console.WriteLine();

        }
        public void RetireMontantToPaye(CompteClient aba, decimal montant)
        {
            InternalClass rv = new InternalClass();

            Console.WriteLine("À partir quel compte vous voulez payer");
            Console.WriteLine("1:Cheque");
            Console.WriteLine("2:Epargne");
            string compte = Console.ReadLine();
            switch (compte)
            {
                case "1":
                    while (aba.GetBalance < montant+2 || montant.Equals(10000))
                    {
                        CompteClient.PrintMessage("montant insufisant ", false);
                        VeuxTuAlleauMenu();
                        montant = 0;
                        montant = rv.AmountToPay();
                        //VeuxTuAlleauMenu();

                    }
                    aba.Retrait(montant+2);
                    Console.WriteLine("Nouveau solde du compte cheque : " + aba.GetBalance);
                    break;
                case "2":
                    while (aba.GetBalance < montant + 2 || montant.Equals(10000))
                    {
                        CompteClient.PrintMessage("montant insufisant ", false);
                        montant = 0;
                        montant = rv.AmountToPay();

                    }

                    aba.RetraitDeCompteEpargne(montant+2);
                    Console.WriteLine("Nouveau solde du compte épargne : " + aba.GetBalanceEpargne);
                    break;
                default:
                    Console.WriteLine("Opération  invalide");
                    break;
            }
            Console.WriteLine();

        }
        public void PayerFacture()
        {
            InternalClass utils = new InternalClass();
            Console.WriteLine("Amazon : #145");
            Console.WriteLine("Bell : #146");
            Console.WriteLine("Vidéotron : #147");
            Console.WriteLine("Veuillez choisir un des fournisseurs par le nom ou par le numéro de la facture:");
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "Amazon":
                    Console.WriteLine("Nom de la compagnie :"+ amazon.Description+ "\t" + "Numero de facture : "+ amazon.ItemNumber );
                    decimal montantAmazon = utils.AmountToPay();
                    RetireMontantToPaye(selectedAccount, montantAmazon);
                    
                    break;
                case "Bell":
                    Console.WriteLine("Nom de la compagnie :" + bell.Description + "\t" + "Numero de facture : " + bell.ItemNumber);
                    decimal montantBell = utils.AmountToPay();
                    RetireMontantToPaye(selectedAccount, montantBell);

                    break;
                case "Vidéotron":
                    Console.WriteLine("Nom de la compagnie :" + videotron.Description + "\t" + "Numero de facture : " + videotron.ItemNumber);
                    decimal montantVideotron = utils.AmountToPay();
                    RetireMontantToPaye(selectedAccount, montantVideotron);
                    break;
                   
                case "145":
                    Console.WriteLine("Nom de la compagnie :" + amazon.Description + "\t" + "Numero de facture : " + amazon.ItemNumber);
                    decimal facturAmazon = utils.AmountToPay();
                    RetireMontantToPaye(selectedAccount, facturAmazon);

                    break;
                case "146":
                    Console.WriteLine("Nom de la compagnie :" + bell.Description + "\t" + "Numero de facture : " + bell.ItemNumber);
                    decimal facturBell = utils.AmountToPay();
                    RetireMontantToPaye(selectedAccount, facturBell);

                    break;
                case "147":
                    Console.WriteLine("Nom de la compagnie :" + videotron.Description + "\t" + "Numero de facture : " + videotron.ItemNumber);
                    decimal facturVideotron = utils.AmountToPay();
                    RetireMontantToPaye(selectedAccount, facturVideotron);

                    break;
                default:
                    Console.WriteLine("Opération invalide");
                    break;
            }
        }
        public void MenuChoixAffichageEpargneCheque(CompteClient a)
        {

            string options = "";


            Console.WriteLine("Veuillez choisir le compte que vous désirez voir le solde");
            Console.WriteLine();
            Console.WriteLine("1- Checking");
            Console.WriteLine("2- Epargne");

            Console.WriteLine("Faite votre choix?");
            options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    AficheBalanceCheque(a);
                    break;
                case "2":
                    AficheBalanceEpargne(a);
                    break;
                case "3":
                    ///retur au menu 
                    break;
                default:
                    CompteClient.PrintMessage("Opération  invalide", false);
                    break;
            }

        }

        public void AficheBalanceCheque(CompteClient acount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t" + acount.Nom + "\t" + acount.GetBalance + "$");
            Console.WriteLine();
            Console.ResetColor();

        }
        public void AficheBalanceEpargne(CompteClient acount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t" + acount.Nom + "\t" + acount.GetBalanceEpargne + "$");
            Console.WriteLine();
            Console.ResetColor();

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
            CompteClient.PrintMessage("N'existe pas !", false);

            return false;
        }
        public CompteClient AdminLogin()
        {
            //CompteCheque admin = new CompteCheque("admin", "admin", "123456", 0, false );
            Console.WriteLine("-----Admin client-----\n" +
            "Entrer le numero de compte & mot de passe");
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

                    if (admin.GetNumeroCompte.Equals(numerocompte))
                    {

                        selectedAccount = admin;

                        if (admin.GetMotPasse.Equals(motpasse))
                        {
                            //Si le account actuel est Verouilles alors il vous affiche le message que le accoute il est verouille 
                            if (selectedAccount.IsLocked)
                            {
                                selectedAccount.GetEtatcompote = "NON-ACTIF";
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

                        if (mauvaisEsai >= maxMauvaisEsai)
                            {

                                selectedAccount.IsLocked = true;
                                selectedAccount.GetEtatcompote = "NON-ACTIF";
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
                        InternalClass rv = new InternalClass();
                        decimal montant = rv.AmountToDeposit();
                        RemplirGuichet(montant);
                        VoirSoldeGuichet();
                        Console.WriteLine("");
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
            InternalClass rv = new InternalClass();
            decimal soldeTemp = montatnDuGuichet + montant;



            if (soldeTemp > montantMaximum)
            {
                Console.WriteLine($"Le montant excède la valeure maximum permis {montantMaximum}.");
                if (montantMaximum.Equals(10000) || soldeTemp.Equals(10000))
                {
                    VoirSoldeGuichet();
                    Console.WriteLine("");
                    MenuAdmin();
                }
                VoirSoldeGuichet();

                montant = rv.AmountToDeposit();



            }
            return AdminDepot(montant);
        }


        public void VoirSoldeGuichet()
        {
            CompteClient.PrintMessage("Le solde du Guichet est de : " + GetMontatnDuGuichet + "$", true);
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
                
                Console.WriteLine($"Nom:{ account.Nom}  Compte:{account.GetNumeroCompte}  Solde Cheque :{account.GetBalance} Solde Epargne :{account.GetBalanceEpargne} Etat du Compte: {account.GetEtatcompote}"  );
                
            }
            Console.WriteLine();


        }
        public void AfficherLlisteComptesSansBalance() 
        {
            foreach (CompteClient account in listeClients)
            {

                Console.WriteLine($"Nom:  { account.Nom}   \tNumero du Compte: {account.GetNumeroCompte} \a");

            }
            Console.WriteLine();

        }

        //Admin peux chosire de alle au menu Principal 
        public void RetournerMenuPrincipal()
        {
            Login();
        }
        //Admin peux remetre le Guichet  A  ON
        public void RemettreGuichetFonction() 
        {
            Console.WriteLine("Voulez-vous remettre le système en fonction (O/N)?");
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "O":
                    break;
                case "N":
                    
                    CompteClient.PrintMessage("Hors-service  "+ EtatGuichet.PANNE, false);
                    admin.IsLocked = false ;
                    //CompteClient.LockAccount();
                    MenuAdmin();

                    // Login();
                    break;
                default:
                    
                    CompteClient.PrintMessage("Opération invalide", false); ;
                    break;
            }
            

        }
        public void VeuxTuAlleauMenu()
        {
            Console.WriteLine("Voulez-vous allez au menu principal ou changer le montant  (O/N)?");
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "O":
                    MenuA(selectedAccount);
                    break;
                case "N":
                    break;
                default:
                    CompteClient.PrintMessage("Opération invalide", false); ;
                    break;
            }


        }

    }
}