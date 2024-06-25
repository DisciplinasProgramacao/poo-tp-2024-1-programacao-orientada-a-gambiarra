using System;
using System.Text;

namespace RestaurantePOG
{
    /// <summary>Classe representando o cliente do restaurante.</summary>
    public class Cliente {
        #region Atributos
        private string nome;
        #endregion
        #region Construtor
        public Cliente(string nome) { this.nome = nome; }    
        #endregion
        #region Métodos
       /// <summary>Retorna o nome do Cliente</summary>
       /// <returns>String contendo o nome do cliente</returns>
        public string getNome(){ return nome; }

        public override string ToString() { return $"-> {nome}"; }

        #endregion
    }
}

