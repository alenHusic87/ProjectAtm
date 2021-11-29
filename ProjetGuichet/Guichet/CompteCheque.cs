﻿using System;
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
            // Nancy
            if (montant < 0)
            {
                Console.WriteLine("Le montant ne peut pas être négatif");
                return;
            }
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
            if (montant < 0)
            {
                Console.WriteLine("Le montant ne peut pas être négatif");
                return;
            }
            else
            {
                this.balance += montant;
            }
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
