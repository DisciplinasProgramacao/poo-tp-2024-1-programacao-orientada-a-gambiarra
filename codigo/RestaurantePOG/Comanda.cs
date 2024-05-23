using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG
{
    internal class Comanda
    {
        protected static float TAXA_SERVICO = 0.1f;
        private LinkedList<Pedido> listaPedidos;
        private double valorTotalItens;
        private bool comandaFechada;

        public Comanda()
        {
            this.listaPedidos = new LinkedList<Pedido>();
            this.comandaFechada = false;
            this.valorTotalItens = 0;
        }

        /// <summary>
        /// Adiciona pedido no final da lista de pedidos da comanda.
        /// </summary>
        /// <param name="pedido"></param>
        public void realizarPedido(Pedido pedido)
        {
            listaPedidos.AddLast(pedido);
        }
        /// <summary>
        /// Altera a comanda para o status fechada.
        /// </summary>
        /// <returns></returns>
        public bool fechaComanda()
        {
            return comandaFechada = true;
        }
        /// <summary>
        /// Realiza o somátorio dos totais de pedidos dentro da comanda.
        /// </summary>
        /// <returns>Valor total da comanda.</returns>
        public double calcularValorFinalConta()
        {
            foreach (Pedido pedido in listaPedidos)
            {
                valorTotalItens += pedido.valorTotal();
            }
            return valorTotalItens;
        }


    }
}