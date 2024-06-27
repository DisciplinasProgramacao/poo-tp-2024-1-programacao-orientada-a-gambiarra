namespace RestaurantePOG
{
    /// <summary>Classe representando o cliente do restaurante</summary>
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

        
        /// <summary>Nome formatado em string</summary>
        /// <returns>O Nome formatado em string</returns>
        public override string ToString() { return $"-> {nome}"; }

        #endregion
    }
}

