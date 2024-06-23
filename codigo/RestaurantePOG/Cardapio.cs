using System.Text;

namespace RestaurantePOG{
    public class Cardapio {
        private List <Item> itens;

        public Cardapio() {
            itens = new List<Item>();
        }

        public Cardapio adicionarItem(string nome, double preco) {
            itens.Add(new Item(nome, preco));
            return this;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder().Append(cabecalho());
            foreach (Item item in itens) { sb.AppendLine(item.ToString()); }
            return sb.ToString();
        }  

        public string cabecalho(){
            return "=========================================\n"+
                   "====             CARDAPIO            ====\n"+
                   "=========================================\n";
        }
    }
}