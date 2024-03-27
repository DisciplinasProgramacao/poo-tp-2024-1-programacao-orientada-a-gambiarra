using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>
    /// Classe representando uma requisi��o de atendimento no restaurante
    /// </summary>
    public class Requisicao
	{
		int id;
		Cliente cliente;
		DateTime entrada;
		DateTime saida;
		Mesa mesa;

        /// <summary>
        /// M�todo para adicionar uma mesa � requisi��o
        /// </summary>
        /// <returns>A mesa adicionada � requisi��o</returns>
        public Mesa addMesa()
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// M�todo para verificar se o atendimento da requisi��o foi encerrado
        /// </summary>
        /// <returns>True se o atendimento foi encerrado, False caso contr�rio</returns>
        public bool atendimentoEncerrado()
		{
			throw new NotImplementedException();
		}
	}
}
