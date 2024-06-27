using System.Collections;

namespace RestaurantePOG { 
    /// <summary>Classe representando a fila de espera do restaurante</summary>
    public class FilaEspera : IEnumerable<Cliente>
    {
        #region Atributos
        private List<Cliente> clientes;
        #endregion

        #region Construtor
        /// <summary>Construtor da classe FilaEspera</summary>
        public FilaEspera()
        {
            clientes = new List<Cliente>();
        }
        #endregion

        #region Métodos
        /// <summary>Adiciona um cliente à lista de espera</summary>
        /// <param name="cliente">O objeto cliente do tipo Cliente</param>
        public void adicionarCliente(Cliente cliente) {  clientes.Add(cliente); }
        
        /// <summary>Remove um cliente específica da lista de espera</summary>
        /// <param name="cliente">Cliente a ser removido</param>
        public void removerFila(Cliente cliente) { clientes.Remove(cliente); }
        
        /// <summary>Informa se a fila de espera está vazia</summary>
        /// <returns>True se sim, false se não</returns>
        public bool estaVazia() { return clientes.Count == 0; }
        
        /// <summary>Método responsável por retornar o enumerator de clientes.</summary>
        /// <returns>Enum de clientes</returns>
        public IEnumerator<Cliente> GetEnumerator() { return clientes.GetEnumerator(); }
        
        /// <summary>Método responsável por retornar uma Enum.</summary>
        /// <returns>Enum</returns>
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion
    }
}
