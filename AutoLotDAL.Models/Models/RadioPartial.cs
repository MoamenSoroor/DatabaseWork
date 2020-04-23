using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AutoLotDAL.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Radio : EntityBase
    {

        public Radio()
        {

        }

        public override string ToString()
        {
            // return base.ToString();
            return $"Name: {this.Name}       Version:{this.Version}";
        }




    }
}
