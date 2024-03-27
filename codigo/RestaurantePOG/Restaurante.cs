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
		Requisicao [] requisicao;
		Queue <FilaEspera> FilaEspera;

        /// <summary>
        /// Método para atender um cliente no restaurante
        /// </summary>
        /// <param name="cliente">Cliente a ser atendido</param>
        public void atenderCliente(Cliente cliente)
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// Método privado para adicionar um cliente à fila de espera
        /// </summary>
        /// <param name="cliente">Cliente a ser adicionado à fila de espera</param>
        private void addFilaEspera(Cliente cliente)
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// Método para atender o próximo cliente da fila de espera
        /// </summary>
        /// <returns>O cliente atendido</returns>
		public Cliente atenderFilaEspera()
		{
			throw new NotImplementedException();
		}
	}
}
