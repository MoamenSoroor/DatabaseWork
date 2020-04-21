namespace AutoLotDAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Car
    {
        public Car()
        {
            Orders = new HashSet<Order>();
        }

        [Key, Column("CarId")]
        public int CarId { get; set; }

        [StringLength(50), Column("Make")]
        public string Make { get; set; }

        [StringLength(50), Column("Color")]
        public string Color { get; set; }

        [StringLength(50), Column("PetName")]
        public string CarNickName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
