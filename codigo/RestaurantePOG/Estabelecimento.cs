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

            public abstract string exibeListaAtendimento();

            public abstract void atenderCliente();

            public string exibeCardapio() { return cardapio.ToString(); }
    
            public void gerarCardapio(Cardapio cardapio) {  this.cardapio = cardapio;  }

            public void gerarMesas(List<Mesa> mesas) { this.mesas = mesas; }

            public void adicionarItemCardapio(string nome, double preco) { cardapio.adicionarItem(nome, preco); }

            public void adicionarMesa(int qtdPessoas){ mesas.Add(new Mesa(qtdPessoas)); }

            public Requisicao? getRequisicaoPorCliente(Cliente cliente) {

                Requisicao? requisicao = null;

                try {
                    Cliente? clienteEncontrado = lista_clientes.Find(c => c.getNome() == cliente.getNome());
                    if (clienteEncontrado != null) {
                        requisicao = lista_requisicao.Find(r => r.getCliente() == cliente);
                    }
                    else { throw new ArgumentNullException(); }
                }
                catch (ArgumentNullException) { }

                return requisicao;
            }
            public Requisicao buscarRequisicaoPorCliente(string cliente) {
                try
                {
                    Requisicao? requisicao = lista_requisicao.Find(req => req.getNomeCliente().Equals(cliente));
                    if(requisicao != null)
                        return requisicao;
                    else
                    {
                        Console.WriteLine("Não há requisições para esse cliente");
                        return null;
                    }
                }
                catch
                {
                    Console.WriteLine("Erro ao executar a pesquisa de cliente");
                    return null;

                }
            }

            public void realizarPedido(Requisicao requisicao, string opcaoCardapio, int quantidade)  {
                Item? item = cardapio.buscarItem(opcaoCardapio);
                if(item == null) {
                    Console.WriteLine("Item não encontrado");

                }
                else {
                    requisicao.addPedido(quantidade, item);
                    Console.WriteLine("Pedido realizado com sucesso.");

                }
            
            }

            public string exibeListaClientes() {
                StringBuilder sb = new StringBuilder();
                foreach (Cliente cliente in lista_clientes) { sb.AppendLine(cliente.ToString()); }
                return sb.ToString();
            }

            public string finalizarAtendimento(Requisicao requisicao) { return requisicao.finalizarRequisicao(); }
            #endregion
        }
    }
