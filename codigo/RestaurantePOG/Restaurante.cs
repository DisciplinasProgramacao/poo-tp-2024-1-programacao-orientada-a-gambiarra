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
        private <Cardapio> cardapio;
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
            this.cardapio = new Cardapio;
           
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

        public void iniciaAtendimento(Requisicao requisicao)
        {
            requisicao.associaMesa()
        }

        public void atenderCliente(Cliente cliente, int qntPessoas)
        {

            Requisicao requisicao = cliente.fazerRequisicao(quantPessoas);
            return realizarAlocacaoMesa(requisicao);
        }

        private Boolean validaClienteEmEspera(Requisicao requisicao)
        {
            if ()
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        private Boolean validaStatusRequisicao(Requisicao requisicao)
        {
            if ()
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        private List<Mesa> getMesasDisponiveis()
        {
            List<Mesa> getMesasDisponiveis = new List<Mesa>();
            foreach (Mesa mesas in Mesas)
            {
                if (!mesas.Ocupada)
                {
                    getMesasDisponiveis.Add(mesas);
                }
            }
            return getMesasDisponiveis;
        }

        private Requisicao getProximoFilaEspera(int capacidade)
        {

        }
        #endregion
    }
}
