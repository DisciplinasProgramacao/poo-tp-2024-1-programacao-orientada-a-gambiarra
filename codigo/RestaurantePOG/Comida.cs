﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG {
    internal class Comida : Pedido {
        public Comida(int quantidade, Item item) : base(quantidade, item) {

        }
    }
}
