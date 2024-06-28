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
        public Restaurante(string nome) : base(nome) {     
        fila_espera = new FilaEspera();

        cardapio = new Cardapio().adicionarItem("Moqueca de Palmito", 32.0)
                                 .adicionarItem("Falafel Assado", 20.0)
                                 .adicionarItem("Salada Primavera com Macarrão Konjac", 25.0)
                                 .adicionarItem("Escondidinho de Inhame", 18.0)
                                 .adicionarItem("Strogonoff de Cogumelos", 35.0)
                                 .adicionarItem("Caçarola de legumes", 22.0)
                                 //==========================================================//
                                 .adicionarItem("Água", 3.0)
                                 .adicionarItem("Copo de suco", 7.0)
                                 .adicionarItem("Refrigerante orgânico", 7.0)
                                 .adicionarItem("Cerveja vegana", 9.0)
                                 .adicionarItem("Taça de vinho vegano", 18.0);

        mesas = new List<Mesa> { new Mesa(4), new Mesa(4), new Mesa(4), new Mesa(4),
                                    new Mesa(6), new Mesa(6), new Mesa(6), new Mesa(6),
                                    new Mesa(8), new Mesa(8) };

        tipo_estabelecimento = 2;
        }
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


        /// <summary> Exibe o Menu Principal</summary>
        public override string exibeMenuEstabelecimento(){
            return  "=========================================\n"+
                    "====          MENU PRINCIPAL         ====\n"+
                    "=========================================\n"+
                    "1 - Cadastrar Cliente\n"+
                    "2 - Realizar um Pedido de um Cliente\n"+
                    "3 - Mostrar Lista de Clientes\n"+
                    "4 - Mostrar Cardápio\n"+
                    "5 - Adicionar Item no Cardápio\n"+
                    "6 - Adicionar uma nova Mesa\n"+
                    "7 - Acomodar um Cliente a uma Mesa\n"+
                    "8 - Encerrar Programa.\n"+
                    "=========================================\n";
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

        // <summary>Método responsável por criar uma nova mesa</summary>
        /// <param name="qtdPessoas">A quantidade de pessoas que caberá na mesa</param>
        public void adicionarMesa(int qtdPessoas){ mesas.Add(new Mesa(qtdPessoas)); }

        public override bool validarAtendimento(string nome) {
            Requisicao? requisicao = getRequisicaoPorNomeCliente(nome);

            if(requisicao != null && requisicao.estahAlocadaEmMesa()) {
                return true;
            }
            return false;
        }

        #endregion
    }
}
