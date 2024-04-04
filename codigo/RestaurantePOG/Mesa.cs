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
    private bool status;
    private Queue<FilaEspera> filaEspera; /// fila de espera de clientes que desejam ocupar a mesa
        public Mesa(int id, int capacidade)
    {
        this.id = id;
        this.capacidade = capacidade;
        this.status = false;
        this.filaEspera = new Queue<FilaEspera>();
    }
        public void AtenderCliente(Cliente cliente)/// Atribui um cliente a mesa e marca a mesa como ocupada
    {
        this.cliente = cliente;
        this.status = true;
    }

        public bool statusOcupacao()///Retorna true se a mesa estiver ocupada e false se estiver disponivel
		{
			 return status;
		}
        public void AtendimentoEncerrado()///Marca a mesa com disponivel e libera o cliente que estava nela 
    {
        this.status = false;
        this.cliente = null;
    }
 public int Id
    {
        get { return id; }
    }

    public int Capacidade
    {
        get { return capacidade; }
    }

    public Cliente Cliente
    {
        get { return cliente; }
    }
    public Queue<FilaEspera> FilaEspera
    {
        get { return filaEspera; }
    }
}
}