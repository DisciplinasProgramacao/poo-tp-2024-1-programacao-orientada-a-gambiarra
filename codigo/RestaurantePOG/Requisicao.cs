using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando uma requisi��o de atendimento no restaurante
    /// </summary>
    public class Requisicao
    {
        int id;
        Cliente cliente;
        DateTime entrada;
        DateTime saida;
        Mesa mesa;

        ///<summary>
        ///Construtor padr�o da requisi��o
        ///<summary>
        public Requisicao(int id, Cliente cliente, Mesa mesa)
        {
            this.id = int.Parse(mesa.id.ToString() + cliente.idCliente.ToString());
            this.cliente = cliente;
            this.entrada = new DateTime.Now();
            this.mesa = mesa;
        }

        /// <summary>
        /// M�todo para adicionar uma mesa � requisi��o
        /// </summary>
        /// <returns>A mesa adicionada � requisi��o</returns>
        public Mesa AddMesa(Mesa mesa)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// M�todo para finalizar a requisi��o
        /// </summary>
        public void FinalizarRequisicao()
        {
            this.saida = new DateTime.Now();
            this.mesa.ocupada = false;
        }

        /// <summary>
        /// M�todo que gera o relat�rio da requisi��o
        /// <summary>
        /// <returns>Retorna o relat�rio por string<returns>
        public string RelatorioRequisicao()
        {
            string relatorio = ("REQUISI��O  " + this.id.ToString() + "\n" + cliente.nome + "\nMesa " + mesa.Id.ToString() + "\n\nEntrada: " + entrada.ToString("dd/MM/yyyy HH:mm:ss") + "\nSaida: " + saida.ToString("dd/MM/yyyy HH:mm:ss"));
            return relatorio;
        }
    }
}