using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{    
    class CompteEpargne : CompteClient
    {
        public CompteEpargne() { }
        public CompteEpargne(string nom, string numero, string pin, decimal balance, bool islocked ,CompteCheque chequ)
        {
            GetNumeroCompte = numero;
            GetMotPasse = pin;
            GetBalance = balance;
            IsLocked = islocked;
            Nom = nom;
            GetChequ = chequ;
        }
        public override void Retrait( decimal montant)
        {
            // Nancy
            if (balance <= 0)
            {
                Console.WriteLine("Le compte est insuffisant");
            }
            else if (balance >= montant)
            {
                this.balance = this.balance - montant;
            }
        }
        public override void Depot(decimal montant)
        {
            // on n'effectue le Depot  
            //ici on devrais ajouter la logique 
            GetBalance += montant;
        }
        public override void Virement(decimal montant)
        {
            //TO DOOO
            GetBalance = GetBalance + montant;
        }
        public override void PayBill(decimal montant)
        {
            //TO DOOO
            GetBalance = GetBalance - montant;
        }
        public override string AfficherSolde()
        {
            return "Le solde du compte de " + GetNumeroCompte + " est de " + GetBalance + "$";
        }
   
    }
}
