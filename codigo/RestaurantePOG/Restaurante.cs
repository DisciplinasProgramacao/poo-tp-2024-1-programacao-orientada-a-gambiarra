using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Reflection;

namespace RestaurantePOG {
    ///<summary>Classe representando o restaurante</summary>
    public class Restaurante : Estabelecimento{
        #region Atributos
        private FilaEspera fila_espera;
        #endregion

        #region Construtor
        ///<summary>Construtor do restaurante</summary>
        ///<param name="nome">Nome do restaurante</param>
        ///<returns>Objeto do tipo Restaurante</returns>
        public Restaurante(string nome) : base(nome) { fila_espera = new FilaEspera(); }
        #endregion

        #region Métodos
        /// <summary>Atende o cliente especificado. Inicia sua requisição e o acomoda em uma mesa.</summary>
        /// <param name="nomeCliente"></param>
        public override bool atenderCliente(Requisicao? requisicao) { return atenderProximo(); }


        /// <summary>Método responsável por exibir uma lista dos clientes que estão alocados em uma mesa (prontos para serem atendidos)</summary>
        /// <returns>lista de clientes em atendimento .ToString()</returns>
        public override string exibeListaAtendimento()  {
            StringBuilder listaAtendimento = new StringBuilder();

            foreach(Requisicao requisicao in lista_requisicao){
                if(!requisicao.estahFinalizada() && requisicao.estahAlocadaEmMesa()){
                    listaAtendimento.AppendLine(requisicao.getCliente().ToString());
                }
            }
            return listaAtendimento.ToString();            
        }
        

        /// <summary>Método responsável por cadastrar um cliente<summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="qtdPessoas">Quantidade de pessoas</param>
        public override void cadastrarCliente(string nome, int qtdPessoas){
            // Gerar uma requisicao com as informações especificadas
            Cliente cliente = new (nome);
            Requisicao requisicao = new Requisicao(cliente, qtdPessoas);

            lista_requisicao.Add(requisicao); // Inserir na lista de requisicoes
            lista_clientes.Add(cliente); // inserir na lista de clientes
            fila_espera.adicionarCliente(cliente); // inserir na lista de espera
        }


        /// <summary>Atende o próximo cliente da fila de espera, por ordem de chegada, porém é atendido apenas se tiver mesa disponível para a quantidade de pessoas</summary>
        private bool atenderProximo() {
            bool alocado = false;
            Requisicao? requisicao;

            // Procurar mesas livres
            List<Mesa> mesas_disponiveis = mesas.Where(m => !m.estahOcupada()).ToList();

            // Encontrar a primeira requisição que cabe em uma mesa disponível
            foreach (Cliente cliente in fila_espera) {
                requisicao = getRequisicaoPorNomeCliente(cliente.getNome());

                if (requisicao != null) {
                    foreach (Mesa mesa in mesas_disponiveis) {
                        if (requisicao.getQuantidadePessoas() <= mesa.getCapacidade()) {
                            requisicao.iniciarRequisicao(mesa); // Iniciar atendimento da requisicao
                            fila_espera.removerFila(cliente);
                            alocado = true;
                            break; // Interrompe o loop de mesas assim que a requisição é alocada
                        }
                    }
                }
                if (alocado) { break; } // Interrompe o loop de clientes assim que uma requisição é alocada
            }
            return alocado;
        }

        #endregion
    }
}
