using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Reflection;

namespace RestaurantePOG {

    ///<summary>Classe representando o restaurante </summary>
    public class Restaurante {

#region atributos
        private String nome; 
        private List<Mesa> mesas;
        private List<Requisicao> lista_requisicao;
        private List<Cliente> lista_clientes;
        private FilaEspera fila_espera;
        private Cardapio cardapio;
#endregion

#region Construtores
        ///<summary>Método responsável por instanciar um novo objeto da classe Restaurante</summary>
        ///<param name="nome"></param>
        ///<returns>Objeto do tipo Restaurante</returns>
        public Restaurante(String nome) {
            lista_requisicao = new List<Requisicao>();
            lista_clientes = new List<Cliente>();
            fila_espera = new FilaEspera();
            cardapio = new Cardapio();
            mesas = new List<Mesa>();
            this.nome = nome;
        }
#endregion

#region métodos

        public void atenderProximo() {
            //procurar uma mesa livre;
            //encontrar a primeira requisição que cabe naquela mesa
            //iniciar atendimento da requisicao
        }


        public void realizarPedido(Requisicao requisicao, string opcaoCardapio)  {
            
            // Verificar se a 'opcaoCardapio' existe dentro do Cardapio. Ex: { [Banana, Pera] => opcaoCardapio = uva } => False
            // Se existir realizar o pedido, se não retornar uma exceção nula igual o metodo 'getRequisicaoPorNomeCliente'

        }


        public string exibeListaAtendimento()  {
            // Retorna uma string com todos os clientes que não estão na lista de espera e não possuem o status da requisição como finalizado.
            return "";
        }


        public string exibeListaClientes() {
            // Retornar uma string com o nome de todos os clientes. Para implementação, siga o exemplo do ToString do Cardapio.
            return "";
        }

        
        public void finalizarAtendimento(Requisicao requisicao) { requisicao.finalizarRequisicao(); }

        public string exibeCardapio() { return cardapio.ToString(); }
    
        public void gerarCardapio(Cardapio cardapio) {  this.cardapio = cardapio;  }

        public void gerarMesas(List<Mesa> mesas) { this.mesas = mesas; }

        public void adicionarItemCardapio(string nome, double preco) { cardapio.adicionarItem(nome, preco); }

        public void adicionarMesa(int qtdPessoas){ mesas.Add(new Mesa(qtdPessoas)); }
        

        public void cadastrarCliente(string nome, int qtdPessoas){
            // Gerar uma requisicao com as informações especificadas
            // Inserir na lista de requisicoes
            // inserir na lista de espera
            // inserir na lista de clientes
        }


        public Requisicao? getRequisicaoPorNomeCliente(Cliente cliente) {

            Requisicao? requisicao = null;

            try{
                Cliente? clienteEncontrado = lista_clientes.Find(c => c.getNome() == cliente.getNome());
                if (clienteEncontrado != null) {
                    requisicao = lista_requisicao.Find(r => r.getCliente() == cliente);
                }
                else { throw new ArgumentNullException(); }
            } catch (ArgumentNullException){  }

            return requisicao;
        }
#endregion
    }
}
