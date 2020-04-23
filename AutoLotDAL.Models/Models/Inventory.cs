namespace AutoLotDAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using AutoLotDAL.Models.Base;

    [Table("Inventory")]
    public partial class Inventory : EntityBase
    {
        public Inventory()
        {
            Orders = new HashSet<Order>();
        }


        [StringLength(50), Column("Make")]
        public string Make { get; set; }

        [StringLength(50), Column("Color")]
        public string Color { get; set; }

        [StringLength(50), Column("PetName")]
        public string PetName { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
