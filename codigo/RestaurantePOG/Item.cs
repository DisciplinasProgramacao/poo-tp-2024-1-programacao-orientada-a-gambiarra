using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG {
    internal class Item {
        private string nome;
        private double preco;
       

        public Item(string nome, double preco) {
            this.nome = nome;
            this.preco = preco;
          
        }

        public double getPreco() { return preco; }   
    }

}
