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

        [Fact]
        public void ConcertTicket_QualityChange_QualityIncreasesSingle_longLead()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, 14);
            Assert.Equal(Items[0].Quality, 21);
        }

        [Fact]
        public void ConcertTicket_QualityChange_QualityIncreasesSingle_lastSingleIncrease()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 15},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, 10);
            Assert.Equal(Items[0].Quality, 16);
        }

        [Fact]
        public void ConcertTicket_QualityChange_QualityIncreasesDouble_tenDays()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, 9);
            Assert.Equal(Items[0].Quality, 22);
        }

        [Fact]
        public void ConcertTicket_QualityChange_QualityIncreasesDouble_sixDays()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 20},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, 5);
            Assert.Equal(Items[0].Quality, 22);
        }

        [Fact]
        public void ConcertTicket_QualityChange_QualityIncreasesTriple_fourDays()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 8},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, 3);
            Assert.Equal(Items[0].Quality, 11);
        }

        [Fact]
        public void ConcertTicket_QualityChange_QualityIncreasesTriple_oneDay()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 13},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, 0);
            Assert.Equal(Items[0].Quality, 16);
        }

        [Fact]
        public void ConcertTicket_QualityChange_ZeroQuality_afterConcert()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 34},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, -1);
            Assert.Equal(Items[0].Quality, 0);
        }

        [Fact]
        public void ConcertTicket_QualityChange_QualityIncreasesSingle()
        {
            var Items = new List<Item> {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(Items[0].SellIn, 14);
            Assert.Equal(Items[0].Quality, 21);
        }
        // conjured items
        [Fact]
        public void ConjuredItems_QualityChange_DegradeTwiceAsFast()
        {
            var Items = new List<Item> {
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
            };
            Program.UpdateQuality(Items);
            Assert.NotNull(Items);
            Assert.NotEmpty(Items);
            Assert.Equal(Items[0].Name, "Conjured Mana Cake");
            Assert.Equal(Items[0].SellIn, 2);
            Assert.Equal(Items[0].Quality, 4);
        }
    }
}