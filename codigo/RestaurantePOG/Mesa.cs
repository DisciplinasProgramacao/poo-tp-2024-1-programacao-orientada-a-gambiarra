using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando uma mesa do restaurante
    /// </summary>
    public class Mesa
	{
    private int id;
    private int capacidade;
    private bool ocupada;
   
        public Mesa(int id, int capacidade)
    {
        this.id = id;
        this.capacidade = capacidade;
        this.ocupada = false;
    }
    public static List<Mesa> CriarMesas(int quantidade)
    {
        List<Mesa> mesas = new List<Mesa>();

        // Cria 10 mesas
        for (int i = 0; i < quantidade; i++)
        {
            if (i < 4)
            {
                mesas.Add(new Mesa(i + 1, 4));
            }
            else if (i < 8)
            {
                mesas.Add(new Mesa(i + 1, 6));
            }
            else
            {
                mesas.Add(new Mesa(i + 1, 8));
            }
        }

        return mesas;
    }
        public void AtenderCliente(Cliente cliente)/// Atribui um cliente a mesa e marca a mesa como ocupada
    {
        this.cliente = cliente;
        this.ocupada = true;
    }

        public bool statusOcupacao()///Retorna true se a mesa estiver ocupada e false se estiver disponivel
		{
			 return ocupada;
		}
        public void AtendimentoEncerrado()///Marca a mesa com disponivel e libera o cliente que estava nela 
    {
        this.ocupada = false;
        this.cliente = null;
    }
 public int Id
    {
        get { return id; }
    }
 public void setId(int id)
    {
        this.id = id;
    }
      public int getCapacidade()
    {
        return capacidade;
    }
 public bool isOcupada()
    {
        return ocupada;
    }
    public void setOcupada(bool ocupada)
    {
        this.ocupada = ocupada;
    }

    public override string ToString()
    {
        return "Mesa " + id + " (" + capacidade + " pessoas)";
    }
}
}