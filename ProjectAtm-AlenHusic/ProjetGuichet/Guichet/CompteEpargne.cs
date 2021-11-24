using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{    
    class CompteEpargne : CompteClient
    {
        public CompteEpargne(string nom, string numero, string pin, double balance, bool islocked)
        {
            this.numerocompte = numero;
            this.motpasse = pin;
            this.balance = balance;
            this.isLocked = islocked;
            this.nom = nom;
        }
        public override void Retrait(double montant)
        {
            // on effectue le retrait  
            //si le solde final reste supérieur  on peut retirer
            GetBalance -= montant;
        }
        public override void Depot(double montant)
        {
            // on n'effectue le Depot  
            //ici on devrais ajouter la logique 
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
            return "Le solde du compte " + numerocompte + " est de " + balance + "$";
        }

    }
}
