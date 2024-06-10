using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o restaurante
    /// </summary>
    public class Restaurante
    {
        #region atributos
        private static int MAX_MESA = 10;
        private static String nome;
        private List<Requisicao> lista_requisicao;
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
                new Mesa(4), new Mesa(4), new Mesa(4), new Mesa(4),
                new Mesa(6), new Mesa(6), new Mesa(6), new Mesa(6),
                new Mesa(8), new Mesa(8)
            }
            this.filaEspera = new List<Requisicao>();
            this.cardapio = new Cardapio();
           
        }
        #endregion

        #region métodos
        public Requisicao consultarEmAtendimentos()
        {
            List<Requisicao> clientesEmAtendimento = new List<Requisicao>();
            foreach (Requisicao requisicao in lista_requisicao)
            {
                if (requisicao.getStatus = 1)
                {
                    clientesEmAtendimento.Add(Requisicao)
                }
            }
            return clientesEmAtendimento;
        }

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
            Mesa mesa = new Mesa();
            foreach (Mesa mesaDisp in getMesasDisponiveis())
            {
                if (requisicao.getQuantidadePessoas() < mesaDisp.getCapacidade())
                {
                    mesa = mesaDisp;
                    break;
                }
            }
            requisicao.iniciarRequisicao(mesa);
        }

        private List<Mesa> getMesasDisponiveis()
        {
            List<Mesa> getMesasDisponiveis = new List<Mesa>();
            foreach (Mesa mesa in mesas)
            {
                if (!mesa.EstahOcupada())
                {
                    getMesasDisponiveis.Add(mesa);
                }
            }
            return getMesasDisponiveis;
        }

        public void adicionaFilaEspera(Requisicao requisicao)
        {
            filaEspera.add(requisicao);
        }

        public void adicionarRequisicao(Requisicao requisicao)
        {
            lista_requisicao.add(requisicao);
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



        #endregion

    }
}
