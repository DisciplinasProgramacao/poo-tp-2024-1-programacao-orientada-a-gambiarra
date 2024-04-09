using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando uma requisição de atendimento no restaurante
    /// </summary>
    public class Requisicao
    {
        int id;
        Cliente cliente;
        DateTime entrada;
        DateTime saida;
        Mesa mesa;

        ///<summary>
        ///Construtor padrão da requisição
        ///<summary>
        public Requisicao(int id, Cliente cliente, Mesa mesa)
        {
            this.id = int.Parse(mesa.id.ToString() + cliente.idCliente.ToString());
            this.cliente = cliente;
            this.entrada = new DateTime.Now();
            this.mesa = mesa;
        }

        /// <summary>
        /// Método para adicionar uma mesa à requisição
        /// </summary>
        /// <returns>A mesa adicionada à requisição</returns>
        public Mesa AddMesa(Mesa mesa)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para finalizar a requisição
        /// </summary>
        public void FinalizarRequisicao()
        {
            this.saida = new DateTime.Now();
            this.mesa.ocupada = false;
        }

        /// <summary>
        /// Método que gera o relatório da requisição
        /// <summary>
        /// <returns>Retorna o relatório por string<returns>
        public string RelatorioRequisicao()
        {
            string relatorio = ("REQUISIÇÃO  " + this.id.ToString() + "\n" + cliente.nome + "\nMesa " + mesa.Id.ToString() + "\n\nEntrada: " + entrada.ToString("dd/MM/yyyy HH:mm:ss") + "\nSaida: " + saida.ToString("dd/MM/yyyy HH:mm:ss"));
            return relatorio;
        }
    }
}