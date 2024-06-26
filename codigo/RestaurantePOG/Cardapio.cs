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

        public Item? buscarItemPorNome(string nome) {
            Item? item = null;
            try{
                item = itens.Find(item => item.getNome().Equals(nome));
            } catch(ArgumentException){ }
            return item;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder().Append(cabecalho());
            foreach (Item item in itens) { sb.AppendLine(item.ToString()); }
            sb.Append(rodape());
            return sb.ToString();
        }  

        public string cabecalho(){
            return "================================================\n"+
                   "========             CARDAPIO            =======\n"+
                   "================================================\n";
        }

        public string rodape(){
            return "================================================";
        }
        #endregion
    }
}
