using System;
using Moq;
using ProjetoESW.Controllers;
using ProjetoESW.Data;
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
            var controller = new SpeciesController(mockContext.Object);
          
            //var result = controller.MyCreate("Cão");




        }
    }
}
