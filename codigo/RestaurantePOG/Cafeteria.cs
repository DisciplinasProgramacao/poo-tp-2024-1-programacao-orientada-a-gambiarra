using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG
{
    internal class Cafeteria : Estabelecimento
    {
        #region Atributos
        private Requisicao requisicao;
        #endregion
        #region Construtor
        public Cafeteria(string nome) : base(nome) {
            this.nome = nome;
            Requisicao requisicao;

        #endregion
        }
        /// <summary>
        /// Registra início do atendimento ao cliente
        /// </summary>
        public override void atenderCliente() {
            requisicao.registrar_hora();

        }
        #region Métodos
        /// <summary>
        /// Cadasta cliente e cria requisição.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="qtdPessoas"></param>
        public override void cadastrarCliente(string nome, int qtdPessoas) {
            // Gerar uma requisicao com as informações especificadas
            Cliente cliente = new(nome);
            requisicao = new Requisicao(cliente, qtdPessoas);

            lista_requisicao.Add(requisicao); // Inserir na lista de requisicoes
            lista_clientes.Add(cliente); // inserir na lista de clientes

        }
        /// <summary>
        /// Retorna as requisições de atendimento realizados pelos clientes.
        /// </summary>
        /// <returns></returns>
        public override string exibeListaAtendimento() {
            try {
                StringBuilder sb = new StringBuilder();
                foreach (var requisicoes in lista_requisicao) {
                    sb.Append(requisicoes.ToString());

                }
                return sb.ToString();
            }
            catch {
                return "Não há registros de atendimento";
            }
                        
        }
        #endregion
    }
}
