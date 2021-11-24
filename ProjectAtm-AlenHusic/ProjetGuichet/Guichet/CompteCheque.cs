using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{    
    class CompteCheque : CompteClient
    {
        public CompteCheque() { }
        public CompteCheque(string numero ,string pin ,double balance,bool islocked)
        {
            this.numerocompte = numero;
            this.motpasse = pin;
            this.balance = balance;
            this.isLocked = islocked;

        }


        public override void Retrait(double montant)
        {
            // on n'effectue le Retrait  
            //ajouter la logique 
            //voir si le solde final reste supérieur, si oui, on peut retirer
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
        public override string AfficheSolde()
        {
            return "Le solde du compte de " + numerocompte + " est de " + balance + "$";
        }


    }
}
