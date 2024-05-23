using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG {
    internal class Pedido {
        private int quantidade;
        private Item item;
        private double valorUnitario;

        public Pedido(int quantidade, Item item)  {
            this.quantidade = quantidade;
            this.item = item;
            this.valorUnitario = item.getPreco();
        }

        public double valorTotal() {
            return valorUnitario * quantidade;
        }
        


    }
}
