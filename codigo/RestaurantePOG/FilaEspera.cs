using System;
using System.Collections;
using System.Collections.Generic;

namespace RestaurantePOG { 
    /// <summary>
    /// Classe representando a fila de espera do restaurante
    /// </summary>
    public class FilaEspera : IEnumerable<Cliente>
    {
        #region Atributos
        private List<Cliente> clientes;
        #endregion

        #region Construtor
        /// <summary>
        /// Construtor padrão da classe FilaEspera
        /// </summary>
        public FilaEspera()
        {
            clientes = new List<Cliente>();
        }
        #endregion

        #region Métodos
        public void adicionarCliente(Cliente cliente) {  clientes.Add(cliente); }

        public void removerFila(Cliente cliente) { clientes.Remove(cliente); }

        public bool estaVazia() { return clientes.Count == 0; }

        public IEnumerator<Cliente> GetEnumerator() { return clientes.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion
    }
}
