using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG {

    ///<summary>Enumerador que define o status de uma Requisicao</summary>
    public enum EStatusRequisicao {
        FILA_DE_ESPERA = 1,
        EM_ATENDIMENTO = 2,
        FINALIZADO = 3
    }

    ///<summary> Classe representando uma requisicao de atendimento</summary>
    public class Requisicao {
        private static int ultimoId = 0;
        private int id;
        private int quantidadedePessoas;
        private Cliente cliente;
        private EStatusRequisicao statusRequisicao;
        private Mesa? mesa;
        private Comanda? comanda;
        private DateTime? hora_entrada;
        private DateTime? hora_saida;

        ///<summary>Método responsável por instanciar um novo objeto da classe Requisicao</summary>
        ///<param name="nome">Nome do cliente que está sendo atendido</param>
        ///<param name="qtdPessoas">Quantidade de Pessoas para a Reserva</param>
        ///<returns>Objeto do tipo Requisicao</returns>
        public Requisicao(string? nome, int qtdPessoas) {
            id = ++ultimoId;
            cliente = new Cliente(nome);
            quantidadedePessoas = qtdPessoas;
            statusRequisicao = EStatusRequisicao.FILA_DE_ESPERA;
            mesa = null;
            comanda = null;
            hora_saida = null;
            hora_entrada = null;
        }

        /// <summary> Metodo responsavel por finalizar uma requisicao. Quando uma Requisicao é finalizada, a mesma tem seu status alterado para 'FINALIZADO', tem sua hora de saída registrada e a mesa que estava alocada a tal requisição é liberada.</summary>
        public void finalizarRequisicao() {
            mesa.desocupar();
            statusRequisicao = EStatusRequisicao.FINALIZADO;
            hora_saida = registrar_hora();
            comanda.fechaComanda();
        }

        public bool pertenceAoCliente(Cliente cliente) {
            return this.cliente.Equals(cliente);
        }

        ///<summary>
        ///Calcula o valor para cada pessoa
        ///</summary>
        ///<returns>Valor dividido igualmente entre as pessoas da mesa</returns>
        public double calculaValorPorPessoa() {
            double valorPorPessoa = comanda.calcularValorFinalConta() / (double)quantidadedePessoas;
            return valorPorPessoa;
        }

        /// <summary>
        /// Método para adicionar uma mesa à requisi��o
        /// </summary>
        /// <returns>A mesa adicionada à requisição</returns>
        public void iniciarRequisicao(Mesa mesa) {
            this.mesa = mesa;
            this.mesa.ocupar();
            hora_entrada = registrar_hora();
        }

        ///<summary>Método responsável por gerar a data e hora atual.</summary>
        ///<returns>Retorna um formato DD/MM/AAAA HH:MM:SS</returns>
        private DateTime registrar_hora() { return DateTime.Now; }

        ///<summary>Método responsável por verificar se a requisição referenciada já foi finalizada ou não..</summary>
        ///<returns>Retorna 'True' caso esteja finalizada e 'False' caso contrário.</returns>
        public bool estahFinalizada() { return statusRequisicao.Equals(EStatusRequisicao.FINALIZADO) ? true : false; }

        internal int getQuantidadePessoas()
        {
            return quantidadedePessoas;
        }

        internal bool exibirDetalhes()
        {
            throw new NotImplementedException();
        }
    }
}




