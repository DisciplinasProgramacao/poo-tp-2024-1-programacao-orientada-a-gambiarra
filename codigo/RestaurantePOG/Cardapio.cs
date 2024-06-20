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

    public void gerarItens()
    {
        // Dados fixos para as comidas
        adicionarItem("Moqueca de Palmito", 32);
        adicionarItem("Falafel Assado", 20);
        adicionarItem("Salada Primavera com Macarr�o Konjac", 25);
        adicionarItem("Escondidinho de Inhame", 18);
        adicionarItem("Strogonoff de Cogumelos", 35);
        adicionarItem("Cacarola de legumes", 22);

        // Dados fixos para as bebidas
        adicionarItem("Agua", 3);
        adicionarItem("Copo de suco", 7);
        adicionarItem("Refrigerante org�nico", 7);
        adicionarItem("Cerveja vegana", 9);
        adicionarItem("Taca de vinho vegano", 18);
    }

}

