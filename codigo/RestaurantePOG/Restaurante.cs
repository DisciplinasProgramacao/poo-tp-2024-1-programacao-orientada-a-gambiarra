using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o restaurante
    /// </summary>
    public class Restaurante
{
	#region atributos
	private List<Requisicao> requisicao = new List<Requisicao>();
	private List<Mesa> mesas = new List<Mesa>();
	private Queue<Cliente> filaClientes = new Queue<Cliente>();
	private Queue<Cliente> filaEspera = new Queue<Cliente>();
	private int maxMesas = 10;
	#endregion

	#region Construtores
	public Restaurante(List<Mesa> mesas)
	{
		this.mesas = mesas;
		this.filaClientes = new Queue<Cliente>();
		this.filaEspera = new Queue<Cliente>();
		this.maxMesas = 10;
		this.requisicao = new List<Requisicao>();
	}
    #endregion

    #region métodos
    public void atenderCliente(Cliente cliente, int qntPessoas)
	{
		Console.WriteLine("Atendido: " + filaClientes.Peek());
		filaClientes.Dequeue();
		cliente.solicitarReserva(qntPessoas);
	}

   
    private void addFilaEspera(Cliente cliente)
	{
		 filaEspera.Enqueue(cliente);
         Console.WriteLine("Cliente adicionado à fila de espera.");
	}

    
	private void atenderFilaEspera(Cliente cliente, int qntPessoas)
	{
		Console.WriteLine("Atendido: " + filaEspera.Peek());
		filaEspera.Dequeue();
		cliente.solicitarReserva(qntPessoas);
	}

	public void encerrarAtendimento(int idRequisicao)
	{
		
	}


	public void reservarMesa(Mesa mesa)
	{
		mesa.isOcupada();
	}

	private String verificarMesaDisponivel()
	{
		 StringBuilder listaMesas = new StringBuilder();
            foreach(Mesa mesa in mesas)
            {
                listaMesas.AppendLine(String.Format("Capacidade Mesa: {0} Disponibilidade: {1}"+ mesa.getCapacidade(), mesa.statusOcupacao()));
            }
            return listaMesas.ToString();
	}
	public String relatorioFila(Cliente cliente)
	{
		StringBuilder relatorioFila = new StringBuilder();
		foreach	(Cliente obj in filaClientes)
		{
			relatorioFila.Append(obj.ToString() + "(Fila de atendimento)");
		}
		foreach	(Cliente obj in filaEspera)
		{
			relatorioFila.Append(obj.ToString() + "(Fila de espera)");
		}
		return relatorioFila.ToString();
	}
    #endregion
}
}
