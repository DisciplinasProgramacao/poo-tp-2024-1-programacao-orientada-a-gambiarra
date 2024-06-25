using System.Text;

namespace RestaurantePOG{
    public class Cardapio {
        #region Atributos
        private List <Item> itens;
        #endregion
        #region Construtor
        public Cardapio() {
            itens = new List<Item>();
        }
        #endregion
        #region Métodos
        public Cardapio adicionarItem(string nome, double preco) {
            itens.Add(new Item(nome, preco));
            return this;
        }

        public Item? buscarItem(string nome)
        {
            Item? item = itens.Find(item => item.getNome().Equals(nome));
            if (item != null)
                return item;
            else
            {
                Console.WriteLine("Item não encontrado no cardápio");
                return null;
            }
                
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder().Append(cabecalho());
            foreach (Item item in itens) {
                sb.AppendLine(item.ToString());
                
                }
            return sb.ToString() + ("================================================"); ;
        }  

        public string cabecalho(){
            return "================================================\n"+
                   "========             CARDAPIO            =======\n"+
                   "================================================\n";
        }
        #endregion
    }
}
