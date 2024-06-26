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

        public override void cadastrarCliente(string nome, int qtdPessoas) {
            // Gerar uma requisicao com as informações especificadas
            Cliente cliente = new (nome);
            Requisicao requisicao = new Requisicao(cliente, qtdPessoas);

            lista_requisicao.Add(requisicao); // Inserir na lista de requisicoes
            lista_clientes.Add(cliente); // inserir na lista de clientes
            atenderCliente(requisicao);
        }

        public override void atenderCliente(Requisicao requisicao) { requisicao.iniciarRequisicao(); }
    
        public override string exibeListaAtendimento()  { return exibeListaClientes(); }
    }
}
