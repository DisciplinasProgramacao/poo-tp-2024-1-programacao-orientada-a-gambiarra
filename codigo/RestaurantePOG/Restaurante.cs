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
        /// M�todo para atender um cliente no restaurante
        /// </summary>
        /// <param name="cliente">Cliente a ser atendido</param>
        public void atenderCliente(Cliente cliente)
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// M�todo privado para adicionar um cliente � fila de espera
        /// </summary>
        /// <param name="cliente">Cliente a ser adicionado � fila de espera</param>
        private void addFilaEspera(Cliente cliente)
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// M�todo para atender o pr�ximo cliente da fila de espera
        /// </summary>
        /// <returns>O cliente atendido</returns>
		public Cliente atenderFilaEspera()
		{
			throw new NotImplementedException();
		}
	}
}
