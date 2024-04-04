using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando o restaurante
    /// </summary>
    public class Restaurante
{
	#region atributos
	private List<Requisicao> queue;
	private List<Mesa> mesas;
	private List<Cliente> clientes;
	private int maxMesas = 10;
	#endregion

	#region Construtores
	public Restaurante()
	{
	
	}
    #endregion

    #region métodos
    public void atenderCliente(Cliente cliente, int qntPessoas)
	{

	}

   
    public void addFilaEspera(Cliente cliente)
	{

	}

    
	public void atenderFilaEspera(Cliente cliente)
	{

	}

	public void procurarNaFila()
	{

	}

	public void encerrarAtendimento(int idRequisicao)
	{

	}


	public void reservarMesa(Mesa mesa)
	{

	}
    #endregion
}
