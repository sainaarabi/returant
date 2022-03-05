using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class OrderViewModel
    {
        public Guid ID { get; set; }
        public List<FoodViewModel> FoodList { get; set; }
        public int FoodCounts { get; set; }
        public UserViewModel Customer { get; set; }
        public UserViewModel Seller { get; set; }
        public double OrderPrice { get; set; }

    }
}
