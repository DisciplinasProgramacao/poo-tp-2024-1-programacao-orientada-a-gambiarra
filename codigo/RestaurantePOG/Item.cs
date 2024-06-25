using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG {

    ///<summary>Classe representando um Item</summary>
    public class Item {

        private string nome;
        private double preco;

        ///<summary>Método responsável por instanciar um novo objeto da classe Item</summary>
        ///<param name="nome">Nome do item</param>
        ///<param name="preco">Preco atribuido ao item</param>
        ///<returns>Objeto do tipo Item</returns>
        public Item(string nome, double preco) {
            this.nome = nome;
            this.preco = preco;
        }

        ///<summary>Método responsável por retornar o preco do item referido.</summary>
        ///<returns>Retorna um valor 'double' indicando o preco do item.</returns>
        public double getPreco() { return preco; }   

        public override string ToString() { return $"{nome.PadRight(36)} | R${preco.ToString("F2").PadLeft(7)}"; }
    }
}