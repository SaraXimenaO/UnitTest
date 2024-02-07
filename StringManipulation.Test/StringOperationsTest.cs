using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Test
{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStrings()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Theory]
        [InlineData("Hello", false)]
        [InlineData("ana", true)]
        public void Deberia_validar_si_la_palabra_es_palindrome(string word, Boolean expected)
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var resutl = strOperations.IsPalindrome(word);

            //Assert
            Assert.Equal(resutl, expected);

        }

        [Fact]
        public void QuantityInWords()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.QuantintyInWords("cat", 10);

            //Assert
            Assert.StartsWith("ten", result);
            Assert.Contains("cat", result);
        }

        [Fact]
        public void deberia_retornar_exception_cuando_input_es_null()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]

        public void deberia_retornar_excepcion_cuando_maxlenght_es_cero()
        {
            var strOperations = new StringOperations();
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("Hola", 0));
        }

        [Theory]
        [InlineData("V",5)]
        [InlineData("X", 10)]
        [InlineData("III", 3)]

        public void RomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();
            int result = strOperations.FromRomanToNumber(romanNumber);
            Assert.Equal(expected, result);
        }
    }
}
