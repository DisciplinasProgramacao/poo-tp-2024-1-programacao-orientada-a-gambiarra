using System.Text;

namespace RestaurantePOG
{
    internal class Comanda
    {
        #region Atributos
        private static double TAXA_SERVICO = 0.1;
        private List<Pedido> listaPedidos;
        private double valorTotalItens;
        private double valorTaxaServico;
        private bool comandaFechada;
        #endregion
            
        #region Construtor
        public Comanda() {
            valorTotalItens = 0.00;
            comandaFechada = false;
            listaPedidos = new List<Pedido>();
        }
        #endregion

        #region Métodos
        /// <summary>Método responsável por realizar o pedido da comanda</summary>
        /// <param name="pedido">O pedido específico</param>
        /// <returns>Se o pedido foi realizado ou não</returns>
        public bool realizarPedido(Pedido pedido) {
            bool pedidoRealizado = false;

            if(!comandaFechada){
                listaPedidos.Add(pedido);
                calcularValorConta();
                pedidoRealizado = true;
            }
            return pedidoRealizado;
        }


        /// <summary>Método responsável por calcular o valor da conta, considerando a taxa de serviço</summary>
        /// <returns>Valor da conta + a taxa de serviço</returns>
        public double calcularValorConta() { return calcularTotalPedidos() + calcularTaxaServico(); }


        /// <summary>Método responsável por calcular a taxa de serviço</summary>
        /// <returns>o valor da taxa de serviço</returns>
        public double calcularTaxaServico() { return valorTaxaServico = calcularTotalPedidos() * TAXA_SERVICO; }


        /// <summary>Método responsável por calcular o valor total dos pedidos</summary>
        /// <returns>Valor total dos pedidos</returns>
        public double calcularTotalPedidos() { return valorTotalItens = listaPedidos.Select(l => l.valorTotal()).Sum(); }


        /// <summary>Método responsável por fechar a comanda</summary>
        public void fecharComanda() { comandaFechada = true; }


        /// <summary>Método responsável por retornar o valor total da comanda</summary>
        /// <returns>Valor total dos itens da comanda</returns>
        public double getValorTotal(){ return calcularValorConta(); }
        

        /// <summary>Mostra os pedidos em lista</summary>
        /// <returns>Retorna uma string contendo todos os pedidos</returns>
        public string listarPedidos() {   
            StringBuilder sb = new StringBuilder();
            foreach (Pedido pedido in listaPedidos){ sb.AppendLine(pedido.ToString()); }
            return sb.ToString();
        }
        #endregion
    }  
}
