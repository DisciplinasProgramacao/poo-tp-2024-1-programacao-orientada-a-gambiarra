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
        private int quantidadePessoas;
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
        public Requisicao(Cliente cliente, int qtdPessoas) {
            id = ++ultimoId;
            this.cliente = cliente;
            quantidadePessoas = qtdPessoas;
            statusRequisicao = EStatusRequisicao.FILA_DE_ESPERA;
            mesa = null;
            comanda = null;
            hora_saida = null;
            hora_entrada = null;
        }

        /// <summary> Método para adicionar uma mesa à requisi��o</summary>
        /// <returns>A mesa adicionada à requisição</returns>
        public void iniciarRequisicao(Mesa mesa) {
            this.mesa = mesa;
            this.mesa.ocupar();
            hora_entrada = registrar_hora();
        }

        /// <summary> Metodo responsavel por finalizar uma requisicao. Quando uma Requisicao é finalizada, a mesma tem seu status alterado para 'FINALIZADO', tem sua hora de saída registrada e a mesa que estava alocada a tal requisição é liberada.</summary>
        ///<returns>Retorna uma string contendo as informacoes finais da Comanda.</returns>
        public string finalizarRequisicao() {
            mesa.desocupar();
            comanda.fecharComanda();
            hora_saida = registrar_hora();
            statusRequisicao = EStatusRequisicao.FINALIZADO;
            return exibirDetalhes();
        }

        ///<summary>Exibe as informacoes atuais da comanda</summary>
        ///<returns>Retorna uma string contendo as informacoes atuais da comanda.</returns>
        public string exibirDetalhes() {
            double valorTotal = comanda.getValorTotal();
            string retorno = $"ID Cliente: {id}\n"+
                             $"Titular Conta: {cliente.getNome()}\n"+
                             $"Quantidade Pessoas: {quantidadePessoas}\n"+
                             $"Valor Total Conta: R${valorTotal}\n"+
                             $"Valor Total p/Pessoa: R${valorTotal / (double)quantidadePessoas}\n"+
                             $"Horario de Entrada: {hora_entrada}\n"+
                             $"Horario de Saida: {hora_saida}\n";

            return retorno;
        }

        ///<summary>Método responsável por gerar a data e hora atual.</summary>
        ///<returns>Retorna um formato DD/MM/AAAA HH:MM:SS</returns>
        private DateTime registrar_hora() { return DateTime.Now; }

        ///<summary>Método responsável por verificar se a requisição referenciada já foi finalizada ou não..</summary>
        ///<returns>Retorna 'True' caso esteja finalizada e 'False' caso contrário.</returns>
        public bool estahFinalizada() { return statusRequisicao.Equals(EStatusRequisicao.FINALIZADO) ? true : false; }

        ///<summary>Calcula o valor para cada pessoa</summary>
        ///<returns>Valor dividido igualmente entre as pessoas da mesa</returns>
        public double calculaValorPorPessoa() { return comanda.getValorTotal() / (double)quantidadePessoas; }

        public bool estahEmAtendimento(){ return statusRequisicao.Equals(EStatusRequisicao.EM_ATENDIMENTO) ? true : false; }

        public bool pertenceAoCliente(Cliente cliente) { return this.cliente.Equals(cliente); }

        public int getQuantidadePessoas() {  return quantidadePessoas; }
    }
}




