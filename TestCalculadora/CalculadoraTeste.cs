using System;
using Xunit;
using DioTDD.Entities;
using System.Security.Cryptography.X509Certificates;

namespace TestCalculadora
{
    public class CalculadoraTeste
    {
        private Calculadora _calculadora;

        public CalculadoraTeste()
        {
            _calculadora = new Calculadora();
        }
       
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(4,5,9)]
        public void Somar_PassandoDoisNumerosInteiros(int valor1, int valor2, int resultado)
        {
            int resultadoCalculadora = _calculadora.Somar(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(4,2,2)]
        [InlineData(8,2,4)]
        public void Dividir_PassandoDoisNumerosInteiros(int valor1, int valor2, int resultado)
        {
            int resultadoCalculadora = _calculadora.Dividir(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(4, 2, 8)]
        [InlineData(-5, -5, 25)]
        public void Multiplicar_PassandoDoisNumerosInteiros(int valor1, int valor2, int resultado)
        {
            int resultadoCalculadora = _calculadora.Multiplicar(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(-5, -5, 0)]
        [InlineData(20, -5, 25)]
        public void Subtrair_PassandoDoisNumerosInteiros(int valor1, int valor2, int resultado)
        {
            int resultadoCalculadora = _calculadora.Subtrair(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Assert.Throws<DivideByZeroException>(
                () => _calculadora.Dividir(3, 0)
             );
        }
       
        [Fact]
        public void TestarHistorico()
        {
            _calculadora.Somar(1, 2);
            _calculadora.Somar(3, 4);
            _calculadora.Somar(5, 7);
            _calculadora.Somar(10, 10);
            _calculadora.Somar(5, 5);
            _calculadora.Subtrair(2, 2);
            _calculadora.Dividir(2, 2);
            _calculadora.Multiplicar(3, 3);

            var lista = _calculadora.RetornarHistorico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }


    }
}
