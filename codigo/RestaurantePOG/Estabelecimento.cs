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

            public abstract void atenderCliente(Requisicao requisicao);

            public abstract string exibeListaAtendimento();

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

            public bool realizarPedido(Requisicao requisicao, string nomeItem, int quantidade)  {
                bool resultado = false;
                
                Item? item = cardapio.buscarItemPorNome(nomeItem);

                if(item != null) { resultado = requisicao.addPedido(quantidade, item); }
                
                return resultado;
            }

            public string exibeListaClientes() {
                StringBuilder sb = new StringBuilder();
                foreach (Cliente cliente in lista_clientes) { sb.AppendLine(cliente.ToString()); }
                return sb.ToString();
            }

            public string finalizarAtendimento(Requisicao requisicao) {
                string resultado = requisicao.finalizarRequisicao(); 
                lista_clientes.Remove(requisicao.getCliente());
                return resultado;
            }
            #endregion
        }
    }
