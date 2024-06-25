using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG {

    ///<summary> Classe representando uma requisicao de atendimento</summary>
    public class Requisicao {
        private static int ultimoId = 0;
        private int id;
        private int quantidadePessoas;
        private Cliente cliente;
        private bool finalizada;
        private Mesa? mesa;
        private Comanda comanda;
        private DateTime? hora_entrada;
        private DateTime? hora_saida;

        ///<summary>Método responsável por instanciar um novo objeto da classe Requisicao</summary>
        ///<param name="nome">Nome do cliente que está sendo atendido</param>
        ///<param name="qtdPessoas">Quantidade de Pessoas para a Reserva</param>
        ///<returns>Objeto do tipo Requisicao</returns>
        public Requisicao(Cliente cliente, int qtdPessoas) {
            quantidadePessoas = qtdPessoas;
            comanda = new Comanda();
            this.finalizada = false;
            this.cliente = cliente;
            hora_entrada = null;
            hora_saida = null;
            id = ++ultimoId;
            mesa = null;
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
            string resultado;
            try{
                mesa.desocupar();
                comanda.fecharComanda();
                hora_saida = registrar_hora();
                finalizada = true;
                resultado = exibirDetalhes();
            }catch(ArgumentNullException){ resultado = "Erro ao Finalizar Requisição"; }
            return resultado; 
        }

        ///<summary>Exibe as informacoes atuais da comanda</summary>
        ///<returns>Retorna uma string contendo as informacoes atuais da comanda.</returns>
        public string exibirDetalhes() {
            return $"ID Cliente: {id}\n"+
                   $"Titular Conta: {cliente.getNome()}\n"+
                   $"Quantidade Pessoas: {quantidadePessoas}\n"+
                   $"========================================="+
                   $"TAXA Servico: R${comanda.getValorTotal()}\n"+
                   $"Valor Total Conta: R${comanda.getValorTotal()}\n"+
                   $"Valor Total p/Pessoa: R${calculaValorPorPessoa()}\n"+
                   $"========================================="+
                   $"Horario de Entrada: {hora_entrada}\n"+  
                   $"Horario de Saida: {hora_saida}\n";
        }

        ///<summary>Método responsável por gerar a data e hora atual.</summary>
        ///<returns>Retorna um formato DD/MM/AAAA HH:MM:SS</returns>
        public DateTime registrar_hora() { return DateTime.Now; }

        ///<summary>Método responsável por verificar se a requisição referenciada já foi finalizada ou não..</summary>
        ///<returns>Retorna 'True' caso esteja finalizada e 'False' caso contrário.</returns>
        public bool estahFinalizada() { return finalizada; }

        ///<summary>Calcula o valor para cada pessoa</summary>
        ///<returns>Valor dividido igualmente entre as pessoas da mesa</returns>
        public double calculaValorPorPessoa() { return comanda.getValorTotal() / (double)quantidadePessoas; }

        public int getQuantidadePessoas() {  return quantidadePessoas; }

        public Cliente getCliente(){ return cliente; }

    }
}




