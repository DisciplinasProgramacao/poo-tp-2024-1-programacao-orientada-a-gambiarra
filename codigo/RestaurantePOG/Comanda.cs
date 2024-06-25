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
        #region Atributos
        protected static double TAXA_SERVICO = 0.1;
        private List<Pedido> listaPedidos;
        private double valorTotalItens;
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
        ///<summary>Adiciona pedido no final da lista de pedidos da comanda.</summary>
        ///<param name="pedido"></param>
        public bool realizarPedido(Pedido pedido) {
            bool pedidoRealizado = false;

            if(!comandaFechada){
                listaPedidos.Add(pedido);
                valorTotalItens = calcularValorConta();
                pedidoRealizado = true;
            }
            return pedidoRealizado;
        }

        ///<summary> Realiza o somátorio dos totais de pedidos dentro da comanda juntamenta à taxa de servico. </summary>
        ///<returns> Valor total da comanda. </returns>
        private double calcularValorConta() { 
            double total = listaPedidos.Select(l => l.valorTotal()).Sum();
            total += total * TAXA_SERVICO;
            return  total;
        }


        /// <summary>Altera a comanda para o status fechada.</summary>
        public void fecharComanda() { comandaFechada = true; }


        ///<summary> Retorna o valor Total da Comanda Atualmente </summary>
        ///<returns> Valor total da comanda. </returns>
        public double getValorTotal(){ return valorTotalItens; }
        #endregion

    }  
}
