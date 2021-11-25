using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    class CompteCheque : CompteClient
    {
        public CompteCheque() { }
        public CompteCheque(string nom, string numero, string pin, decimal balance, bool islocked)
        {
            this.numerocompte = numero;
            this.motpasse = pin;
            this.balance = balance;
            this.isLocked = islocked;
            this.nom = nom;
        }

        public override void VirmentEntreCompte(CompteClient destinataier, decimal montant)
        {
            this.Retrait(montant);
            destinataier.Depot(montant);
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
            return "Le solde du compte de " + numerocompte + " est de " + balance + "$";
        }


       /* public override void ChangeMotPass(CompteClient a, string numerocompte)
        {
            bool check = false;

            if (GetNumeroCompte == numerocompte) // valid acc_no  
            {
                
                check = true;
                if (check)
                {
                    Console.WriteLine("  User: " + a.GetNumeroCompte);
                    Console.Write("Enter existing pin: ");

                    try
                    {
                        string old_pin = a.GetMotPasse;

                        ConsoleKeyInfo key;
                        do
                        {
                            key = Console.ReadKey(true);
                            // Backspace Should Not Work  
                            if (key.Key != ConsoleKey.Backspace)
                            {
                                old_pin += key.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if ((old_pin.Length - 1) != -1)
                                {
                                    old_pin = old_pin.Remove(old_pin.Length - 1);
                                    Console.Write("\b \b");
                                }
                            }
                        }
                        while (key.Key != ConsoleKey.Enter);

                        if (a.GetMotPasse.Equals(int.Parse(old_pin)))
                        {
                            Console.Write("\n\t\t Enter new pin: ");
                            ConsoleKeyInfo key1;
                            old_pin = null;
                            do
                            {
                                key1 = Console.ReadKey(true);

                                // Backspace Should Not Work  
                                if (key1.Key != ConsoleKey.Backspace)
                                {
                                    old_pin += key1.KeyChar;
                                    Console.Write("*");
                                }
                                else
                                {
                                    if ((old_pin.Length - 1) != -1)
                                    {
                                        old_pin = old_pin.Remove(old_pin.Length - 1);
                                        Console.Write("\b \b");
                                    }
                                }

                            }
                            while (key.Key != ConsoleKey.Enter);

                            Console.Write("\n\t\t Re-Enter new pin: ");
                            string cur_pin = ""; ;
                            do
                            {
                                key = Console.ReadKey(true);

                                // Backspace Should Not Work  
                                if (key.Key != ConsoleKey.Backspace)
                                {
                                    cur_pin += key.KeyChar;
                                    Console.Write("*");
                                }
                                else
                                {
                                    if ((cur_pin.Length - 1) != -1)
                                    {
                                        cur_pin = cur_pin.Remove(cur_pin.Length - 1);
                                        Console.Write("\b \b");
                                    }
                                }
                            }// Stops Receiving Keys Once Enter is Pressed  
                            while (key.Key != ConsoleKey.Enter);

                            if (int.Parse(old_pin) == int.Parse(cur_pin))
                            {
                                a.GetMotPasse.Equals(int.Parse(cur_pin));

                                Console.WriteLine("CHANGE OF PIN");
                                
                            }
                            else
                            {
                                Console.WriteLine("Both Pin ne marche pas ");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Pin");
                            return;
                        }
                    
                        }
                    catch (Exception)
                    { 

                    }



                }

            }
        }*/
    }
}
