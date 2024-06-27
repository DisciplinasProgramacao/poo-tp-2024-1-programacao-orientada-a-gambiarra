using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG
{
    public class Cafeteria : Estabelecimento {
        
        public Cafeteria(string nome) : base(nome) { }

        /// <summary>Método responsável por cadastrar um cliente<summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="qtdPessoas">Quantidade de pessoas</param>
        public override void cadastrarCliente(string nome, int qtdPessoas) {
            // Gerar uma requisicao com as informações especificadas
            Cliente cliente = new (nome);
            Requisicao requisicao = new Requisicao(cliente, qtdPessoas);

            lista_requisicao.Add(requisicao); // Inserir na lista de requisicoes
            lista_clientes.Add(cliente); // inserir na lista de clientes
            atenderCliente(requisicao);
        }

        /// <summary>Atende o cliente especificado de acordo com sua requisição. Inicia sua requisição</summary>
        /// <param name="requisicao">A requisição do cliente</param>
        public override void atenderCliente(Requisicao requisicao) { requisicao.iniciarRequisicao(); }

        /// <summary>Método responsável por exibir uma lista dos clientes em atendimento</summary>
        /// <returns>Lista de clientes em atendimento .ToString()</returns>
        public override string exibeListaAtendimento()  { return exibeListaClientes(); }
    }
}
