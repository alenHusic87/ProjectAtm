using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Guichet
{
    abstract class CompteClient
    {
        protected string numerocompte;
        protected decimal balance;
        protected string nom;
        protected  string motpasse;   // minimum 4 caractere peut importe le type 
        protected bool isLocked;
        protected string typecompte;

        private decimal balancEpargne;
        private decimal balancCheque;
        protected CompteCheque chequ;
        protected static CompteEpargne epargne;
        public decimal TransferAmount { get; set; }
   

        public string GetTypeCompte { get => typecompte; set => typecompte = value; }
        public string GetNumeroCompte { get => numerocompte; set => numerocompte = value; }
        public  string GetMotPasse { get => motpasse; set => motpasse = value; }
        public  decimal GetBalance { get => balance; set => balance = value; }
        public bool IsLocked { get => isLocked; set => isLocked = value; }
        public string Nom { get => nom; set => nom = value; }
        public List<CompteClient> ClientsList { get; private set; }
        public CompteCheque GetChequ { get => chequ; set => chequ = value; }
        public CompteEpargne GetEpargne { get => epargne; set => epargne = value; }
        public decimal GetBalancEpargne { get => balancEpargne; set => balancEpargne = value; }
        public decimal GetBalancCheque { get => balancCheque; set => balancCheque = value; }
     

        public CompteClient()
        {
        }

       /* public CompteClient(CompteCheque chequ ,CompteEpargne epargne)
        {
            this.chequ = chequ;
            this.epargne = epargne;
        }*/
        public CompteClient(string numerocompte, string  motpasse, decimal balance)
        {
            this.numerocompte = numerocompte;
            this.motpasse = motpasse;
            this.balance = balance;
        }
    

        //Afficher le message en vert si correct 
        //Afficher le message en rouge si incorrect
        public static void PrintMessage(string msg, bool success)
        {
            if (success)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);
            Console.ResetColor();
        }

        //Fonction fermer le commpte 
        public static void LockAccount()
        {
            PrintMessage("Vous avez saisi 3 fois des données incorrect. Le compte est vérouiller.", false);
            Console.WriteLine("Appeller l'admin pour le déverouiller.");
            System.Environment.Exit(1);
        }

        // La méthode abstraite Retirer   
        public abstract void Retrait(decimal montant);
        // La méthode abstraite Depot  
        public abstract void Depot(decimal montant);
        // La méthode abstraite AfficheSolde   
        public abstract string AfficherSolde();

        // La méthode abstraite Virement 
        public abstract void Virement(decimal montant);
        // La méthode abstraite PayBill 
        public abstract void PayBill(decimal montant);

        public static  void VirmentCompte(CompteClient celuiquienvoie, CompteClient destinataire,decimal montant)
        {
            ///Console.WriteLine("*** Veuillez saisir vois 5 nombres en 1 et 200 ***");


                    

            
                    if (montant <= 0)
                    {
                        CompteClient.PrintMessage("le monta devrai etre plus grande que zero", false);

                    }
                    else if (celuiquienvoie.GetBalance < montant)
                    {
                        CompteClient.PrintMessage($"Retrai ne function pas tu nas pas assez de money money ", false);

                    }
                    else
                    {

                        celuiquienvoie.Retrait(montant);
                        destinataire.Depot(montant);
                        CompteClient.PrintMessage($"tu as bine trensfere   {montant + "$"} a {destinataire.GetNumeroCompte + "    " + " NOm:" + " " + destinataire.Nom }", true);
                    }
   

           

            /*if (montant <= 0)
            {
                CompteClient.PrintMessage("le monta devrai etre plus grande que zero", false);

            }
            else if (celuiquienvoie.GetBalance < montant)
            {
                CompteClient.PrintMessage($"Retrai ne function pas tu nas pas assez de money money ", false);

            }
            else
            {

                celuiquienvoie.Retrait(montant);
                destinataire.Depot(montant);
                CompteClient.PrintMessage($"tu as bine trensfere   {montant + "$"} a {destinataire.GetNumeroCompte +  "    "  +  " NOm:"  + " " +destinataire.Nom }", true);
            }*/
        }

        public   void ChangeMotPass() 
        {

            string premierPin, deuxiemePin;
            string troisiemePin;

             Console.WriteLine("Enter actuel  mot de passe: ");
            premierPin = Console.ReadLine();

            if (premierPin == GetMotPasse)
            {

                Console.WriteLine("Reentre   ton nouve mote passe  : ");
                deuxiemePin = Console.ReadLine();
                Console.WriteLine("Confirme ton mot de passe : ");
                troisiemePin = Console.ReadLine();

                if(troisiemePin == deuxiemePin) 
                {
                    GetMotPasse = troisiemePin;
                }
                else
                {
                    Console.WriteLine("le  nouve mote passe ne est pa pareille : ");
                    ChangeMotPass();
                }
            }
            else
            {
                Console.WriteLine("Ton mot passe actuel n eats pa celui la que tu as rentre  ");
                ChangeMotPass();
            }
            
        }
    }
}
