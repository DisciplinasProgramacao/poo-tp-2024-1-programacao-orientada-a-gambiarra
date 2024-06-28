    using System.Text;
    using RestaurantePOG;

    namespace RestaurantePOG{

        public abstract class Estabelecimento{
            #region Atributos
            protected String nome; 
            protected List<Mesa> mesas;
            protected List<Requisicao> lista_requisicao;
            protected List<Cliente> lista_clientes;
            protected Cardapio cardapio;
            public int tipo_estabelecimento;
            #endregion

            #region Construtor
            public Estabelecimento(string nome) {
                this.nome = nome;
                lista_requisicao = new List<Requisicao>();
                lista_clientes = new List<Cliente>();
                cardapio = new Cardapio();
                mesas = new List<Mesa>();
            }
            #endregion

            #region Métodos
            public abstract void cadastrarCliente(string nome, int qtdPessoas);
            public abstract bool atenderCliente(Requisicao? requisicao);
            public abstract string exibeListaAtendimento();
            public abstract string exibeMenuEstabelecimento();
            public abstract bool validarAtendimento(string nome);


            /// <summary>Método responsável por mostrar o cardápio</summary>
            /// <returns>O cardapio em string</returns>
            public string exibeCardapio() { return cardapio.ToString(); }


            /// <summary>Método responsável por adicionar um novo item ao cardápio de itens</summary>
            /// <param name="nome">Nome do item</param>
            /// <param name="preco">Preço do item</param>
            public void adicionarItemCardapio(string nome, double preco) { cardapio.adicionarItem(nome, preco); }
            

            /// <summary>Método responsável por retornar a requisição de acordo com o cliente referido.</summary>
            /// <param name="cliente">Nome do cliente</param>
            /// <returns>A requisição do cliente</returns>
            public Requisicao? getRequisicaoPorNomeCliente(string nome) {
                Requisicao? requisicao = null;

                try {
                    Cliente? clienteEncontrado = lista_clientes.Find(c => c.Equals(nome));
                    if (clienteEncontrado != null) {
                        requisicao = lista_requisicao.Find(r => r.getCliente().Equals(nome));
                    }
                    else { throw new ArgumentNullException(); }
                }
                catch (ArgumentNullException) { }

                return requisicao;
            }
            

            /// <summary>Realiza o pedido do cliente usando as informações necessárias para tal</summary>
            /// <param name="requisicao">A requisição especificada</param>
            /// <param name="nomeItem">Nome do item especificado</param>
            /// <param name="quantidade">Quantidade de itens desejados</param>
            /// <returns>O resultado da ação, se foi possível realizar o pedido ou não.</returns>
            public bool realizarPedido(Requisicao requisicao, string nomeItem, int quantidade)  {
                bool resultado = false;
                
                Item? item = cardapio.buscarItemPorNome(nomeItem);

                if(item != null) { resultado = requisicao.addPedido(quantidade, item); }
                
                return resultado;
            }
            

            /// <summary>Mostra a lista de Clientes que passaram pelo restaurante durante a execução do programa.</summary>
            /// <returns>A lista de clientes como uma string</returns>
            public string exibeListaClientes() {
                StringBuilder sb = new StringBuilder();
                foreach (Cliente cliente in lista_clientes) { sb.AppendLine(cliente.ToString()); }
                return sb.ToString();
            }


            /// <summary>Finaliza o atendimento do cliente através de sua requisição</summary>
            /// <param name="requisicao">Requisição do cliente</param>
            /// <returns>O resultado da finalização, se foi finalizado ou não.</returns>
            public string finalizarAtendimento(Requisicao requisicao) {
                string resultado = requisicao.finalizarRequisicao(); 
                lista_clientes.Remove(requisicao.getCliente());
                return resultado;
            }
            #endregion
        }
    }
