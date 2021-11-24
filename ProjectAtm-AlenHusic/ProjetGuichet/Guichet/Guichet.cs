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
        private List<CompteEpargne> comptesEpargne = new List<CompteEpargne>();



        public Guichet()
        {
            CompteCheque clinet = new CompteCheque("123456", "1234", 100.50, false);

            comptesCheques.Add(new CompteCheque("12345", "1234" ,100.50 ,false));
            comptesCheques.Add(clinet);
            comptesEpargne.Add(new CompteEpargne("12345678", "1234",109.50 ,false));

            Login();

            foreach (CompteCheque a in comptesCheques)
            {
               Console.WriteLine($"Numero  de compte Cheques  : {a.GetNumeroCompte}  {a.GetMotPasse}  {a.GetBalance} ");
            }
            foreach (CompteEpargne a in comptesEpargne)
            {

                Console.WriteLine($"Numero de compte Epargne  : {a.GetNumeroCompte} {a.GetBalance} ");
            }

            CompteCheque compteCourant = new CompteCheque("Djavo", "1234", 100.50, false);
            Console.Write("Entrez le montant du retrait : ");
            double montantretrait = Convert.ToDouble(Console.ReadLine());
            

            compteCourant.Retrait(montantretrait);

            
            Console.WriteLine(compteCourant.AfficheSolde());
            Console.WriteLine(compteCourant.GetMotPasse);

            Console.Write("Entrez le montant du depot : ");
            double montantDepot = Convert.ToDouble(Console.ReadLine());
            compteCourant.Virement(montantDepot);


            Console.Write("Entrez le montant à payer : ");
            double montanttoPay = Convert.ToDouble(Console.ReadLine());
            compteCourant.PayBill(montanttoPay);

            Console.WriteLine(compteCourant.AfficheSolde());

        }

        //Initialiser le 5 user 
        //et devrais appeller la methode dans Constructeur du guichet
        public void Initialization()
        {
            mDepart = 0;
            comptesCheques.Add(new CompteCheque("comptesCheques", "1234", 100.50, false));
            comptesEpargne.Add(new CompteEpargne("CompteEpargne", "1234", 100.50, false));
        }

        public void Login()
        {
            Console.WriteLine("-----Bienvenue-----\n\n" + "Login:\n" +
                "1----Admin\n" +
                "2----Client\n\n" +
                "Entrer  1 ou 2:");
            try
            {
                string user = Console.ReadLine();
                // Checking if input is correct
                if (user == "1" || user == "2")
                {

                    switch (user)
                    {
                        // Case 1 pour Admin Login
                        case "1":
                            Console.WriteLine("-----Accès client-----\n" +
                                " Enter numero de compte & mot de passe");

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
                            CompteCheque clinet = new CompteCheque("123456", "1234", 100.50, false);
                            string numerocompte = clinet.GetNumeroCompte;
                            string motpass = clinet.GetMotPasse;
                            //bool isSignedin = false;
                            Console.WriteLine("-----Accès client-----\n" +
                                "Entrer numero de compte & mot de passe");
                        
                                // Lire le userName du client 
                                Console.Write("Utilisateur: ");
                                clinet.GetNumeroCompte = Console.ReadLine();

                            if (clinet.GetNumeroCompte.Equals(numerocompte) )
                            {
                                    Console.WriteLine("le numero de compte est valide ");
                                    
                                //Afficher le le reste 
                                int mauvais = 0;
                                gotoPin:
                                Console.Write("mot de passe: ");
                                clinet.GetMotPasse = Console.ReadLine();
                                if (clinet.GetMotPasse.Equals(motpass)) 
                                {
                                    Console.WriteLine("le mot de passe du client est valide ");
                                }
                                else 
                                {
                                    mauvais++;
                                    if (mauvais < 3)
                                    {
                                        Console.WriteLine("mauvais code essayer encore.");
                                        goto gotoPin;
                                      
                                        
                                    }
                                    else if (mauvais == 3)
                                    {
                                    
                                        Console.WriteLine("le mot de passe à été entré 3 fois . Le compte est gelé!");
                                        break;
                                    }
                                }
                            }
                            else 
                            {
                                Console.WriteLine("le user est incorect");
                            }
                            break;


                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Svp essayer encore");
            }
        }



        // methode pour valider un username et un nip
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




        // - void Retire()
        // {
        /// peux  retire  maximum 10 000$
        ///  if( mDepart == 0  || mDepart  < leretrait ) 
        ///  { 
        ///    /// Affiche la panne  que le solde est a  0$
        ///    ///qu'il ne peut pas se connecte a sont  compte 
        ///    ///appeler l'admin pour remplir le Atm
        ///  }
        ///  else{
        ///   mDepart--;
        ///   Console.Writeline(mDepart);
        ///   //Peut toujours retire ;
        ///     retourner solde;
        ///  } 


        // }

        /// --  void Depot()
        /// {
        ///     ///quand les client vont deposer
        ///     si client depose 100$ 
        ///     mDeposedansGuichet +=100;
        ///     mDeposedansGuichet++;
        ///     
        /// 
        ///   
        ///     
        ///    
        ///     
        ///    // Quand les clients  depose  dans leurs compte Cheque ou Epargne
        ///    //sa ne se addtione pas  et peut affiche le motant qui est dans le Banque 
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

        // montat depart 10 000$;
        // voire la liste de compte

    }
}
