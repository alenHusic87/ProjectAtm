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
            this.motpass = pin;
            this.balance = balance;
            this.isLocked = islocked;

        }


        public override void Retrait(double montant)
        {
            // on n'effectue le Retrait  
            //ici on devrais ajouter la logique 
            //apres on devrais faire si le solde final rest supérieur  on peut retire
            GetBalance -= montant;
        }
        public override void Depot(double montant)
        {
            // on n'effectue le Depot  
            //ici on devrais ajouter la logique 
            GetBalance += montant;
        }
        public override void Virment(double montant)
        {
            //TO DOOO
            GetBalance = GetBalance + montant;
        }
        public override void PayBill(double montant)
        {
            //TO DOOO
            GetBalance = GetBalance - montant;
        }
        public override string AfficheSold()
        {
            return "Le solde du compte de " + numerocompte + " est de " + balance + "$";
        }


    }
}
