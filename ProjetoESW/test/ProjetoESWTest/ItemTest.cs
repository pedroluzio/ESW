using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoESW.Models.Stock;
using Xunit;

namespace ProjetoESWTest
{

    public class ItemTest
    {
        [Fact]
        public void ItemCreat()
        {
            ItemType itemType1 = new ItemType("Ração de Cão", 100){Items = new List<Item>()};

            Item item1 = new Item()
                {Descricao = "Ração E Continente", ItemTypeID = itemType1.ID, ItemType = itemType1, Quantidade = 10,Movements = new List<Movements>()};
            
            itemType1.Items.Add(item1);
            Assert.False(item1.HaveHistory());
            Assert.Equal(itemType1,item1.ItemType);
            Assert.Equal(itemType1.Items[0],item1);
            Assert.Equal(0,item1.QuantityAvailable());
        }

        [Fact]
        public void ItemAddMovement()
        {
            ItemType itemType1 = new ItemType("Ração de Cão", 100) { Items = new List<Item>() };

            Item item1 = new Item()
                { Descricao = "Ração E Continente", ItemTypeID = itemType1.ID, ItemType = itemType1, Quantidade = 10, Movements = new List<Movements>() };

            itemType1.Items.Add(item1);

            Assert.Equal(0,item1.QuantityAvailable());

            item1.Movements.Add(new Movements(){Item=item1, ItemID = item1.ID,Moment = DateTime.Now,Quantity = 10});

            Assert.Equal(10*10,item1.QuantityAvailable());
            Assert.Equal(item1.Quantidade*item1.Movements.Sum(m=>m.Quantity),item1.QuantityAvailable());

            Assert.Equal(item1.QuantityAvailable(),itemType1.QuantityAvailable());

        }
    }
}
