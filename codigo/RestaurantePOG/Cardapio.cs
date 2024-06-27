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
        /// <summary>Método responsável por adicionar um novo item ao cardápio</summary>
        /// <param name="nome">Nome do item</param>
        /// <param name="preco">preço do item</param>
        /// <returns>A adição do item no cardápio</returns>
        public Cardapio adicionarItem(string nome, double preco) {
            itens.Add(new Item(nome, preco));
            return this;
        }


        /// <summary>Busca o item especificado</summary>
        /// <param name="nome">Nome do item</param>
        /// <returns>O item</returns>
        public Item? buscarItemPorNome(string nome) {
            Item? item = null;
            try{
                item = itens.Find(item => item.getNome().Equals(nome));
            } catch(ArgumentException){ }
            return item;
        }


        /// <summary>Cabeçalho do cardápio</summary>
        /// <returns>O cabeçalho</returns>
        private string cabecalho(){
            return "================================================\n"+
                   "=======             CARDAPIO             =======\n"+
                   "================================================\n";
        }
        

        /// <summary>O cabeçalho como string</summary>
        /// <returns>O cabeçalho como string formatado</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder().Append(cabecalho());
            foreach (Item item in itens) { sb.AppendLine(item.ToString()); }
            sb.Append("================================================");
            return sb.ToString();
        }  
        #endregion
    }
}
