using System;
using Xunit;

namespace ProjetoESWTest
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {

            //preciso de um ApplicationDbContext!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1111

            var mockContext = new Mock<ApplicationDbContext>();
            //var controller = new MembrosController(new ClubeContext(new DbContextOptions<ClubeContext>()));

            //var controller = new MembrosController(mockContext.Object);


            //var result = controller.AteMaioridade(idade);

           // Assert.Equal(expected, result);
        }
    }
}
