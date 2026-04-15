using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using System.Text;
using System.Transactions;
using System.Linq;

namespace Olivarez_Mary_Joy_ShoppingCartActivity
{ 
    class Product
    {
        //hii

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Remaining_Stock { get; set; }

    }
}