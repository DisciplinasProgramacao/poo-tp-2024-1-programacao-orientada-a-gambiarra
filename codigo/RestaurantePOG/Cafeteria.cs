namespace RestaurantePOG
{
    public class Cafeteria : Estabelecimento {
        public Cafeteria(string nome) : base(nome) { }
        #region Métodos
        /// <summary>Método responsável por cadastrar um cliente e automaticamente iniciar o seu atendimento independente de uma mesa<summary>
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
        public override bool atenderCliente(Requisicao? requisicao) { 
            bool resultado = false;

            if(requisicao != null){
                requisicao.iniciarRequisicao(null);
                resultado = true;
            }
            
            return resultado;
        }

        /// <summary>Método responsável por exibir uma lista dos clientes em atendimento</summary>
        /// <returns>Lista de clientes em atendimento .ToString()</returns>
        public override string exibeListaAtendimento()  { return exibeListaClientes(); }

        public bool vincularMesa(string nomeCliente){
            bool alocado = false;
            Requisicao? requisicao;

            // Procurar mesas livres
            List<Mesa> mesas_disponiveis = mesas.Where(m => !m.estahOcupada()).ToList();
            requisicao = getRequisicaoPorNomeCliente(nomeCliente);

            if (requisicao != null && !requisicao.estahAlocadaEmMesa()) {
                foreach (Mesa mesa in mesas_disponiveis) {
                    if (requisicao.getQuantidadePessoas() <= mesa.getCapacidade()) {
                        requisicao.registrarMesa(mesa); // Aloca cliente à Mesa
                        alocado = true;
                        break; // Interrompe o loop de mesas assim que a requisição é alocada
                    }
                }
            }
            return alocado;
        }
        #endregion
    }
}
