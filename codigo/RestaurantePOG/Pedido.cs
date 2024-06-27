namespace RestaurantePOG {
    public class Pedido {
        #region Atributos
        private Item item;
        private int quantidade;
        private double valorUnitario;
        #endregion

        #region Construtor
        /// <summary>Construtor de Pedido</summary>
        /// <param name="quantidade">Quantidade de itens solicitados do Item especificado</param>
        /// <param name="item">Objeto do tipo item a ser registrado no pedido</param>
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
            string qtd_vlr = $" x{quantidade}: R$ {valorTotal():f2} ";
            int valor = 41 - item.getNome().Length - qtd_vlr.Length;
            if (valor < 0){ valor = 0; }
            
            return  $"{item.getNome()} " + 
                    $"{new string('.', valor)}" + // Pontos para alinhar
                    $"{qtd_vlr}"; // Valor total formatado
        }

        #endregion

    }
}
