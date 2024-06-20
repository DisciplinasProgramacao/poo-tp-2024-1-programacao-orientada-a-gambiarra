using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Reflection;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o restaurante
    /// </summary>
    public class Restaurante
    {
        #region atributos
        private static int MAX_MESA = 10;
        private String nome;
        private List<Requisicao> lista_requisicao; //todas
        private List<Mesa> mesas;
        private List<Requisicao> filaEspera;
        private Cardapio cardapio;
        #endregion

        #region Construtores
        public Restaurante(String nome)
        {
            this.nome = nome;
            this.lista_requisicao = new List<Requisicao>();
            this.mesas = new List<Mesa>
            {
                new Mesa(1, 4), new Mesa(2, 4), new Mesa(3, 4), new Mesa(4, 4),
                new Mesa(5, 6), new Mesa(6, 6), new Mesa(7, 6), new Mesa(8, 6),
                new Mesa(9, 8), new Mesa(10, 8)
            };
            this.filaEspera = new List<Requisicao>();
            this.cardapio = new Cardapio();
        }
        #endregion

        #region métodos
        
        /// <summary>
        /// Retorna quais mesas estão em atendimento
        /// </summary>
        /// <returns>Mesa</returns>
        public List<Requisicao> consultarEmAtendimentos()
        {
            return lista_requisicao.Where(requisicao => !requisicao.estahFinalizada()).ToList();
        }
        /// <summary>
        /// Função de retornar se a requisição pode ser atendida pela quantidade de pessoas.
        /// </summary>
        /// <param name="requisicao"></param>
        /// <returns></returns>
        public bool estahAptoAtendimento(Requisicao requisicao) //verifica se há mesa disponível para atender a requisição selecionada
        {
            foreach (Mesa mesa in getMesasDisponiveis())
            {
                if (requisicao.getQuantidadePessoas() < mesa.getCapacidade())
                {
                    return true;
                }  
            }
            return false;
        }

        public void atenderCliente(Requisicao requisicao) //Determina a mesa como ocupada pela requisição e incia a requisição
        {
            Mesa mesa;
            foreach (Mesa mesaDisp in getMesasDisponiveis())
            {
                if (requisicao.getQuantidadePessoas() < mesaDisp.getCapacidade())
                {
                    mesa = mesaDisp;
                    requisicao.iniciarRequisicao(mesa);
                    break;
                }
            }    
        }

        private List<Mesa> getMesasDisponiveis()
        {
            List<Mesa> getMesasDisponiveis = new List<Mesa>();
            foreach (Mesa mesa in mesas)
            {
                if (!mesa.estahOcupada())
                {
                    getMesasDisponiveis.Add(mesa);
                }
            }
            return getMesasDisponiveis;
        }

        public void adicionaFilaEspera(Requisicao requisicao) //Adiciona uma requisição para a fila de espera
        {
            filaEspera.Add(requisicao);
        }

        public void adicionarRequisicao(Requisicao requisicao) //Adiciona uma nova requisição à lista de requisições do restaurante
        {
            lista_requisicao.Add(requisicao);
        }

        // public Requisicao getRequisicao(int index){
        //     if(index<0 || index >= lista_requisicao.Count);
        //         //exceção
        //     else return lista_requisicao[index];
        // }

         public Requisicao getRequisicao(Cliente cliente){
            return filaEspera.Where( req => req.pertenceAoCliente(cliente)).First();
                    
        }
        public int getTamanhoLista(string opcao){
            int tamanho = 0;

            if (opcao.Equals("Atendimento")){
                
            } else if(opcao.Equals("Espera")){
                
            } else if(opcao.Equals("Cardapio")){
                
            }
        
            return tamanho;
        }

        public void finalizarAtendimento(Requisicao requisicao) //fecha uma comanda
        {
            foreach (var req in lista_requisicao)
            {
                if (req.Equals(this.requisicao))
                {
                    this.requisicao.finalizarRequisicao();
                }
            }
        }

        public void realizarPedido(Requisicao requisicao, int opcaoCardapio) //Adiciona um novo pedido na comanda de uma requisicao especificada
        {
            
            /*foreach (var req in lista_requisicao)
            {
                if (req.Equals(this.requisicao))
                {
                    requisicao.add(opcaoCardapio); //req n tem opcao cardapio
                }
            }*/
        }

        public string exibeCardapio() // Retorna uma String que mostrar todos os itens do cardápio.
        {
            return cardapio.ToString();
        }

        public string exibeListaAtendimento() //Retorna uma String com todos clientes com status  de requisicao 1 (em atendimento)
        {
            StringBuilder todosClientesEmAtendimento = new StringBuilder();
            foreach (var cliente in filaEspera)
            {
                for (int i = 1; i <= filaEspera.Count; i++)
                {
                    todosClientesEmAtendimento.AppendLine(i + ".");
                }
                todosClientesEmAtendimento.Append(cliente);
                todosClientesEmAtendimento.AppendLine("");
            }
            return todosClientesEmAtendimento.ToString();
        }
//bool finalizada em requisicao nao eh 0 1 ou 2
        public string exibeListaEspera() //Retorna uma String com todos clientes com status  de requisicao 0 (em espera)
        {
            StringBuilder todosClientesEmEspera = new StringBuilder();
            foreach (var cliente in lista_requisicao)
            {
               /* if (cliente.finalizada == 0)
                {
                    for (int i = 1; i <= lista_requisicao.Count; i++)
                {
                    todosClientesEmEspera.AppendLine(i + ".");
                }
                todosClientesEmEspera.Append(cliente);
                todosClientesEmEspera.AppendLine("");
                }
                */
            }
            return todosClientesEmEspera.ToString();
        }

        public string exibeListaClientes() //Retorna uma String com todos clientes gerais
        {
            StringBuilder todosClientes = new StringBuilder();
            foreach (var cliente in lista_requisicao)
            {
                for (int i = 1; i <= lista_requisicao.Count; i++)
                {
                    todosClientes.AppendLine(i + ".");
                }
                todosClientes.Append(cliente);
                todosClientes.AppendLine("");
            }
            return todosClientes.ToString();
        }

        public void adicionarItem(Item novoItem) //Adiciona novo item ao cardapio
        {
            cardapio.adicionarItem(novoItem.nome, novoItem,preco);
        }

        /// <summary>
        ///  responsável por gerar os itens do cardápio pré-estabelecidos pelo requisitos.
        /// </summary>
        public void gerarCardapio()
        {
            cardapio.gerarItens();
        }

        internal void atenderProximo()
        {
            //procurar uma mesa livre;
            //encontrar a primeira requisição que cabe naquela mesa
            //iniciar atendimento da requisicao
        }

        #endregion

    }
}
