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
		int id;
		int capacidade;
		bool status;

        /// <summary>
        /// M�todo para verificar o status de ocupa��o da mesa
        /// </summary>
        /// <returns>True se a mesa estiver ocupada, False caso contr�rio</returns>
        public bool statusOcupacao()
		{
			throw new NotImplementedException();
		}
	}
}
