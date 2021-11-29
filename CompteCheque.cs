using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Guichet
{
    class CompteCheque : CompteClient
    {
        static decimal balanceCheque;

        static decimal BalanceCheque { get => balanceCheque; set => balanceCheque = value; }

        public CompteCheque(decimal balancecheque,decimal blaanceepargne)
        {
            GetBalancCheque = balancecheque;
            GetBalancEpargne = blaanceepargne;
        }
        public CompteCheque(string nom, string numero, string pin, decimal balance, bool islocked ,CompteEpargne epargne)
        {
            GetNumeroCompte = numero;
            GetMotPasse = pin;
            GetBalance = balance;
            IsLocked = islocked;
            Nom = nom;
            //GetEpargne = epargne;
            
        }

        public override void Retrait(decimal montant)
        {
           
            // on effectue le Retrait  
            //ajouter la logique 
            //voir si le solde final reste supérieur, si oui, on peut retirer
            GetBalance -= montant;

     
        }

        public override void Depot(decimal montant)
        {
            // on effectue le Depot  
            // ajouter la logique 
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
        public static decimal ReturnBalanceCheque()
        {
            return BalanceCheque;
        }
    }

   
}
