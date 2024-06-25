using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantePOG {
    
    ///<summary>Classe representando uma Mesa</summary>
    public class Mesa {
        #region Atributos
        private int capacidade;
        private bool ocupada; 
        #endregion
   
        #region Construtor
        ///<summary>Método responsável por instanciar um novo objeto da classe Mesa</summary>
        ///<param name="capacidade">capacidade referente àquela mesa</param>
        ///<returns>Objeto do tipo Mesa</returns>
        public Mesa(int capacidade) {
            ocupada = false;
            this.capacidade = capacidade;   
        }
        #endregion
        
        #region Métodos
        ///<summary>Método responsável por verificar se a mesa está ou não ocupada</summary>
        ///<returns>Retorna 'False' caso NAO esteja ocupada e 'True' caso esteja</returns>
        public bool estahOcupada() { return ocupada; }

        ///<summary>Método responsável por definir o status da mesa para ocupado(True)</summary>
        public void ocupar(){ ocupada = true; }

        ///<summary>Método responsável por definir o status da mesa para desocupado(False)</summary>
        public void desocupar()  { ocupada = false; }

        ///<summary>Método responsável por retornar qual a capacidade a mesa possui</summary>
        ///<returns>Retorna um número inteiro indicando a capacidade da mesa</returns>
        internal int getCapacidade() { return capacidade; }
        #endregion
    }
 }
