using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
   public class Facture
    {
        #region Constructors
        public Facture()
        {
        }

        public Facture(int itemNumber, string description, decimal unitPrice)
        {
            this.ItemNumber = itemNumber;
            this.Description = description;
            this.UnitPrice = unitPrice;
           
        }
        #endregion

        #region Properties
        public int ItemNumber
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal UnitPrice
        {
            get;
            set;
        }

        #endregion

        #region Methods


        public override string ToString()
        {
            return string.Format( this.Description +this.UnitPrice);
        }
        #endregion
    }
}

