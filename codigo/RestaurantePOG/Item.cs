using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG {
    internal class Item {
        protected string nome;
        protected float preco;

        public Item(string nome, float preco) {
            this.nome = nome;
            this.preco = preco;
        }

        public float getPreco() { return preco; }   
    }

}
