

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.TModels
{
    public class OrderEntity : Base.ExtendedEntity
    {
        [ForeignKey("Buyer")]
        public Guid Buyer { get; set; }
        public UserEntity Buyerlist { get; set; }
        public int FoodCount { get; set; }
        public double Price { get; set; }

        [ForeignKey("FoodID")]
        public Guid FoodID { get; set; }
        public FoodEntity Food { get; set; }
    }
}
