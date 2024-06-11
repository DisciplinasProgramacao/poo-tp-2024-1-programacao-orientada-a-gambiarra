using RestaurantePOG;

public class Cardapio
{
    private List <Item> itens;

    public Cardapio()
    {
        itens = new List<Item>();
    }

    public void adicionarItem(string nome, double preco)
    {
        itens.Add(new Item(nome, preco));
    }
    public void gerarItens() {
       
    }
    //public List<Item> GetItemCardapio()
    //{
   // return itens;
   // }
    
}