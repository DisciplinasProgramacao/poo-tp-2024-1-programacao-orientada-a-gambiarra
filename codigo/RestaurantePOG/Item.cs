namespace RestaurantePOG {
    ///<summary>Classe representando um Item</summary>
    public class Item {

        private string nome;
        private double preco;
        #endregion

        #region Construtor
        ///<summary>Método responsável por instanciar um novo objeto da classe Item</summary>
        ///<param name="nome">Nome do item</param>
        ///<param name="preco">Preco atribuido ao item</param>
        ///<returns>Objeto do tipo Item</returns>
        public Item(string nome, double preco) {
            this.nome = nome;
            this.preco = preco;
        }
        #endregion

        #region Métodos
        ///<summary>Método responsável por retornar o preco do item referido.</summary>
        ///<returns>Retorna um valor 'double' indicando o preco do item.</returns>
        public double getPreco() { return preco; }

        /// <summary>Método responsável por retornar o nome do item referido.</summary>
        /// <returns>Retorna uma 'string' indicando o nome do item.</returns>
        public string getNome() { return nome; }  
        
        /// <summary>Transforma Item em uma String</summary>
        /// <returns>Uma string com as informações do Item de forma formatada</returns>
        public override string ToString() { return $"{nome.PadRight(36)} | R${preco.ToString("F2").PadLeft(7)}"; }
        #endregion
    }
}
