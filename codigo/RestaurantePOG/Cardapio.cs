using RestaurantePOG;

public class Cardapio
{
    private List <Item> itens;

    public Cardapio()
    {
        itens = new List<Item>();
    }

    public void AdicionarItem(string nome, float preco)
    {
        itens.Add(new Item(nome, preco));
    }
    public List<Item> GetItemCardapio()
{
    return itens;
}
}