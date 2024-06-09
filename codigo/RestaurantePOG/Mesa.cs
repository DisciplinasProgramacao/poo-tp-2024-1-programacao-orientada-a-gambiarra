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
    private int proximoId;
    private int capacidade;
    private bool status;
   
        public Mesa(int id, int proximoId, int capacidade)
    {
        this.id = id;
        this.proximoId = proximoId;
        this.capacidade = capacidade;
        this.status = false;
    }
 public int Id
    {
        get { return id; }
        set { id = value;}
    }
    public int ProximoId
    {
        get {return proximoId; }
        set {proximoId = value; }
    }
      public int Capacidade
    {
        get { return capacidade; }
        set { proximoId = value; }
    }
 public bool Status
    {
        get { return status;}
        set { status = value;}
    }
    public bool EstahOcupada() // retorna true se a mesa estiver ocupada e false caso contrario
    {
        return status;
    }

    public void Ocupar() // define o status da mesa para ocupado
    {
        status = true;
    }

    public void Desocupar() // define o status da mesa para desocupado
    {
        status = false;
    }
}
}