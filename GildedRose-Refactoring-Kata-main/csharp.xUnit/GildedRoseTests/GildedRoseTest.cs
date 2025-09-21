using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTestNonRegression
{
    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    public void TestItemClassic(int nbdays)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "itemClassic", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        for (int i = 0; i <= nbdays; i++)
        {
            app.UpdateQuality();
            app.UpdateQualityCategorized();   
        }
        Assert.Equal(Items[0].Quality, app.ItemCategorizeds[0].Quality);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    public void TestItemAgedBrie(int nbdays)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        for (int i = 0; i <= nbdays; i++)
        {
            app.UpdateQuality();
            app.UpdateQualityCategorized();
        }
        Assert.Equal(Items[0].Quality, app.ItemCategorizeds[0].Quality);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    public void TestItemSulfuras(int nbdays)
    {
        IList<Item> Items = new List<Item> { new Item{
                Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80
            },
            new Item{
                Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80
            }
         };
        GildedRose app = new GildedRose(Items);
        for (int i = 0; i <= nbdays; i++)
        {
            app.UpdateQuality();
            app.UpdateQualityCategorized();           
        }
        Assert.Equal(Items[0].Quality, app.ItemCategorizeds[0].Quality);
        Assert.Equal(Items[1].Quality, app.ItemCategorizeds[1].Quality);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    public void TestItemBackstage(int nbdays)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        for (int i = 0; i <= nbdays; i++)
        {
            app.UpdateQuality();
            app.UpdateQualityCategorized();          
         }
        Assert.Equal(Items[0].Quality, app.ItemCategorizeds[0].Quality);
    }

    [Theory]
    [InlineData(5, 8)]
    [InlineData(1, 16)]
    public void TestItemConjured(int nbdays, int qualifiedResult)
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        for (int i = 0; i <= nbdays; i++)
        {
            app.UpdateQualityCategorized();           
        }
        Assert.Equal(qualifiedResult, app.ItemCategorizeds[0].Quality);
    }
}