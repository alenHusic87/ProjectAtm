using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    class InternalClass
    {
        
        internal string EnterUser(string discription)
        {
            Console.WriteLine("Numero de Compte "+ discription);
            string user = Console.ReadLine();

            return user;
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

            while (!result || montant<0)
            {
                Console.WriteLine("Entre Montant a retire ");
                result = Decimal.TryParse(Console.ReadLine(), out montant);
                if (!result)
                {
                    Console.WriteLine("Ecrive juste de chifre.");
                }
                if (montant== 0) 
                {
                    Console.WriteLine("montant ne peut pas etre 0.");
                }

            }

            return montant;
        }
        internal decimal AmountToDeposit()
        {
            decimal montant = 0;
            bool result = false;

            while (!result || montant<0)
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
        internal decimal AmountToPay()
        {
            decimal montant = 0;
            bool result = false;

            while (!result)
            {
                Console.WriteLine("Entre Montant a Payer ");
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
            CompteClient client = listeClients.Find(c => c.GetNumeroCompte.Equals(utlisateur));

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
            CompteClient client = listeClients.Find(c => c.GetMotPasse.Equals(pasword));

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
