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
        /// Método para verificar o status de ocupação da mesa
        /// </summary>
        /// <returns>True se a mesa estiver ocupada, False caso contrário</returns>
        public bool statusOcupacao()
		{
			throw new NotImplementedException();
		}
	}
}
