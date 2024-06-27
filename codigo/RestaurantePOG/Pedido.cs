namespace RestaurantePOG {
    public class Pedido {
        #region Atributos
        private Item item;
        private int quantidade;
        private double valorUnitario;
        #endregion

        #region Construtor
        /// <summary>Construtor de Pedido</summary>
        /// <param name="quantidade">Quantidade de itens solicitados</param>
        /// <param name="item">O item solicitado</param>
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
        
        /// <summary>Transforma Pedido em uma string</summary>
        /// <returns>Uma string com as informações do Pedido de forma formatada</returns>
        public override string ToString() {
            return $"{item.getNome()} ***** x{quantidade}: R$ {valorTotal()}";
        }
        #endregion

    }
}
