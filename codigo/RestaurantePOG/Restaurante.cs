using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Reflection;

namespace RestaurantePOG {
    ///<summary>Classe representando o restaurante </summary>
    public class Restaurante : Estabelecimento{
        #region Atributos
        private FilaEspera fila_espera;
        #endregion

        #region Construtor
        ///<summary>Método responsável por instanciar um novo objeto da classe Restaurante</summary>
        ///<param name="nome"></param>
        ///<returns>Objeto do tipo Restaurante</returns>
        public Restaurante(string nome) : base(nome) {
            fila_espera = new FilaEspera();
        }
        #endregion

        #region Métodos

        public override void atenderCliente(Requisicao requisicao) {
            // Procurar mesas livres
            List<Mesa> mesas_disponiveis = mesas.Where(m => !m.estahOcupada()).ToList();

            // Encontrar a primeira requisição que cabe em uma mesa disponível
            foreach (Mesa mesa in mesas_disponiveis) {
                if (requisicao.getQuantidadePessoas() <= mesa.getCapacidade()) {
                    requisicao.iniciarRequisicao(mesa); // Iniciar atendimento da requisicao
                    fila_espera.removerFila(requisicao.getCliente());
                    break; // Interrompe o loop de mesas assim que a requisição é alocada
                }
            }    
        }

        public void atenderProximo() {
            bool alocado = false;
            Requisicao? requisicao;

            // Procurar mesas livres
            List<Mesa> mesas_disponiveis = mesas.Where(m => !m.estahOcupada()).ToList();

            // Encontrar a primeira requisição que cabe em uma mesa disponível
            foreach (Cliente cliente in fila_espera) {
                requisicao = getRequisicaoPorCliente(cliente);

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
        }

        public override string exibeListaAtendimento()  {
            StringBuilder listaAtendimento = new StringBuilder();

            foreach(Requisicao requisicao in lista_requisicao){
                if(!requisicao.estahFinalizada() && requisicao.estahAlocadaEmMesa()){
                    listaAtendimento.AppendLine(requisicao.getCliente().ToString());
                }
            }

            return listaAtendimento.ToString();            
        }

        public override void cadastrarCliente(string nome, int qtdPessoas){
            // Gerar uma requisicao com as informações especificadas
            Cliente cliente = new (nome);
            Requisicao requisicao = new Requisicao(cliente, qtdPessoas);

            lista_requisicao.Add(requisicao); // Inserir na lista de requisicoes
            lista_clientes.Add(cliente); // inserir na lista de clientes
            fila_espera.adicionarCliente(cliente); // inserir na lista de espera
        }

        #endregion
    }
}
