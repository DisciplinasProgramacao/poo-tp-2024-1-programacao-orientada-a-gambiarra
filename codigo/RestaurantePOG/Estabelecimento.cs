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

            try{
                Cliente? clienteEncontrado = lista_clientes.Find(c => c.getNome() == cliente.getNome());
                if (clienteEncontrado != null) {
                    requisicao = lista_requisicao.Find(r => r.getCliente() == cliente);
                }
                else { throw new ArgumentNullException(); }
            } catch (ArgumentNullException){  }

            return requisicao;
        }

        public void realizarPedido(Requisicao requisicao, string opcaoCardapio)  {
            
            // Verificar se a 'opcaoCardapio' existe dentro do Cardapio. Ex: { [Banana, Pera] => opcaoCardapio = uva } => False
            // Se existir realizar o pedido, se não retornar uma exceção nula igual o metodo 'getRequisicaoPorNomeCliente'
        }

        public string exibeListaClientes() {
            StringBuilder sb = new StringBuilder();
            foreach (Cliente cliente in lista_clientes) { sb.AppendLine(cliente.ToString()); }
            return sb.ToString();
        }

        public void finalizarAtendimento(Requisicao requisicao) { requisicao.finalizarRequisicao(); }
        #endregion
    }
}
