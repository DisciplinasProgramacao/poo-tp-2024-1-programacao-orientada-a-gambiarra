using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG {
    public class Pedido {

        private Item item;
        private int quantidade;
        private double valorUnitario;

        public Pedido(int quantidade, Item item)  {
            
            this.item = item;
            this.quantidade = quantidade;
            valorUnitario = item.getPreco();
        }
        
        /// <summary>Retorna o valor total do pedido.</summary>
        /// <returns>Total dos pedidos</returns>
        public double valorTotal() { return valorUnitario * quantidade; }
        
    }
}
