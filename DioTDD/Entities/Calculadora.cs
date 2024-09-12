using System;
using System.Collections.Generic;
using System.Text;

namespace DioTDD.Entities
{
    public class Calculadora
    {
        private List<string> historico;

        public Calculadora()
        {
            historico = new List<string>();
        }

        public int Somar(int numero1, int numero2)
        {   
            int resultado = numero1 + numero2;
            historico.Insert(0, $"{numero1} + {numero2} = {resultado}" );
           
            return resultado;
        }
        public int Dividir(int numero1, int numero2)
        {
            int resultado = numero1 / numero2;
            historico.Insert(0, $"{numero1} / {numero2} = {resultado}");

            return resultado;
        }
        public int Subtrair(int numero1, int numero2)
        {
            int resultado = (numero1) - (numero2);
            historico.Insert(0, $"{numero1} - {numero2} = {resultado}");

            return resultado;
        }
        public int Multiplicar(int numero1, int numero2)
        {
            int resultado = numero1 * numero2;
            historico.Insert(0, $"{numero1} * {numero2} = {resultado}");

            return resultado;
        }

        public List<string> RetornarHistorico()
        {
            historico.RemoveRange(3, historico.Count - 3);
            return historico;
        }
    }
}
