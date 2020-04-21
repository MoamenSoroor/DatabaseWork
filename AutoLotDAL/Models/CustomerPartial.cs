using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Customer
    {
        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        public override string ToString()
        {
            //return base.ToString();

            return $"Customer[ Id: {this.CustID}, FullName: {this.FullName} ]";
        }

    }
}
