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

        public string NbdeCompte { get => nbdeCompte; set => nbdeCompte = value; }



        ///Construtructeur 
        ///public Guichet()
        ///{
        ///     CompteClient  client1 = new  CompteClient();
        ///     CompteClient  client2 = new  CompteClient();
        ///     CompteClient  client3 = new  CompteClient();
        ///     CompteClient  client4 = new  CompteClient();
        ///     CompteClient  client5 = new  CompteClient();
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
