
using Xunit;
using ProjetoESW.Models.Stock;

namespace ProjetoESWTest
{
    public class ItemTypesTest
    {

        [Fact]
        public void ItemTypeCreate()
        {
            ItemType itemType1 = new ItemType("Ração de Cão",100);
            ItemType itemType2 =  new ItemType("Ração de Gato",5);

            Assert.False(itemType1.HaveHistory());
            Assert.False(itemType2.HaveHistory());

            Assert.Equal(0, itemType1.QuantityAvailable());
            Assert.Equal("Abaixo do Limite",itemType1.StockAvailable());
            
        }

       

    }
}
