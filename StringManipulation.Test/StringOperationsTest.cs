using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Test
{
    public class StringOperationsTest
    {
        [Fact (Skip = "Atributo para omitir prueba")]
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

        [Theory]
        [InlineData("cat", 10, "ten")]
        [InlineData("dog", 5, "five")]
        public void Deberia_devolver_el_numero_en_palabras_y_la_palabra(string word, int quantity,string  expected)
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.QuantintyInWords(word, quantity);

            //Assert
            Assert.StartsWith(expected, result);
            Assert.Contains(word, result);
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
            //Arrange
            var strOperations = new StringOperations();

            //Act
            int result = strOperations.FromRomanToNumber(romanNumber);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]

        public void PruebaConMock()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            //Act
            var result = strOperations.CountOccurrences("Sara", 'S');

            //Assert
            Assert.Equal(result, 1);
        }

        [Fact]

        public void deberia_leer_el_archivo()
        {
            //Arrange
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("valor de prueba");
            
            //Act
            var result = strOperations.ReadFile(mockFileReader.Object, "File.txt");

            //Assert
            Assert.Equal("valor de prueba", result);
        }
    }
}
