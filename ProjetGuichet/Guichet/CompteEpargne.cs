using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{    
    class CompteEpargne : CompteClient
    {
        public CompteEpargne() { }
        public CompteEpargne(string nom, string numero, string pin, decimal balance,decimal balanceEpargne, bool islocked ): base("Epargne")
        {
            GetNumeroCompte = numero;
            GetMotPasse = pin;
            GetBalance = balance;
            IsLocked = islocked;
            Nom = nom;
            GetBalanceEpargne = balanceEpargne;


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

        public override decimal DepotDansleCompte(CompteClient account, List<CompteClient> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser("");
            account = rv.GetByNumeroCompte(utilisateur, listeClients);
            while (account == null)
            {
                Console.WriteLine("Account doesn't exist");
                utilisateur = rv.EnterUser("");
                account = rv.GetByNumeroCompte(utilisateur, listeClients);
            }

            decimal montant = rv.AmountToDeposit();
            while (montant <= 0 || montant.Equals(10000))
            {
                Console.WriteLine("Amount invalide ");
                montant = 0;
                montant = rv.AmountToDeposit();
            }

            account.GetBalance += montant;
            Console.WriteLine("Added {0} to account {1}", montant, utilisateur);

            return account.GetBalance;
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
        public override void RetraitDeCompteEpargne(decimal montant)
        {
            // Nancy
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
        public override void PayerFacture(string Facture, decimal montant)
        {
            Retrait(montant + 2);
            Console.WriteLine("Réglement du facture : {0}", Facture);
        }


    }
}
