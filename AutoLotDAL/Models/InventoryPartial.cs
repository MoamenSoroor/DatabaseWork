using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Inventory
    {
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";

        public override string ToString()
        {
            //return base.ToString();
            return $"{this.PetName ?? "**No Name**"} is a {this.Color} " +
                $"{this.Make} with ID { this.Id}.";
        }
    }
}
