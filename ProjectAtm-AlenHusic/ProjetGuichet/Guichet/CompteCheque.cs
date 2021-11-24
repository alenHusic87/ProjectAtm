using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{    
    class CompteCheque : CompteClient
    {
        public CompteCheque() { }
        public CompteCheque(string nom, string numero, string pin, double balance, bool islocked)
        {
            this.numerocompte = numero;
            this.motpasse = pin;
            this.balance = balance;
            this.isLocked = islocked;
            this.nom = nom;
        }


        public override void Retrait(double montant)
        {
            // on effectue le Retrait  
            //ajouter la logique 
            //voir si le solde final reste supérieur, si oui, on peut retirer
            GetBalance -= montant;
        }
        public override void Depot(double montant)
        {
            // on effectue le Depot  
            // ajouter la logique 
            GetBalance += montant;
        }
        public override void Virement(double montant)
        {
            //TO DOOO
            GetBalance = GetBalance + montant;
        }
        public override void PayBill(double montant)
        {
            //TO DOOO
            GetBalance = GetBalance - montant;
        }
        public override string AfficherSolde()
        {
            return "Le solde du compte de " + numerocompte + " est de " + balance + "$";
        }


    }
}
