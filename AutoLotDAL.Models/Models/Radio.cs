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
    [Table("Radio")]
    public partial class Radio : EntityBase
    {

        [Column("Name"), StringLength(30)]
        public string Name { get; set; }


        [Column("Version"), StringLength(30)]
        public string Version { get; set; }




    }
}
