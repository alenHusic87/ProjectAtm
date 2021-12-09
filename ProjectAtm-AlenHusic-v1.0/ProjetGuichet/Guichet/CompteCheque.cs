using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Guichet
{
    public class CompteCheque : CompteClient
    {
        static decimal balanceCheque;

        static decimal BalanceCheque { get => balanceCheque; set => balanceCheque = value; }
        public CompteCheque(string nom, string numero, string pin, decimal balance, decimal blanceEpargne, bool islocked, string etatcompte) : base("Cheque")
        {
            GetNumeroCompte = numero;
            GetMotPasse = pin;
            GetBalance = balance;
            IsLocked = islocked;
            Nom = nom;
            GetBalanceEpargne = blanceEpargne;
            GetEtatcompote = etatcompte;
        }

        public override decimal DepotDansleCompte(CompteClient account, List<CompteClient> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser("");
            account = rv.GetByNumeroCompte(utilisateur, listeClients);

            while (account == null)
            {
                Console.WriteLine("Le compte n'existe pas ");
                utilisateur = rv.EnterUser("");
                account = rv.GetByNumeroCompte(utilisateur, listeClients);
            }

            decimal montant = rv.AmountToDeposit();
            while (montant <= 0 || montant.Equals(10000))
            {
                Console.WriteLine("Montant invalide ");
                montant = 0;
                montant = rv.AmountToDeposit();
            }

            account.GetBalance += montant;

            Console.WriteLine("Depot dans compte de {0} {1}: ${2} Total:${3}", AccountType, utilisateur, montant, GetBalance);

            return account.GetBalance;
        }
        public override void Retrait(decimal montant)
        {
            // Nancy

            if (Guichet.GetMontatnDuGuichet >= montant)
            {
                if (montant < 0)
                {
                    Console.WriteLine("Le montant ne peut pas être négatif");
                    return;
                }
                if (this.balance <= 0)
                {
                    Console.WriteLine("Le compte est insuffisant");
                }
                else if (this.balance >= montant)
                {
                    this.balance = this.balance - montant;
                    Guichet.GetMontatnDuGuichet -= montant;
                }
                //Console.WriteLine("Pas asse dans Guichet");
            }
            else
            {
                Console.WriteLine("Pas assez d'argent dans le guichet");
            }
            if (Guichet.GetMontatnDuGuichet.Equals(0))
            {
                Console.WriteLine("Panne");
                Guichet.IsON = false;
                Guichet.clientCompteChequeAlen.IsLocked = true;
                Guichet.clientCompteEpargneAlen.IsLocked = true;
                Guichet.clientCompteChequeNancy.IsLocked = true;
                Guichet.clientCompteEpargneNancy.IsLocked = true;
                Guichet.clientCompteChequeJeanSimon.IsLocked = true;
                Guichet.clientCompteEpargneJeanSimon.IsLocked = true;
                CompteClient.LockGuichet();
            }
        }
        public override void RetraitDeCompteEpargne(decimal montant)
        {
            if (Guichet.GetMontatnDuGuichet >= montant)
            {
                if (montant < 0)
                {
                    Console.WriteLine("Le montant ne peut pas être négatif");
                    return;
                }
                if (this.GetBalanceEpargne <= 0)
                {
                    Console.WriteLine("Le compte est insuffisant");
                }
                else if (this.GetBalanceEpargne >= montant)
                {
                    this.GetBalanceEpargne = this.GetBalanceEpargne - montant;
                    Guichet.GetMontatnDuGuichet -= montant;
                }
                //Console.WriteLine("Pas asse dans Guichet");
            }
            else
            {
                Console.WriteLine("Pas assez d'argent dans le guichet");
            }
            if (Guichet.GetMontatnDuGuichet == 0)
            {
                Console.WriteLine("Panne");
                Guichet.IsON = false;
                Guichet.clientCompteChequeAlen.IsLocked = true;
                Guichet.clientCompteEpargneAlen.IsLocked = true;
                Guichet.clientCompteChequeNancy.IsLocked = true;
                Guichet.clientCompteEpargneNancy.IsLocked = true;
                Guichet.clientCompteChequeJeanSimon.IsLocked = true;
                Guichet.clientCompteEpargneJeanSimon.IsLocked = true;
                CompteClient.LockGuichet();
            }
        }
        public override void DepotparDefaut(decimal montant)
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
        public override void DepotparDefautDansEpargne(decimal montant)
        {
            if (montant < 0)
            {
                Console.WriteLine("Le montant ne peut pas être négatif");
                return;
            }
            else
            {
                this.GetBalanceEpargne += montant;
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
        public override void PayerFacture(string Facture, decimal montant)
        {
            Retrait(montant + 2);
            Console.WriteLine("Régler la facture : {0}", Facture);
        }
    }

   
}
