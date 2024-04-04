using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o restaurante
    /// </summary>
    public class Restaurante
    {

        Queue<FilaEspera> FilaEspera;

        private List<Cliente> clientesCadastrados = new List<Cliente>();
        private List<Requisicao> requisicoes = new List<Requisicao>();
        private List<Mesa> mesasDisponiveis = new List<Mesa>();

        /// <summary>
        /// 
        /// Metodo para cadastrar um novo cliente no restaurante
        ///
        /// recebe as informacoes necessarias como parametro e adiciona
        /// esse novo objeto a lista de clientes cadastrados
        /// 
        /// </summary>

        public void CadastrarCliente(string nome, int quantidadePessoa)
        {
            // Cria um novo cliente e adiciona à lista de clientes cadastrados
            Cliente novoCliente = new Cliente(nome, quantidadePessoa);
            clientesCadastrados.Add(novoCliente);
        }

        /// <summary>
        /// Metodo para atender um cliente no restaurante
        /// 
        /// 
        /// 
        /// Etapas:
        /// 
        /// 1. verifica se tem mesa disponivel
        /// 2. se sim, alocar em uma mesa 
        /// 3. se nao, colocar na fila de espera
        ///
        /// 
        /// 
        /// </summary>
        /// <param name="cliente">Cliente a ser atendido</param>
        public void atenderCliente(Cliente cliente)
        {
            Mesa mesaDisponivel = null;

            // Percorre todas as mesas disponíveis
            foreach (Mesa mesa in mesasDisponiveis)
            {
                // Verifique se a mesa está ocupada, se for false == livre

                if (!mesa.statusOcupacao()) 
                {
                    mesaDisponivel = mesa;
                    break;
                }
            }

            if (mesaDisponivel != null)
            {
                
                mesaDisponivel.AlocarCliente(cliente); // Aloque o cliente à mesa disponível, metodo ainda não implementado
                mesasDisponiveis.Remove(mesaDisponivel);
            }
            else
            {
                
                FilaEspera.addFilaEspera(cliente);  // Coloque o cliente na fila de espera, metodo ainda não implementado
            }
        }
        
        
        /// <summary>
        /// Metodo para criar uma requisicao
        /// 
        /// cria um novo objeto Requisicao com essas informações de cliente e mesa
        /// e adiciona esse novo objeto à lista de requisições
        /// 
        /// </summary>
        
        
        public void CriarRequisicao(Cliente cliente, Mesa mesa)
        {
            Requisicao novaRequisicao = new Requisicao();
            novaRequisicao.Cliente = cliente;
            novaRequisicao.Mesa = mesa;
            requisicoes.Add(novaRequisicao);
        }

        /// <summary>
        /// M�todo privado para adicionar um cliente � fila de espera
        /// </summary>
        /// <param name="cliente">Cliente a ser adicionado � fila de espera</param>
        private void addFilaEspera(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// M�todo para atender o pr�ximo cliente da fila de espera
        /// </summary>
        /// <returns>O cliente atendido</returns>
		public Cliente atenderFilaEspera()
        {
            throw new NotImplementedException();
        }
    }
}
