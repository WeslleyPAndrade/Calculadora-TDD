using CalculadoraApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraAppTests
{
    public class CalculadoraTests
    {
        private Calculadora calculadora;
        public Calculadora InstanciaCalculadora(Calculadora calculadora)
        {
            if (calculadora == null)
            {
                return new Calculadora();
            }

            return calculadora;
        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(5,5,10)]
        public void TesteSomar(int val1, int val2, int result)
        {
            //Arrange
            calculadora = InstanciaCalculadora(calculadora);

            //Act

            int resultadoCalc = calculadora.Somar(val1, val2);

            //Assert

            Assert.Equal(result, resultadoCalc);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(5, 5, 0)]
        public void TesteSubtratir(int val1, int val2, int result)
        {
            //Arrange
            calculadora = InstanciaCalculadora(calculadora);
            //Act

            int resultadoCalc = calculadora.Subtratir(val1, val2);

            //Assert

            Assert.Equal(result, resultadoCalc);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(5, 5, 25)]
        public void TesteMultiplicar(int val1, int val2, int result)
        {
            //Arrange
            calculadora = InstanciaCalculadora(calculadora);

            //Act

            int resultadoCalc = calculadora.Multiplicar(val1, val2);

            //Assert

            Assert.Equal(result, resultadoCalc);
        }

        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int val1, int val2, int result)
        {
            //Arrange
            calculadora = InstanciaCalculadora(calculadora);

            //Act

            int resultadoCalc = calculadora.Dividir(val1, val2);

            //Assert

            Assert.Equal(result, resultadoCalc);
        }

        [Fact]
        public void TesteDividirPorZero()
        {
            calculadora = InstanciaCalculadora(calculadora);

            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(3,0));
        }
        
        [Fact]
        public void TesteHistorico()
        {
            calculadora = InstanciaCalculadora(calculadora);

            calculadora.Somar(1, 3);
            calculadora.Somar(2, 2);
            calculadora.Somar(3, 1);
            calculadora.Somar(4, 8);
            
            var lista = calculadora.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }

    }
}
