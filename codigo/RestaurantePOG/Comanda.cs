using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

        public bool realizarPedido(Pedido pedido) {
            bool pedidoRealizado = false;

            if(!comandaFechada){
                listaPedidos.Add(pedido);
                calcularValorConta();
                pedidoRealizado = true;
            }
            return pedidoRealizado;
        }

        public double calcularValorConta() { return calcularTotalPedidos() + calcularTaxaServico(); }

        public double calcularTaxaServico() { return valorTaxaServico = calcularTotalPedidos() * TAXA_SERVICO; }

        public double calcularTotalPedidos() { return valorTotalItens = listaPedidos.Select(l => l.valorTotal()).Sum(); }

        public void fecharComanda() { comandaFechada = true; }

        public double getValorTotal(){ return valorTotalItens; }

        public string listarPedidos() {   
            StringBuilder sb = new StringBuilder();
            foreach (Pedido pedido in listaPedidos){ sb.AppendLine(pedido.ToString()); }
            return sb.ToString();
        }
    }  
}