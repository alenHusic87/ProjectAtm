using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    class InternalClass
    {
        
        internal string EnterUser(string discription)
        {
            Console.WriteLine("Numéro de Compte "+ discription);
            string user = Console.ReadLine();

            return user;
        }

        internal string EnterPasword()
        {
            Console.WriteLine("Mot de passe:");
            string pasword = Console.ReadLine();

            return pasword;
        }
        internal decimal AmountToRetire()
        {
            decimal montant = 0;
            bool result = false;

            while (!result || montant<0)
            {
                Console.WriteLine("Entrer le montant à retirer ");
                result = Decimal.TryParse(Console.ReadLine(), out montant);
                if (!result)
                {
                    Console.WriteLine("Entrer seulement des chiffres");
                }
                if (montant== 0) 
                {
                    Console.WriteLine("Le montant ne peut pas être 0.");
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
                Console.WriteLine("Entrer le montant à deposer ");
                result = Decimal.TryParse(Console.ReadLine(), out montant);
                if (!result)
                {
                    Console.WriteLine("Entrer seulement des chiffres");
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
                Console.WriteLine("Entrer le montant à payer ");
                result = Decimal.TryParse(Console.ReadLine(), out montant);
                if (!result)
                {
                    Console.WriteLine("Entrer seulement des chiffres");
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
