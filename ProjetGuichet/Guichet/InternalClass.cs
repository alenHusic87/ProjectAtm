using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    class InternalClass
    {
        
        internal string EnterUser()
        {
            Console.WriteLine("Numero de Compte :");
            string iban = Console.ReadLine();

            return iban;
        }
        internal string EnterPasword()
        {
            Console.WriteLine("pasword:");
            string pasword = Console.ReadLine();

            return pasword;
        }
        internal decimal AmountToRetire()
        {
            decimal montant = 0;
            bool result = false;

            while (!result)
            {
                Console.WriteLine("Entre Montant a retire ");
                result = Decimal.TryParse(Console.ReadLine(), out montant);
                if (!result)
                {
                    Console.WriteLine("Ecrive juste de chifre.");
                }

            }

            return montant;
        }

        internal decimal AmountToDeposit()
        {
            decimal montant=0;
            bool result = false;

            while (!result)
            {
                Console.WriteLine("Entre Montant a depose ");
                result = Decimal.TryParse(Console.ReadLine(), out montant);
                if (!result)
                {
                    Console.WriteLine("Ecrive juste de chifre.");
                }

            }

            return montant;
        }

        internal CompteClient GetByNumeroCompte(string utlisateur, List<CompteClient> listeClients)
        {
            CompteClient client = listeClients.Find(c => c.GetNumeroCompte == utlisateur);

            if (client != null)
            {
                return client;
            }
            else
            {
                return null;
            }
        }
        internal CompteClient GetByNumeroCompteCheque(string utlisateur, List<CompteCheque> listeClients)
        {
            CompteClient client = listeClients.Find(c => c.GetNumeroCompte == utlisateur);

            if (client != null)
            {
                return client;
            }
            else
            {
                return null;
            }
        }
        internal CompteClient GetByNumeroCompteEpargne(string utlisateur, List<CompteEpargne> listeClients)
        {
            CompteClient client = listeClients.Find(c => c.GetNumeroCompte == utlisateur);

            if (client != null)
            {
                return client;
            }
            else
            {
                return null;
            }
        }
        internal CompteClient GetPasword(string pasword, List<CompteClient> listeClients)
        {
            CompteClient client = listeClients.Find(c => c.GetMotPasse == pasword);

            if (client != null)
            {
                return client;
            }
            else
            {
                return null;
            }
        }
    }
}
