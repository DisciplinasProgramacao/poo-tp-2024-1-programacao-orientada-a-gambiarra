using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantePOG {

    ///<summary>Classe representando uma requisicao de atendimento</summary>
    public class Requisicao {
    #region Atributos
        private static int ultimoId = 0;
        private int id;
        private int quantidadePessoas;
        private Cliente cliente;
        private bool finalizada;
        private Mesa? mesa;
        private Comanda comanda;
        private DateTime? hora_entrada;
        private DateTime? hora_saida;
    #endregion
    #region Construtor
        ///<summary>Método responsável por instanciar um novo objeto da classe Requisicao</summary>
        ///<param name="nome">Nome do cliente que está sendo atendido</param>
        ///<param name="qtdPessoas">Quantidade de Pessoas para a Reserva</param>
        ///<returns>Objeto do tipo Requisicao</returns>
        public Requisicao(Cliente cliente, int qtdPessoas) {
            quantidadePessoas = qtdPessoas;
            comanda = new Comanda();
            this.cliente = cliente;
            hora_entrada = null;
            finalizada = false;
            hora_saida = null;
            id = ++ultimoId;
            mesa = null;
        }
    #endregion
    #region Métodos
        /// <summary> Método para adicionar uma mesa à requisi��o</summary>
        /// <returns>A mesa adicionada à requisição</returns>
        public void iniciarRequisicao(Mesa? mesa) {
            if(mesa != null){
                this.mesa = mesa;
                this.mesa.ocupar();
            }
            hora_entrada = registrar_hora();
        }

        /// <summary> Metodo responsavel por finalizar uma requisicao. Quando uma Requisicao é finalizada, a mesma tem seu status alterado para 'FINALIZADO', tem sua hora de saída registrada e a mesa que estava alocada a tal requisição é liberada.</summary>
        ///<returns>Retorna uma string contendo as informacoes finais da Comanda.</returns>
        public string finalizarRequisicao() {
            string resultado = "Conta já está finalizada...";

            if(!finalizada){
                if(mesa != null){ 
                    mesa.desocupar(); 
                    mesa = null;
                }

                comanda.fecharComanda();
                hora_saida = registrar_hora();
                finalizada = true;
                resultado = exibirDetalhes();
            }
            
            return resultado; 
        }

        ///<summary>Exibe as informacoes atuais da comanda</summary>
        ///<returns>Retorna uma string contendo as informacoes atuais da comanda.</returns>
        public string exibirDetalhes() {
            return $"=========================================\n"+
                   $"====              CONTA              ====\n"+
                   $"=========================================\n"+
                   $"ID Cliente: {id}\n"+
                   $"Titular Conta: {cliente.getNome()}\n"+
                   $"Quantidade Pessoas: {quantidadePessoas}\n"+
                   $"Finalizada:{finalizada}\n"+
                   $"=========================================\n"+
                   $"Pedidos Realizados:\n"+
                   $"{comanda.listarPedidos()}"+
                   $"=========================================\n"+
                   $"TAXA Servico: R${comanda.calcularTaxaServico():f2}\n"+
                   $"Valor Total Conta: R${comanda.getValorTotal():f2}\n"+
                   $"Valor Total p/Pessoa: R${calculaValorPorPessoa():f2}\n"+
                   $"=========================================\n"+
                   $"Horario de Entrada: {hora_entrada?.ToString("dd/MM/yyyy HH:mm:ss")}\n" +
                   $"Horário de Saída: {hora_saida?.ToString("dd/MM/yyyy HH:mm:ss")}\n"+
                   $"=========================================";
        }

        ///<summary>Método responsável por gerar a data e hora atual.</summary>
        ///<returns>Retorna um formato DD/MM/AAAA HH:MM:SS</returns>
        private DateTime registrar_hora() { return DateTime.Now; }

        ///<summary>Método responsável por verificar se a requisição referenciada já foi finalizada ou não.</summary>
        ///<returns>Retorna 'True' caso esteja finalizada e 'False' caso contrário.</returns>
        public bool estahFinalizada() { return finalizada; }

        ///<summary>Calcula o valor para cada pessoa</summary>
        ///<returns>Valor dividido igualmente entre as pessoas da mesa</returns>
        public double calculaValorPorPessoa() { return comanda.getValorTotal() / quantidadePessoas; }
        
        /// <summary>Para saber a quantidade de pessoas na requisição</summary>
        /// <returns>Retorna a quantidade de pessoas</returns>
        public int getQuantidadePessoas() {  return quantidadePessoas; }


        /// <summary>Víncula uma Mesa à Requisição</summary>
        public void registrarMesa(Mesa mesa){ this.mesa = mesa; }
    
        /// <summary>Para saber o nome do cliente da requisição</summary>
        /// <returns>Cliente</returns>
        public Cliente getCliente(){ return cliente; }
        
         /// <summary>Para adicionar um pedido na comanda</summary>
        /// <returns>Retorna o item e a quantidade de itens para a comanda</returns>
        public bool addPedido(int quantidade, Item item){ return comanda.realizarPedido(new Pedido(quantidade, item)); }
        
        /// <summary>Para saber se a requisição está com o status de alocada em uma mesa</summary>
        /// <returns>True caso esteja alocada, false caso contrário</returns>
        public bool estahAlocadaEmMesa() { return (mesa != null) ? true : false; }
    #endregion
    }
}




