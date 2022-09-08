using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestItem_SellInDecrement_NonZero()
        {
            var Items = new List<Item> {
                new Item {Name = "test_item", SellIn = 2, Quality = 10},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "test_item");
            Assert.Equal(Items[0].SellIn, 1);
        }

        [Fact]
        public void TestItem_SellInDecrement_Zero()
        {
            var Items = new List<Item> {
                new Item {Name = "test_item", SellIn = 0, Quality = 10},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "test_item");
            Assert.Equal(Items[0].SellIn, -1);
        }

        [Fact]
        public void TestItem_QualityDecrement_InDate()
        {
            var Items = new List<Item> {
                new Item {Name = "test_item", SellIn = 10, Quality = 10},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "test_item");
            Assert.Equal(Items[0].Quality, 9);
        }

        [Fact]
        public void TestItem_QualityDecrement_DateIsZero()
        {
            var Items = new List<Item> {
                new Item {Name = "test_item", SellIn = 0, Quality = 10},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "test_item");
            Assert.Equal(Items[0].Quality, 8);
        }

        [Fact]
        public void TestItem_QualityDecrement_DateIsNegative()
        {
            var Items = new List<Item> {
                new Item {Name = "test_item", SellIn = -1, Quality = 10},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "test_item");
            Assert.Equal(Items[0].Quality, 8);
        }

        [Fact]
        public void TestItem_QualityDecrement_CanDecrementToZero()
        {
            var Items = new List<Item> {
                new Item {Name = "test_item", SellIn = 10, Quality = 1},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "test_item");
            Assert.Equal(Items[0].Quality, 0);
        }

        [Fact]
        public void TestItem_QualityDecrement_CantDecrementToNegative()
        {
            var Items = new List<Item> {
                new Item {Name = "test_item", SellIn = 0, Quality = 1},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "test_item");
            Assert.Equal(Items[0].Quality, 0);
        }

        [Fact]
        public void AgedBrie_QualityChange_QualityIncreases()
        {
            var Items = new List<Item> {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 1},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Aged Brie");
            Assert.Equal(Items[0].SellIn, 9);
            Assert.Equal(Items[0].Quality, 2);
        }

        [Fact]
        public void AgedBrie_QualityChange_QualityIncreasesDouble()
        {
            var Items = new List<Item> {
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 1},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Aged Brie");
            Assert.Equal(Items[0].SellIn, -1);
            Assert.Equal(Items[0].Quality, 3);
        }

        [Fact]
        public void TestItem_QualityIncrement_CanIncrementToFifty()
        {
            var Items = new List<Item> {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 49},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Aged Brie");
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void TestItem_QualityIncrement_CantIncrementPastFifty()
        {
            var Items = new List<Item> {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 50},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Aged Brie");
            Assert.Equal(Items[0].Quality, 50);
        }

        [Fact]
        public void TestItem_QualityIncrement_WontIncrementPastFifty()
        {
            var Items = new List<Item> {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Sulfuras, Hand of Ragnaros");
            Assert.Equal(Items[0].Quality, 80);
        }

        [Fact]
        public void Sulfuras_Ages()
        {
            var Items = new List<Item> {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Sulfuras, Hand of Ragnaros");
            Assert.Equal(Items[0].SellIn, 0);
        }

        [Fact]
        public void Sulfuras_Quality_DoesNotDecrease()
        {
            var Items = new List<Item> {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Sulfuras, Hand of Ragnaros");
            Assert.Equal(Items[0].Quality, 50);
        }

        // backstage passes
        // conjured items
    }
}