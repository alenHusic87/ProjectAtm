using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Guichet
{
    abstract class CompteClient
    {
        protected string numerocompte;
        protected decimal balance;
        protected string nom;
        protected string motpasse;   // minimum 4 caractere peut importe le type 
        protected bool isLocked;
        protected string typecompte;


        public string GetTypeCompte { get => typecompte; set => typecompte = value; }
        public string GetNumeroCompte { get => numerocompte; set => numerocompte = value; }
        public string GetMotPasse { get => motpasse; set => motpasse = value; }
        public decimal GetBalance { get => balance; set => balance = value; }
        public bool IsLocked { get => isLocked; set => isLocked = value; }
        public string Nom { get => nom; set => nom = value; }
        public List<CompteClient> ClientsList { get; private set; }
       

        public CompteClient()
        {
        }

        public CompteClient(string numerocompte, string  motpasse, decimal balance)
        {
            this.numerocompte = numerocompte;
            this.motpasse = motpasse;
            this.balance = balance;
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
        }


        //Fonction fermer le commpte 
        public static void LockAccount()
        {
            PrintMessage("Vous avez saisi 3 fois des données incorrect. Le compte est vérouiller.", false);
            Console.WriteLine("Appeller l'admin pour le déverouiller.");
            System.Environment.Exit(1);
        }

        // La méthode abstraite Retirer   
        public abstract void Retrait(decimal montant);
        // La méthode abstraite Depot  
        public abstract void Depot(decimal montant);
        // La méthode abstraite AfficheSolde   
        public abstract string AfficherSolde();

        // La méthode abstraite Virement 
        public abstract void Virement(decimal montant);
        // La méthode abstraite PayBill 
        public abstract void PayBill(decimal montant);

        //public abstract double VirmentEntreCompte(CompteCheque source, CompteEpargne destinataire, int montant);

        public abstract void VirmentEntreCompte(CompteClient Receiver, decimal montant);

       public void ChangeMotPass() 
        {
            string firstPin, secondPin;

            Console.WriteLine("Enter Le nouveu mot de passe: ");
            firstPin = Console.ReadLine();
            Console.WriteLine("Reentre  a nouve le mote de passe : ");
            secondPin = Console.ReadLine();
            if (firstPin == secondPin)
            {
                Console.WriteLine("Le mote de passe a ete change avce suces!");
                GetMotPasse = firstPin;
            }
            else
            {
                Console.WriteLine("le mote passe ne matche pas ");
                ChangeMotPass();
            }
        }


    }
}
