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
        
        protected string motpass;   // minimum 4 caractere nimporte que type de caractere
        protected bool isLocked;
        protected string typecompte;

        public string GetTypeCompte { get => typecompte; set => typecompte = value; }
        public string GetNumeroCompte { get => numerocompte; set => numerocompte = value; }
        public string GetMotPass { get => motpass; set => motpass = value; }
        public double GetBalance { get => balance; set => balance = value; }
        public bool IsLocked { get => isLocked; set => isLocked = value; }

        public CompteClient()
        {
        }




        //Affiche le message en Yellow si ce corect 
        //Affiche le message en Rouge si ce pas corect
        public static void PrintMessage(string msg, bool success)
        {
            if (success)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);
            Console.ResetColor();
            Console.WriteLine("presse sur nimporte quoi pour  continue");
            Console.ReadKey();
        }


        //Function to ferme le commpte 
        public static void LockAccount()
        {
            Console.Clear();
            PrintMessage("TOn  Comptes est locked.", true);
            Console.WriteLine("Appel Admin pour unlocked.");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

        // La méthode abstraite Retire   
        public abstract void Retrait(double montant);
        // La méthode abstraite Depot  
        public abstract void Depot(double montant);
        // La méthode abstraite AfficheSold   
        public abstract string AfficheSold();

        // La méthode abstraite Virment 
        public abstract void Virment(double montant);
        // La méthode abstraite PayBill 
        public abstract void PayBill(double montant);

        //metohde normal:
        //methode change mote pass
        //methode fereme  session

    }
}
