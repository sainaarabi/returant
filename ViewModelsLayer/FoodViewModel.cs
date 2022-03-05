using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelsLayer
{
    public class FoodViewModel
    {

        public Guid ID { get; set; }
        public string FoodIamge { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
    }
}
