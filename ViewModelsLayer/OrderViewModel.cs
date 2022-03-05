using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelsLayer
{
    public class OrderViewModel
    {
        public Guid ID { get; set; }
        public Guid Buyer { get; set; }
        public List<FoodViewModel> foods { get; set; }
        public int FoodCount { get; set; }

        public double Price { get; set; }
        public Guid FoodID { get; set; }
    }
}
