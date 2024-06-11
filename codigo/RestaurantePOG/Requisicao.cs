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
        private static int proximoId;
        private int id;
        private int status;                 // 0 = Esperando Fila     1 = Em Atendimento    2 = finalizado
        private Cliente cliente;
        private int quantidadedePessoas;
        private Mesa? mesa;
        private Comanda? comanda;
        private DateTime? hora_entrada;
        private DateTime? hora_saida;

        static Requisicao(){
            proximoId = 1;
        }

        ///<summary>
        ///Construtor padrao da requisicao
        ///<summary>
        public Requisicao(string? nome, int qtdPessoas)
        {
            this.id = proximoId++;
            this.status = 0;
            this.cliente = new Cliente(nome);
            this.quantidadedePessoas = qtdPessoas;
            this.mesa = null;
            this.comanda = null;
            this.hora_entrada = null;
            this.hora_saida = null;
        }

        /// <summary>
        /// M�todo para finalizar a requisi��o
        /// </summary>
        public void finalizarRequisicao()
        {
            this.status = alteraStatus();
            liberaMesa();
            this.comanda.fechaComanda();
            this.hora_saida = horas();
        }

        ///<summary>
        ///Calcula o valor para cada pessoa
        ///</summary>
        ///<returns>Valor dividido igualmente entre as pessoas da mesa</returns>
        public double calculaValorPorPessoa()
        {
            double valorPorPessoa = this.comanda.calcularValorFinalConta() / (double)this.quantidadedePessoas;
            return valorPorPessoa;
        }

        ///<summary>
        ///Define a requisição como atendida e cria a comanda
        ///</summary>
        ///<returns>Retorna true</returns>
        private int alteraStatus()
        {
            this.comanda = new Comanda();
            return this.status++; ;
        }

        /// <summary>
        /// Método para adicionar uma mesa à requisi��o
        /// </summary>
        /// <returns>A mesa adicionada à requisição</returns>
        private Mesa addMesa(Mesa mesa)
        {
            this.status = alteraStatus();
            this.mesa = mesa;
            return this.mesa;
        }

        ///<summary>
        ///Libera a mesa usada na requisicao
        ///</summary>
        private void liberaMesa()
        {
            mesa.desocupar();
        }

        ///<summary>
        ///Gera a hora atual
        ///</summary>
        ///<returns>Horario atual</returns>
        private DateTime horas()
        {
            DateTime horas = DateTime.Now;
            return horas;
        }
        public int getStatus()
        {
            return this.status;
        }

        internal int getQuantidadePessoas()
        {
            return this.quantidadedePessoas;
        }

        internal void iniciarRequisicao(Mesa mesa)
        {
            throw new NotImplementedException();
        }

        internal bool exibirDetalhes()
        {
            throw new NotImplementedException();
        }
    }
}