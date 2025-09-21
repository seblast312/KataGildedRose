using System;

namespace GildedRoseKata;

/// <summary>
/// Sous-
/// </summary>
public class ItemCategorized : Item
{
    private readonly ItemCategory _category;
    public ItemCategory Category { get => _category; }

    public ItemCategorized(Item item) : base()
    {
        if (string.IsNullOrEmpty(item.Name))
        {
            throw new ArgumentException("Le nom de l'article est requis.");
        }

        if (item.Quality < 0)
        {
            throw new ArgumentException("La qualité de l'article doit avoir une valeur supérieure à 0.");
        }

        this.Name = item.Name;
        this.Quality = item.Quality;
        this.SellIn = item.SellIn;

        // On categorise l'item grâce à son nom
        if (item.Name.StartsWith("Aged Brie"))
        {
            this._category = ItemCategory.IncreaseWithAge;
        }
        else if (item.Name.StartsWith("Sulfuras"))
        {
            this._category = ItemCategory.Legendary;
        }
        else if (item.Name.StartsWith("Backstage passes"))
        {
            this._category = ItemCategory.IncreaseBeforeSellIn;
        }
        else if (item.Name.StartsWith("Conjured"))
        {
            this._category = ItemCategory.Conjured;
        }
        else
        {
            this._category = ItemCategory.Default;
        }
    }

    public void UpdateQuality()
    {
        switch (_category)
        {
            case ItemCategory.Default:
                this.Quality = this.Quality - 1 >= 0 ? this.Quality - 1 : 0;
                break;
            case ItemCategory.IncreaseWithAge:
                this.Quality = this.Quality + 1 >= 50 ? 50 : this.Quality + 1;
                break;
            case ItemCategory.IncreaseBeforeSellIn:
                if (this.SellIn > 10)
                {
                    this.Quality += 1;
                }
                else if (this.SellIn > 5 && this.SellIn <= 10)
                {
                    this.Quality += 2;
                }
                else if (this.SellIn >= 0 && this.SellIn <= 5)
                {
                    this.Quality += 3;
                }
                else
                {
                    this.Quality = 0;
                }
                break;
            case ItemCategory.Conjured:
                this.Quality = this.Quality - 2 >= 0 ? this.Quality - 2 : 0;
                break;
            default:
                break;
        }
        this.SellIn = this.SellIn - 1;
    }
}