using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Guichet
{
    abstract class CompteClient
    {
        protected string numerocompte;
        protected double balance;
        protected string nom;
        protected string motpasse;   // minimum 4 caractere peut importe le type 
        protected bool isLocked;
        protected string typecompte;

        public string GetTypeCompte { get => typecompte; set => typecompte = value; }
        public string GetNumeroCompte { get => numerocompte; set => numerocompte = value; }
        public string GetMotPasse { get => motpasse; set => motpasse = value; }
        public double GetBalance { get => balance; set => balance = value; }
        public bool IsLocked { get => isLocked; set => isLocked = value; }
        public string Nom { get => nom; set => nom = value; }

        public CompteClient()
        {
        }




        //Afficher le message en vert si correct 
        //Afficher le message en rouge si incorrect
        public static void PrintMessage(string msg, bool success)
        {
            if (success)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);
            Console.ResetColor();
            Console.WriteLine("Appuyer sur une touche pour continuer");
            Console.ReadKey();
        }


        //Fonction fermer le commpte 
        public static void LockAccount()
        {
            Console.Clear();
            PrintMessage("Le compte est vérouiller.", true);
            Console.WriteLine("Appeller l'admin pour le déverouiller.");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

        // La méthode abstraite Retirer   
        public abstract void Retrait(double montant);
        // La méthode abstraite Depot  
        public abstract void Depot(double montant);
        // La méthode abstraite AfficheSolde   
        public abstract string AfficherSolde();

        // La méthode abstraite Virement 
        public abstract void Virement(double montant);
        // La méthode abstraite PayBill 
        public abstract void PayBill(double montant);

        //methode normal:
        //methode changer mot passe
        //methode fermer session

    }
}
