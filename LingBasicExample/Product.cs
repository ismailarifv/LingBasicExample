using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingBasicExample
{
    internal class Product:CommonProperty
    {
        public double Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
