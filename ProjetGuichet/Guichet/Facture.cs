using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
   
 

    class Facture
    {
        private decimal factureAmazon;
        private decimal factureBell;
        private decimal FactureVideotron;

        private string amazon;
        private string bell;
        private string videotron;


        public Facture(decimal factureBell ,decimal factureAmazon ,decimal FactureVideotron) 
        {
            this.FactureVideotron = FactureVideotron;
            this.factureBell = factureBell;
            this.FactureVideotron = factureAmazon;
        }
        public Facture(string bell ,decimal factureBell , string amazon  ,decimal factureAmazon , string videotron , decimal FactureVideotron) 
        {
            this.bell = bell;
            this.factureBell = factureBell;
            this.amazon = amazon;
            this.videotron = videotron;
            this.FactureVideotron = FactureVideotron;

        }
    }
}
