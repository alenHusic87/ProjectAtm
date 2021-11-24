using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
 /*   Démarrage et comportement du système :
Lorsque le guichet démarre, il doit avoir 10 000$ comme montant
disponible ainsi, lorsqu’un usager retire 1 000$, le montant
disponible du GUICHET sera maintenant de 9 000$. Il ne doit pas
être possible de retirer de l’argent du guichet lorsque le montant
du retrait est plus élevé que le montant disponible. Les dépôts des
usagers n’affectent pas le montant disponible dans le guichet. En
d’autres mots, si aucun retrait n’a été effectué et qu’un usager
dépose 1 000$ alors le système n’aura pas 11 000$ comme
disponible.
Lorsque le guichet ne possède plus assez de fonds, il doit être en
mode « panne ». Un système de gestion interne doit permettre de
gérer cet état. Ainsi, seul un administrateur peut être en mesure de
remettre le guichet en fonction et aucun usager ne pourra retirer
de l’argent.
Un administrateur peut remettre de l’argent à l’intérieur du
Guichet. Pour se faire, il se connecte comme administrateur et
effectue un dépôt.
Lorsque le système démarre, il doit y avoir une liste de comptes en
mémoire (minimum 5 comptes clients) et un compte
administrateur. Ainsi, au démarrage de l’application, un utilisateur
de la liste peut accéder à son compte*/


    public class Guichet
    {
        // montat depart 10 000$;
        // voir la liste de compte
        private int mDepart = 10000;

        private int mDeposedansGuichet = 0;

        private string nbdeCompte;
        private static CompteCheque inputAccount;
        private static CompteCheque selectedAccount;

        private  int tries;
        private const int maxTries = 3;


        public string NbdeCompte { get => nbdeCompte; set => nbdeCompte = value; }

        private List<CompteClient> listeClients = new List<CompteClient>();


        private List<CompteCheque> comptesCheques = new List<CompteCheque>();
        private List<CompteEpargne> compteEpargne = new List<CompteEpargne>();
        private IEnumerable<CompteCheque> compteCheques;

        public Guichet()
        {
            CompteCheque client = new CompteCheque("Marc", "123456", "1234", 100.50, false);
            comptesCheques.Add(new CompteCheque("Marc", "12345", "1234", 100.50, false));
            comptesCheques.Add(client);
            compteEpargne.Add(new CompteEpargne("Marc", "12345678", "1234", 109.50, false));

            Login();

            foreach (CompteCheque a in compteCheques)
            {
               Console.WriteLine($"Numero de compte Cheques  : {a.GetNumeroCompte}  {a.GetMotPasse}  {a.GetBalance} ");
            }
            foreach (CompteEpargne a in compteEpargne)
            {

                Console.WriteLine($"Numero de compte Epargne  : {a.GetNumeroCompte} {a.GetBalance} ");
            }

            CompteCheque compteCourant = new CompteCheque("Marc", "Djavo", "1234", 100.50, false);
            Console.Write("Entrez le montant du retrait : ");
            double montantretrait = Convert.ToDouble(Console.ReadLine());
            

            compteCourant.Retrait(montantretrait);

            
            Console.WriteLine(compteCourant.AfficherSolde());
            Console.WriteLine(compteCourant.GetMotPasse);

            Console.Write("Entrez le montant du dépot : ");
            double montantDepot = Convert.ToDouble(Console.ReadLine());
            compteCourant.Virement(montantDepot);
 

            Console.Write("Entrez le montant à payer : ");
            double montanttoPay = Convert.ToDouble(Console.ReadLine());
            compteCourant.PayBill(montanttoPay);

            Console.WriteLine(compteCourant.AfficherSolde());

        }

        //Initialiser les 5 utilisateur
        //et devrais appeller la methode dans Constructeur du guichet
        public void Initialization()
        {
            mDepart = 0;
            comptesCheques.Add(new CompteCheque("Marc","CompteCheques", "1234", 100.50, false));
            compteEpargne.Add(new CompteEpargne("Marc","CompteEpargne", "1234", 100.50, false));
        }

        public void Login()
        {
            Console.WriteLine( "Veuillez choisir l'une des actions suivantes:\n" +
                "1- Se connecter à votre compte\n" +
                "2- Se connecter comme administrateur\n" +
                "3- Quitter\n");
            try
            {
                string user = Console.ReadLine();
                // Checking if input is correct
                if (user == "1" || user == "2" || user == "3")
                {

                    switch (user)
                    {
                        // Case 1 pour Admin Login
                        case "1":
                            Console.WriteLine("-----Accès client-----\n" +
                                " Entrer numéro de compte & mot de passe");

                            //Declare  a Admin object
                            Admin admin = new Admin();
                            bool isSignedin = false;
                            while (!isSignedin)
                            {
                                // Lire le userName du admin
                                Console.Write("Utilisateur: ");
                                admin.GetAdminuser = Console.ReadLine();
                                
                            }

                                break;
                        // Case 2 pour Client Login
                        case "2":
                            CompteCheque client = new CompteCheque("Marc","123456", "1234", 100.50, false);
                            string numerocompte = client.GetNumeroCompte;
                            string motpasse = client.GetMotPasse;
                            //bool isSignedin = false;
                            Console.WriteLine("-----Accès client-----\n" +
                                "Entrer numero de compte & mot de passe");
                        
                                // Lire le userName du client 
                                Console.Write("Utilisateur: ");
                                client.GetNumeroCompte = Console.ReadLine();

                            if (client.GetNumeroCompte.Equals(numerocompte) )
                            {
                                    Console.WriteLine("Le numéro de compte est valide ");
                                    
                                //Afficher le reste 
                                int mauvais = 0;
                                gotoPin:
                                Console.Write("Mot de passe: ");
                                client.GetMotPasse = Console.ReadLine();
                                if (client.GetMotPasse.Equals(motpasse)) 
                                {
                                    Console.WriteLine("Le mot de passe du client est valide ");
                                }
                                else 
                                {
                                    mauvais++;
                                    if (mauvais < 3)
                                    {
                                        Console.WriteLine("Mauvais mot de passe, veuillez réessayer.");
                                        goto gotoPin;
                                      
                                        
                                    }
                                    else if (mauvais == 3)
                                    {
                                    
                                        Console.WriteLine("Le mot de passe à été saisi 3 fois. Le compte est en panne!");
                                        break;
                                    }
                                }
                            }
                            else 
                            {
                                Console.WriteLine("L'utlisateur est incorrect");
                            }
                            break;
                            
                        case "3":
                            Environment.Exit(0);
                            break;

                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("S.v.p essayer encore");
            }
        }



        // methode pour valider l'utlisateur et mot de passe.
        /* public bool ValiderUtilisateur(String username, String nip)
         {
             bool valide = false;
             for (ClasseClient client : listeClients)
             {
                 valide = client.getUsername().equalsIgnoreCase(username) && client.getNumeroNIP().equalsIgnoreCase(nip);
                 if (valide)
                     break;
             }
             return valide;
         }
        */

        ///Constructeur 
        ///public Guichet()
        ///{
        ///     /Faire un ArrayList
        ///     CompteCheque  client1 = new  CompteCheque();
        ///     CompteCheque  client2 = new  CompteCheque();
        ///     CompteCheque  client3 = new  CompteCheque();
        ///     CompteCheque  client4 = new  CompteCheque();
        ///     CompteCheque  client5 = new  CompteCheque();
        ///     
        ///     CompteAdmin admin = new CompteAdmin();
        ///     
        /// 
        ///     
        ///}


        // Fonction pour guichet 




        // - void Retirer()
        // {
        /// peux  retirer un maximum de 10 000$
        ///  if( mDepart == 0  || mDepart  < leretrait ) 
        ///  { 
        ///    /// Afficher la panne et que le solde est a  0$
        ///    ///il ne peut pas se connecter a sont compte 
        ///    ///appeller l'admin pour remplir le Atm
        ///  }
        ///  else{
        ///   mDepart--;
        ///   Console.Writeline(mDepart);
        ///   //Peut toujours retirer ;
        ///     retourner solde;
        ///  } 


        // }

        /// --  void Depot()
        /// {
        ///     ///quand les client vont deposer
        ///     si le client depose 100$ 
        ///     mDeposedansGuichet +=100;
        ///     mDeposedansGuichet++;
        ///     
        /// 
        ///   
        ///     
        ///    
        ///     
        ///    // Quand les clients depose  dans leurs compte Cheque ou Epargne
        ///    //ça ne s'additione pas et ont doit afficher le montant qui est dans le Banque 
        ///    
        /// 
        ///    if ( Panne )
        ///    {
        ///        Login entant qu'admin 
        ///        seulement l'admin peut deposer, alors le compte mDepart == encore a 10 000$;
        ///        Admin a = new Admin();
        ///        
        ///        a.Depot();
        /// 
        ///    }
        ///    
        ///     
        /// 
        ///
        /// }
        /// 

        // montant de depart 10 000$;
        // voir la liste des comptes

    }
}
