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
        private decimal balanceEpargne;
        protected string nom;
        protected string motpasse;   // minimum 4 caractere peut importe le type 
        protected bool isLocked;
        private string etatcompote;


        public string GetNumeroCompte { get => numerocompte; set => numerocompte = value; }
        public  string GetMotPasse { get => motpasse; set => motpasse = value; }
        public  decimal GetBalance { get => balance; set => balance = value; }
        public bool IsLocked { get => isLocked; set => isLocked = value; }
        public string Nom { get => nom; set => nom = value; }


        public string AccountType { get; set; }
        public decimal GetBalanceEpargne { get => balanceEpargne; set => balanceEpargne = value; }
        public string GetEtatcompote { get => etatcompote; set => etatcompote = value; }

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
        public static string EnterUser()
        {
            Console.WriteLine("Numero de Compte :");
            string iban = Console.ReadLine();

            return iban;
        }
        public abstract void PayerFacture(string Facture, decimal montant);
        public abstract void Retrait(decimal montant);
        public abstract void RetraitDeCompteEpargne(decimal montant);
        public abstract string AfficherSolde();
        public abstract void DepotparDefaut(decimal montant);
        public abstract void DepotparDefautDansEpargne(decimal montant);
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
                    int mauvaiscoup = 0;     
                    string usagerLogin;
                    string password;
                    while (mauvaiscoup < 3)
                    {
                        usagerLogin = intercals.EnterUser("Destinataire");
                        password = intercals.EnterPasword();                 
                        if (celuiquienvoie.GetNumeroCompte.Equals(usagerLogin) && celuiquienvoie.GetMotPasse.Equals(password))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nom utilisateur ou mot de passe incorrecte");
                            Console.WriteLine();
                        }
                        mauvaiscoup++;
                    }
                    if (mauvaiscoup.Equals(3))
                    {
                        celuiquienvoie.isLocked = true;
                        CompteClient.LockAccount();

                    }
                    else
                    {
                        celuiquienvoie.Retrait(montant);
                        destinataire.DepotparDefaut(montant);
                        CompteClient.PrintMessage($"tu as bine trensfere   {montant + "$"} a {destinataire.Nom  + "\tDe compte " + "\t"+celuiquienvoie.Nom }", true);
                        CompteClient.PrintMessage($"Le Nouve  solde   du Reciver est de {destinataire.GetBalance + "$" + "\tle nouve sold du Destinataire est de " + celuiquienvoie.GetBalance + "$" }", true);
                    }

                }
                else 
                {
                    celuiquienvoie.Retrait(montant);
                    destinataire.DepotparDefaut(montant);
                    CompteClient.PrintMessage($"tu as bine trensfere   {montant + "$"} a {destinataire.Nom + "\tDe compte " + "\t" + celuiquienvoie.Nom }", true);
                    CompteClient.PrintMessage($"Le Nouve  solde   du Reciver est de {destinataire.GetBalance + "$" + "\tle nouve sold du Destinataire est de " + celuiquienvoie.GetBalance + "$" }", true);

                }

            }

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
        public void ChangeMotPass()
        {
            Console.WriteLine("Entrer le mot de passe actuel:");
            string actuelMotPasse = Console.ReadLine();
            Console.WriteLine("Entrer le nouveau mot de passe:");
            string nouveauMotPasse = Console.ReadLine();
            Console.WriteLine("Confirmer le nouveau mot de passe :");
            string confirmation = Console.ReadLine();
            if (!nouveauMotPasse.Length.Equals(actuelMotPasse.Length))
            {
                Console.WriteLine("Le format du nouveau mot de passe est incorrect");
            }
            else if (nouveauMotPasse.Equals(actuelMotPasse))
            {
                Console.WriteLine("Le nouveau de mot de passe doit etre different de l'actuel mot de passe");
            }
            else if (confirmation.Equals(nouveauMotPasse))
            {
                GetMotPasse = nouveauMotPasse;
                Console.WriteLine("Changement de mot de passe avec succes");
                Console.WriteLine();
            }
            else
            {
                while (!confirmation.Equals(nouveauMotPasse))
                {
                    Console.WriteLine("Veuillez confirmer le nouveau Mot de passe ");
                    confirmation = Console.ReadLine();
                    if (confirmation.Equals(nouveauMotPasse))
                    {
                        Console.WriteLine("Changement de mot de passe effecuté avec success");
                    }
                    else
                    {
                        Console.WriteLine("Mot de passe confirmation doit etre egale au nouveau mot de passe");
                    }
                }
            }

        }

    }
}
