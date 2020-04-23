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
            return $"ID: { this.Id,-5} Name: {this.PetName ?? "*NULL*",-20} Color: {this.Color,-20} " +
                $"Make: {this.Make,-30}";
        }
    }
}
