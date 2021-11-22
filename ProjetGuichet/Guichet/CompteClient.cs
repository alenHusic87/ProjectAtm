using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    abstract class CompteClient
    {
        protected string numerocompte;
        protected string nom;
        protected string prenom;

        protected string  useerName; //de type 8 caractere 
        protected string motpass;   // minimum 4 caractere nimporte que type de caractere

        
        
        public CompteClient()
        {
           
        }
        public void ChnageMotdePass() 
        {
            string  a = "pass1";


        }


        //metohde normal:
            //methode change mote pass
            //methode fereme  session

        //methode abstraite;
            //depot
            //retire
            //affiche sold
            //virment
            //payer bill

    }
}
