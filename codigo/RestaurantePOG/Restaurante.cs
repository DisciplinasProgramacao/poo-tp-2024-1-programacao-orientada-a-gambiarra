using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

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
        private List<Requisicao> lista_requisicao;
        private List<Mesa> mesas;
        private FilaEspera filaEspera;
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
            this.filaEspera = new FilaEspera();
            this.cardapio = new Cardapio();
           
        }
        #endregion

        #region métodos
        
        /// <summary>
        /// Retorna quais mesas estão em atendimento
        /// </summary>
        /// <returns>Mesa</returns>
        public Requisicao consultarEmAtendimentos()
        {
        return lista_requisicao.FirstOrDefault(requisicao => requisicao.getStatus() == 1);
        }
        /// <summary>
        /// Função de retornar se a requisição pode ser atendida pela quantidade de pessoas.
        /// </summary>
        /// <param name="requisicao"></param>
        /// <returns></returns>
        public bool estahAptoAtendimento(Requisicao requisicao) 
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

        public void atenderCliente(Requisicao requisicao)
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
        /// <summary>
        /// Adiciona requsição a fila de espera.
        /// </summary>
        /// <param name="requisicao"></param>
        public void adicionaFilaEspera(Requisicao requisicao)
        {
            filaEspera.addRequisicao(requisicao);
        }

        public void removerFilaEsperaPorId(int id)
        {
            try
            {
                Requisicao req = filaEspera.buscarRequisicaoPorId(id);
                filaEspera.removerRequisicao(req);

                Console.WriteLine("Requisição removida com sucesso !!!\n");
            }
            catch { 
                Console.WriteLine("Requisição não encontrada na fila de espera !!!");
            }
        
        }
      

        public void adicionarRequisicao(Requisicao requisicao)
        {
            lista_requisicao.Add(requisicao);
        }


        public Requisicao getRequisicao(int index){
            return lista_requisicao[index];
        }
        public int getTamanhoLista(string opcao){
            int tamanho = 0;

            if (opcao.Equals("Atendimento")){
                            /// 
            } else if(opcao.Equals("Espera")){
                            ///    
            } else if(opcao.Equals("Cardapio")){
                            ///
            }
        
            return tamanho;
        }

        internal void finalizarAtendimento(Requisicao requisicao)
        {
            throw new NotImplementedException();
        }

        internal void realizarPedido(Requisicao requisicao, int opcaoCardapio)
        {
            throw new NotImplementedException();
        }

        internal bool exibeCardapio()
        {
            throw new NotImplementedException();
        }

        internal void exibeListaAtendimento()
        {
            throw new NotImplementedException();
        }

        public string exibeFilaEspera()
        {
            return filaEspera.ToString();
        }

        internal bool exibeListaClientes()
        {
            throw new NotImplementedException();
        }

        internal void adicionarItem(Item novoItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Casse responsável por gerar os itens do cardápio pré-estabelecidos pelo requisitos.
        /// </summary>
        public void gerarCardapio()
        {
            cardapio.gerarItens();
        }

        #endregion

    }
}
