using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Guichet
{
   public  abstract class CompteClient
    {
        protected string numerocompte;
        protected decimal balance;
        protected string nom;
        protected  string motpasse;   // minimum 4 caractere peut importe le type 
        protected bool isLocked;
        protected string typecompte;

        private decimal balancEpargne;
        private decimal balancCheque;
        //protected CompteCheque chequ;
       /// protected static CompteEpargne epargne;
        public decimal TransferAmount { get; set; }
   

        public string GetTypeCompte { get => typecompte; set => typecompte = value; }
        public string GetNumeroCompte { get => numerocompte; set => numerocompte = value; }
        public  string GetMotPasse { get => motpasse; set => motpasse = value; }
        public  decimal GetBalance { get => balance; set => balance = value; }
        public bool IsLocked { get => isLocked; set => isLocked = value; }
        public string Nom { get => nom; set => nom = value; }
        public List<CompteClient> ClientsList { get; private set; }
       // public CompteCheque GetChequ { get => chequ; set => chequ = value; }
       // public CompteEpargne GetEpargne { get => epargne; set => epargne = value; }
        public decimal GetBalancEpargne { get => balancEpargne; set => balancEpargne = value; }
        public decimal GetBalancCheque { get => balancCheque; set => balancCheque = value; }

        public string AccountType { get; set; }
        public CompteClient() {  }

        public CompteClient(string numerocompte, string  motpasse, decimal balance)
        {
            this.numerocompte = numerocompte;
            this.motpasse = motpasse;
            this.balance = balance;
        }
        public CompteClient(string type)
        {
            this.AccountType = type;
        }

        
        public abstract void Retrait(decimal montant);
        public abstract string AfficherSolde();
        public abstract void DepotparDefaut(decimal montant);
        public abstract void Virement(decimal montant);
        public abstract void PayBill(decimal montant);
        public abstract decimal DepotDansleCompte(CompteClient account, List<CompteClient> listeClients);
        public static  void VirmentCompte(CompteClient celuiquienvoie, CompteClient destinataire,decimal montant)
        {
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
                if(montant >= 1000) 
                {
                    InternalClass intercals = new InternalClass();
                    CompteClient.PrintMessage($"Neeed Pasword ", false);
                    intercals.EnterPasword();
                }
                else 
                {
                    celuiquienvoie.Retrait(montant);
                    destinataire.DepotparDefaut(montant);
                    CompteClient.PrintMessage($"tu as bine trensfere   {montant + "$"} a {destinataire.GetNumeroCompte + "    " + " NOm:" + " " + destinataire.Nom }", true);

                }

            }

        }
        public virtual void ShowBalance()
        {
            Console.WriteLine("Balance de account {0} {1}: ${2}", this.AccountType, this.GetNumeroCompte, this.GetBalance);

        }
        public bool isValidPin(string s)
        {
            if (s.Length == 0 || s.Length > 4)
            {
                return false;
                Console.WriteLine($"mot de passe devrai etre plus grande que 4   ");
            }
     
            return true;
        }
        public static void LockAccount()
        {
            PrintMessage("Vous avez saisi 3 fois des données incorrect. Le compte est vérouiller.", false);
            Console.WriteLine("Appeller l'admin pour le déverouiller.");
            //System.Environment.Exit(1);
        }
        public static void PrintMessage(string msg, bool success)
        {
            if (success)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public   void ChangeMotPass() 
        {
            string actuelPin, deuxiemePin;
            string troisiemePin;

            Console.WriteLine("Enter actuel  mot de passe: ");
            actuelPin = Console.ReadLine();

         

            if (actuelPin.Equals(GetMotPasse))
            {

                Console.WriteLine("Reentre   ton nouve mote passe  : ");
                deuxiemePin = Console.ReadLine();
                //isValidPin(deuxiemePin);
                Console.WriteLine("Confirme ton mot de passe : ");
                troisiemePin = Console.ReadLine();

                if(troisiemePin.Equals(deuxiemePin)) 
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
