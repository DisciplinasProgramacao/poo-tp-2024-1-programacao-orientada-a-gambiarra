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
        private int id;
        private static int proximoId = 1;
        private int status;                 // 0 = Esperando Fila     1 = Em Atendimento    2 = finalizado
        private Cliente cliente;
        private int quantidadedePessoas;
        private Mesa? mesa;
        private Comanda comanda;
        private DateTime entrada;
        private DateTime saida;

        ///<summary>
        ///Construtor padr�o da requisi��o
        ///<summary>
        public Requisicao(Cliente cliente, Mesa mesa)
        {
            this.id = proximoId;
            this.proximoId++;
            this.status = 0;
            this.cliente = cliente;
            this quantidadedePessoas = this.cliente.quantidadePessoa;
            this.entrada = Horas();
            this.mesa = mesa;
        }

        /// <summary>
        /// M�todo para finalizar a requisi��o
        /// </summary>
        public void FinalizarRequisicao()
        {
            this.status = AlteraStatus();
            LiberaMesa();
            this.comanda.FecharComanda();
            this.saida = Horas();
        }

        ///<summary>
        ///Calcula o valor para cada pessoa
        ///</summary>
        ///<returns>Valor dividido igualmente entre as pessoas da mesa</returns>
        public double CalculaValorPorPessoa()
        {
            double valorPorPessoa = this.comanda.valor_total_itens / (double)this.quantidadedePessoas;
            return valorPorPessoa;
        }

        ///<summary>
        ///Define a requisi��o como atendida e cria a comanda
        ///</summary>
        ///<returns>Retorna true</returns>
        private int AlteraStatus()
        {
            bool stat = this.status++;
            this.comanda = new Comanda();
            return stat;
        }

        /// <summary>
        /// M�todo para adicionar uma mesa � requisi��o
        /// </summary>
        /// <returns>A mesa adicionada � requisi��o</returns>
        private Mesa AddMesa(Mesa mesa)
        {
            this.status = AlteraStatus();
            this.mesa = mesa;
        }

        ///<summary>
        ///Libera a mesa usada na requisicao
        ///</summary>
        private void LiberaMesa()
        {
            mesa.ocupada = false;
        }

        ///<summary>
        ///Gera a hora atual
        ///</summary>
        ///<returns>Horario atual</returns>
        private DateTime Horas()
        {
            DateTime horas = new DateTime.Now();
            return horas;
        }
    }
}