using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    class Menu
    {
        public void Menuclient()
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
                        changermdp();
                        break;
                    case "2":
                        deposer();
                        break;
                    case "3":
                        retirer();
                        break;
                    case "4":
                        soldes();
                        break;
                    case "5":
                        virementcompte();
                        break;
                    case "6":
                        facture();
                        break;
                    case "7":
                        quitter();
                        break;
                }

            } while (!options.Equals("7"));

        }
        public void changermdp()
        {
            Console.WriteLine("1");
        }
        public void deposer()
        {
            string choixdeposer = "";
            Console.WriteLine("Veuillez choisir le compte du dépot");
            Console.WriteLine("1- Chèque");
            Console.WriteLine("2- Épargne");

            choixdeposer = Console.ReadLine();
            switch (choixdeposer)
            {
                case "1":
                    chequedepot();
                    break;
                case "2":
                    epargnedepot();
                    break;
            }
            void chequedepot()
            {
                Console.WriteLine("cheque");
                Environment.Exit(0);
            }
            void epargnedepot()
            {
                Console.WriteLine("epargne");
                Environment.Exit(0);
            }
        }
        public void retirer()
        {
            string choixretirer = "";
            Console.WriteLine("Veuillez choisir le compte du retrait");
            Console.WriteLine("1- Chèque");
            Console.WriteLine("2- Épargne");

            choixretirer = Console.ReadLine();
            switch (choixretirer)
            {
                case "1":
                    chequeretrait();
                    break;
                case "2":
                    epargneretrait();
                    break;
            }
            void chequeretrait()
            {
                Console.WriteLine("cheque");
                Environment.Exit(0);
            }
            void epargneretrait()
            {
                Console.WriteLine("epargne");
                Environment.Exit(0);
            }
        }
        public void soldes()
        {
            Console.WriteLine("Quel compte compte désirez-vous voir le solde ?");
            string choixsolde = "";
            Console.WriteLine("1- Chèque");
            Console.WriteLine("2- Épargne");

            choixsolde = Console.ReadLine();
            switch (choixsolde)
            {
                case "1":
                    soldecheque();
                    break;
                case "2":
                    soldeepargne();
                    break;
            }
            void soldecheque()
            {
                Console.WriteLine("cheque");
                Environment.Exit(0);
            }
            void soldeepargne()
            {
                Console.WriteLine("epargne");
                Environment.Exit(0);
            }
        }

        public void virementcompte()
        {
            Console.WriteLine("Veuillez choisir le trajet du virement");
            string choixvirement = "";
            Console.WriteLine("1- De chèque vers épargne");
            Console.WriteLine("2- D'Épargne vers chèque");

            choixvirement = Console.ReadLine();
            switch (choixvirement)
            {
                case "1":
                    chequeepargne();
                    break;
                case "2":
                    epargnecheque();
                    break;
            }
            void chequeepargne()
            {
                int montantdeposer;
                Console.WriteLine("Sélectionner le montant du virement");
                montantdeposer = Convert.ToInt32(Console.ReadLine());

                if (montantdeposer >= 1000)
                {
                    Console.WriteLine("Saisir le mot de passe");
                }

                Environment.Exit(0);
            }
            void epargnecheque()
            {
                int montantdeposer;
                Console.WriteLine("Sélectionner le montant du virement");
                montantdeposer = Convert.ToInt32(Console.ReadLine());

                if (montantdeposer >= 1000)
                {
                    int mdp;
                    Console.WriteLine("Saisir le mot de passe");
                    mdp = Convert.ToInt32(Console.ReadLine());
                    if (mdp != 1234)
                    {
                        Console.WriteLine("erreur");
                    }
                    else if (mdp == 1234)
                    {
                        Console.WriteLine("good");
                    }

                }


                Environment.Exit(0);
            }
        }
        // 2$ de frais par paiement de facture (25$(facture)+2$(frais)=27$ à débiter
        public void facture()
        {
            Console.WriteLine("Veuillez choisir la compagnie à payer");
            string payefacture = "";
            Console.WriteLine("1- Amazon");
            Console.WriteLine("2- Bell");
            Console.WriteLine("3- Vidéotron");

            payefacture = Console.ReadLine();
            switch (payefacture)
            {
                case "1":
                    amazon();
                    break;
                case "2":
                    bell();
                    break;
                case "3":
                    videotron();
                    break;
            }
            void amazon()
            {
                Console.WriteLine("Sélectionner le montant à payer de la facture");
                Console.ReadLine();
                Console.WriteLine("Veuillez choisir le compte à débiter");
                payefacture = Console.ReadLine();
                if (payefacture == "cheque")
                {
                    Console.WriteLine("ok");
                }
                else if (payefacture == "epargne")
                {
                    Console.WriteLine("okok");
                }
                Environment.Exit(0);
            }
            void bell()
            {
                Console.WriteLine("Sélectionner le montant à payer de la facture");
                Console.ReadLine();
                Console.WriteLine("Veuillez choisir le compte à débiter");
                Console.ReadLine();
                if (payefacture == "cheque")
                {
                    Console.WriteLine("ok");
                }
                else if (payefacture == "epargne")
                {
                    Console.WriteLine("okok");
                }
                Environment.Exit(0);
            }
            void videotron()
            {
                Console.WriteLine("Sélectionner le montant à payer de la facture");
                Console.ReadLine();
                Console.WriteLine("Veuillez choisir le compte à débiter");
                Console.ReadLine();
                if (payefacture == "cheque")
                {
                    Console.WriteLine("ok");
                }
                else if (payefacture == "epargne")
                {
                    Console.WriteLine("okok");
                }
            }
            Environment.Exit(0);
        }
        public void quitter()
        {
            Environment.Exit(0);
        }

    }
}
