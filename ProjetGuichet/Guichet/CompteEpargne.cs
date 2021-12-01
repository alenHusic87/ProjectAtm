using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{    
    class CompteEpargne : CompteClient
    {
        public CompteEpargne() { }
        public CompteEpargne(string nom, string numero, string pin, decimal balance, bool islocked ): base("Epargne")
        {
            GetNumeroCompte = numero;
            GetMotPasse = pin;
            GetBalance = balance;
            IsLocked = islocked;
            Nom = nom;
            
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
        public static decimal DepotDansleCompteEpargne(CompteClient account, List<CompteEpargne> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser();
            account = rv.GetByNumeroCompteEpargne(utilisateur, listeClients);

            while (account == null)
            {
                Console.WriteLine("Le Compte ne existe pas ");
                utilisateur = rv.EnterUser();
                account = rv.GetByNumeroCompteEpargne(utilisateur, listeClients);
            }

            decimal montant = rv.AmountToDeposit();
            while (montant <= 0 || montant.Equals(10000))
            {
                Console.WriteLine("Montant invalide ");
                montant = 0;
                montant = rv.AmountToDeposit();
            }

            account.GetBalance += montant;

            Console.WriteLine("Depot dans compte de {0} {1}: ${2} Total:${3}", account.AccountType, utilisateur, montant, account.GetBalance);

            return account.GetBalance;
        }
        public override decimal DepotDansleCompte(CompteClient account, List<CompteClient> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser();
            account = rv.GetByNumeroCompte(utilisateur, listeClients);
            while (account == null)
            {
                Console.WriteLine("Account doesn't exist");
                utilisateur = rv.EnterUser();
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
        public static decimal RaitraitDansleCompteEpargne(CompteClient account, List<CompteEpargne> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser();
            account = rv.GetByNumeroCompteEpargne(utilisateur, listeClients);

            while (account == null)
            {
                Console.WriteLine("Le Compte ne existe pas ");
                utilisateur = rv.EnterUser();
                account = rv.GetByNumeroCompteEpargne(utilisateur, listeClients);
            }

            decimal montant = rv.AmountToRetire();
            while (montant <= 0)
            {
                CompteClient.PrintMessage("Le montant ne peut pas être négatif", false); ;
                montant = 0;
                montant = rv.AmountToRetire();
            }
            if (account.GetBalance <= 0)
            {
                CompteClient.PrintMessage("Le compte est insuffisant", false);
            }
            else if (account.GetBalance >= montant)
            {
                account.GetBalance = account.GetBalance - montant;
            }

            //account.GetBalance -= montant;

            Console.WriteLine("Retarait dans compte de {0} {1}: ${2} Total:${3}", account.AccountType, utilisateur, montant, account.GetBalance);

            return account.GetBalance;
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
