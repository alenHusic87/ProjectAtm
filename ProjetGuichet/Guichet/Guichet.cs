using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
 /*   Démarrage et comportement du système :
Lorsque le guichet démarre, il doit avoir 10 000$ comme montant
disponible.Ainsi, lorsqu’un usager retire 1 000$, le montant
disponible du GUICHET sera maintenant de 9 000$. Il ne doit pas
être possible de retirer de l’argent du guichet lorsque le montant
du retrait est plus élevé que le montant disponible.Les dépôts des
usagers n’affectent pas le montant disponible dans le guichet.En
d’autres mots, si aucun retrait n’a été effectué et qu’un usager
dépose 1 000$ alors le système n’aura pas 11 000$ comme
disponible.
Lorsque le guichet ne possède plus assez de fonds, il doit être en
mode « panne ». Un système de gestion interne doit permettre de
gérer cet état.Ainsi, seul un administrateur peut être en mesure de
remettre le guichet en fonction et aucun usager ne pourra retirer
de l’argent.
Un administrateur peut remettre de l’argent à l’intérieur du
Guichet.Pour se faire, il se connecte comme administrateur et
effectue un dépôt.
Lorsque le système démarre, il doit y avoir une liste de comptes en
mémoire (minimum 5 comptes clients) et un compte
administrateur.Ainsi, au démarrage de l’application, un utilisateur
de la liste peut accéder à son compte*/


    public class Guichet
    {
        // montat depart 10 000$;
        // voire le list de compte
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
               Console.WriteLine($"Numero  de comptesCheques  : {a.GetNumeroCompte}  {a.GetMotPass}  {a.GetBalance} ");
            }
            foreach (CompteEpargne a in comptesEpargne)
            {

                Console.WriteLine($"Numero  de comptesEpargne  : {a.GetNumeroCompte} {a.GetBalance} ");
            }

            CompteCheque compteCourant = new CompteCheque("Djavo", "1234", 100.50, false); 
            compteCourant.Retrait(100);
            compteCourant.Depot(10);
            Console.WriteLine(compteCourant.AfficheSold());
            Console.WriteLine(compteCourant.GetMotPass);

            Console.Write("Entrez le montant du transfert : ");
            double montantTransfert = Convert.ToDouble(Console.ReadLine());
            compteCourant.Virment(montantTransfert);


            Console.Write("Entrez le montant pour payer : ");
            double montanttoPay = Convert.ToDouble(Console.ReadLine());
            compteCourant.PayBill(montanttoPay);

            Console.WriteLine(compteCourant.AfficheSold());

        }

        //Initialise le 5 user 
        //et devrais apple la methode dans Constructeur du guichet
        public void Initialization()
        {
            mDepart = 0;
            comptesCheques.Add(new CompteCheque("comptesCheques", "1234", 100.50, false));
            comptesEpargne.Add(new CompteEpargne("CompteEpargne", "1234", 100.50, false));
        }

        public void Login()
        {
            Console.WriteLine("-----BieneVenu-----\n\n" + "Login:\n" +
                "1----Admin\n" +
                "2----Client\n\n" +
                "Entre  1 or 2:");
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
                            Console.WriteLine("-----Admin Login-----\n" +
                                " Enter ton  numerodecompte & ton mot de pass");

                            //Declare  a Admin object
                            Admin admin = new Admin();
                            bool isSignedin = false;
                            while (!isSignedin)
                            {
                                // Lire le userName du admin
                                Console.Write("Username: ");
                                admin.GetAdminuser = Console.ReadLine();
                                
                            }

                                break;
                        // Case 2 pour Client Login
                        case "2":
                            CompteCheque clinet = new CompteCheque("123456", "1234", 100.50, false);
                            string numerocompte = clinet.GetNumeroCompte;
                            string motpass = clinet.GetMotPass;
                            //bool isSignedin = false;
                            Console.WriteLine("-----Client Login-----\n" +
                                "Enter ton  numerodecompte & ton mot de pass");
                        
                                // Lire le userName du client 
                                Console.Write("Username: ");
                                clinet.GetNumeroCompte = Console.ReadLine();

                            if (clinet.GetNumeroCompte.Equals(numerocompte) )
                            {
                                    Console.WriteLine("Client inscrit il est egale a celui rentre " );
                                    
                                //Affiche le le reste 
                                int wrong = 0;
                                Console.Write("mote de pass: ");
                                clinet.GetMotPass = Console.ReadLine();
                                if (clinet.GetMotPass.Equals(motpass)) 
                                {
                                    Console.WriteLine("le Mote de pas du client  inscrit il est egale a celui rentre ");
                                }
                                else 
                                {
                                    wrong++;
                                    if (wrong < 3)
                                    {
                                        Console.WriteLine("mauvais code essye encore .");
                                        Console.Write("mote de pass: ");
                                        clinet.GetMotPass = Console.ReadLine();
                                        
                                    }
                                    else if (wrong == 3)
                                    {
                                    
                                        Console.WriteLine("le mote de pass est entre  3 fois . compte  il est ferrme!");
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
                Console.WriteLine("Please essaye  encore");
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

        ///Construtructeur 
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


        // FUnction pour guichet 




        // - void Retire()
        // {
        /// peux  retire  maximum 10 000$
        ///  if( mDepart == 0  || mDepart  < leretrait ) 
        ///  { 
        ///    /// Affiche la panne  que le sole est a  0$
        ///    ///que ile ne peut pas se compte a sont  compte 
        ///    ///appler Admin pour remplire le Atm
        ///  }
        ///  else{
        ///   mDepart--;
        ///   Console.Writeline(mDepart);
        ///   //Peut toujours retire ;
        ///     retrun solde;
        ///  } 


        // }

        /// --  void Depot()
        /// {
        ///     ///quand les cliente vont depose  faque 
        ///     si clinte un depose 100$ 
        ///     mDeposedansGuichet +=100;
        ///     mDeposedansGuichet++;
        ///     
        /// 
        ///   
        ///     
        ///    
        ///     
        ///    // Quand le Client   depose  dasn leurs compte Cheque ou Compte Epargne
        ///    //sa ne se addtione pas  et peut affiche le motant qui est dans le Banque 
        ///    
        /// 
        ///    if ( Panne )
        ///    {
        ///        Login tant Admin 
        ///        just Admin peut depose  alors le compte mDepart == encore a 10 000$;
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
        // voire le list de compte

    }
}
