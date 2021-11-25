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
        private int mDepart = 10000;
        private int mDeposedansGuichet = 0;
        private string nbdeCompte;
        private int tries;
        private const int maxTries = 3;

        public string NbdeCompte { get => nbdeCompte; set => nbdeCompte = value; }
        private List<CompteClient> listeClients = new List<CompteClient>();
        private List<CompteCheque> comptesCheques = new List<CompteCheque>();
        private List<CompteEpargne> compteEpargne = new List<CompteEpargne>();

        public Guichet()
        {
            CompteCheque client = new CompteCheque("Marc", "123456", "1234", 100.50M, false);
            comptesCheques.Add(new CompteCheque("Marc", "12345", "1234", 100.50M, false));
            comptesCheques.Add(client);
            compteEpargne.Add(new CompteEpargne("Marc", "12345678", "1234", 109.50M, false));


            Login();
            /* foreach (CompteCheque a in compteCheques)
            {
            Console.WriteLine($"Numero de compte Cheques : {a.GetNumeroCompte} {a.GetMotPasse} {a.GetBalance} ");
            }
            foreach (CompteEpargne a in compteEpargne)
            {


            Console.WriteLine($"Numero de compte Epargne : {a.GetNumeroCompte} {a.GetBalance} "); }*/

            CompteCheque compteCourant = new CompteCheque("Marc", "Djavo", "1234", 100.50M, false);
            Console.Write("Entrez le montant du retrait : ");
            decimal montantretrait = Convert.ToDecimal(Console.ReadLine());

            compteCourant.Retrait(montantretrait);

            Console.WriteLine(compteCourant.AfficherSolde());
            Console.WriteLine(compteCourant.GetMotPasse);

            Console.Write("Entrez le montant du dépot : ");
            decimal montantDepot = Convert.ToDecimal(Console.ReadLine());
            compteCourant.Virement(montantDepot);

            Console.Write("Entrez le montant à payer : ");
            decimal montanttoPay = Convert.ToDecimal(Console.ReadLine());
            compteCourant.PayBill(montanttoPay);
            Console.WriteLine(compteCourant.AfficherSolde());

        }
        //Initialiser les 5 utilisateur
        //et devrais appeller la methode dans Constructeur du guichet
        public void Initialization()
        {
            mDepart = 0;
            comptesCheques.Add(new CompteCheque("Marc", "CompteCheques", "1234", 100.50M, false));
            compteEpargne.Add(new CompteEpargne("Marc", "CompteEpargne", "1234", 100.50M, false));
        }
        public void ClientLogin()
        {
            CompteCheque client = new CompteCheque("Marc", "123456", "1234", 100.50M, false);
            string numerocompte = client.GetNumeroCompte;
            string motpasse = client.GetMotPasse;
            //bool isSignedin = false;
            Console.WriteLine("-----Accès client-----\n" +
            "Entrer numero de compte & mot de passe");
            int mauvais = 0;

        // Lire le userName du client
        gotoPin:
            Console.Write("Utilisateur: ");
            client.GetNumeroCompte = Console.ReadLine();
            Console.Write("Mot de passe: ");
            client.GetMotPasse = Console.ReadLine();


            if (client.GetNumeroCompte.Equals(numerocompte) && client.GetMotPasse.Equals(motpasse))
            {
                Console.WriteLine("Le numéro de compte est valide ");
                //Affiche le menu  du utilisteur 
            }
            else
            {
                mauvais++;
                if (mauvais < 3)
                {
                    //Mauvais mot de passe veuillez réessayer
                    string a = "Données incorrect !";
                    CompteClient.PrintMessage(a, false);
                    goto gotoPin;
                }
                else if (mauvais == 3)
                {
                    string a = "Vous avez saisi 3 fois des données incorrect. Le compte est en panne !";
                    CompteClient.PrintMessage(a, false);
                    Environment.Exit(0);
                }
            }

        }
        public void AdminLogin() 
        {
            Console.WriteLine("-----Accès admin-----\n" +
                            " Entrer numéro de compte & mot de passe");

            //Declare a Admin object
            Admin admin = new Admin();
            bool isSignedin = false;
            while (!isSignedin)
            {
                // Lire le userName du admin
                Console.Write("Utilisateur: ");
                admin.GetAdminuser = Console.ReadLine();
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
                            {
                                Environment.Exit(0);
                            }

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

    }
}