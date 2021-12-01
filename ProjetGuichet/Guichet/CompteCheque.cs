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
        public CompteCheque(string nom, string numero, string pin, decimal balance, bool islocked ):base("Cheque")
        {
            GetNumeroCompte = numero;
            GetMotPasse = pin;
            GetBalance = balance;
            IsLocked = islocked;
            Nom = nom;
            
            
        }
        public static decimal DepotDansleCompteCheque(CompteClient account, List<CompteCheque> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser();
            account = rv.GetByNumeroCompteCheque(utilisateur, listeClients);

            while (account == null)
            {
                Console.WriteLine("Le Compte ne existe pas ");
                utilisateur = rv.EnterUser();
                account = rv.GetByNumeroCompteCheque(utilisateur, listeClients);
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

        public static  decimal RaitraitDansleCompteCheque(CompteClient account, List<CompteCheque> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser();
            account = rv.GetByNumeroCompteCheque(utilisateur, listeClients);

            while (account == null)
            {
                Console.WriteLine("Le Compte ne existe pas ");
                utilisateur = rv.EnterUser();
                account = rv.GetByNumeroCompteCheque(utilisateur, listeClients);
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
                CompteClient.PrintMessage("Le compte est insuffisant",false);
            }
            else if (account.GetBalance >= montant)
            {
                account.GetBalance = account.GetBalance - montant;
            }

            //account.GetBalance -= montant;

            Console.WriteLine("Retarait dans compte de {0} {1}: ${2} Total:${3}", account.AccountType, utilisateur, montant, account.GetBalance);

            return account.GetBalance;
        }
        public override decimal DepotDansleCompte(CompteClient account, List<CompteClient> listeClients)
        {
            InternalClass rv = new InternalClass();
            string utilisateur = rv.EnterUser();
            account = rv.GetByNumeroCompte(utilisateur, listeClients);
           
            while (account==null)
            {
                Console.WriteLine("Le Compte ne existe pas ");
                utilisateur = rv.EnterUser();
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
           
            Console.WriteLine("Depot dans compte de {0} {1}: ${2} Total:${3}", AccountType, utilisateur, montant ,GetBalance);

            return account.GetBalance;
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
