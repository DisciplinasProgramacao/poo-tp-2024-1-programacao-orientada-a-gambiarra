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

        public Comanda() {
            valorTotalItens = 0;
            comandaFechada = false;
            listaPedidos = new LinkedList<Pedido>();
        }


        ///<summary>Adiciona pedido no final da lista de pedidos da comanda.</summary>
        ///<param name="pedido"></param>
        public void realizarPedido(Pedido pedido) {
            listaPedidos.AddLast(pedido);
            valorTotalItens = calcularValorConta();
        }


        /// <summary>Altera a comanda para o status fechada.</summary>
        public void fecharComanda() { comandaFechada = true; }


        ///<summary> Retorna o valor Total da Comanda Atualmente </summary>
        ///<returns> Valor total da comanda. </returns>
        public double getValorTotal(){ return valorTotalItens; }


        ///<summary> Realiza o somátorio dos totais de pedidos dentro da comanda. </summary>
        ///<returns> Valor total da comanda. </returns>
        private double calcularValorConta() { return listaPedidos.Select(l => l.valorTotal()).Sum(); }
    }
}