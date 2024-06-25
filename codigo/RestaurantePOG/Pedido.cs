using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG {
    public class Pedido {
        #region Atributos
        private Item item;
        private int quantidade;
        private double valorUnitario;
        #endregion

        #region Construtor
        public Pedido(int quantidade, Item item)  {
            
            this.item = item;
            this.quantidade = quantidade;
            valorUnitario = item.getPreco();
        }
        #endregion
        
        #region Métodos
        /// <summary>Retorna o valor total do pedido.</summary>
        /// <returns>Total dos pedidos</returns>
        public double valorTotal() { return valorUnitario * quantidade; }
        #endregion
        
    }
}
