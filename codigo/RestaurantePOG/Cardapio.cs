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
        adicionarItem("Salada Primavera com Macarrão Konjac", 25);
        adicionarItem("Escondidinho de Inhame", 18);
        adicionarItem("Strogonoff de Cogumelos", 35);
        adicionarItem("Caçarola de legumes", 22);

        // Dados fixos para as bebidas
        adicionarItem("Água", 3);
        adicionarItem("Copo de suco", 7);
        adicionarItem("Refrigerante orgânico", 7);
        adicionarItem("Cerveja vegana", 9);
        adicionarItem("Taça de vinho vegano", 18);
    }

}

