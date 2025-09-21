public enum ItemCategory
{
    Default = 0,// La qualité diminue normalement
    IncreaseWithAge = 1, // La qualité augmente avec le temps
    Legendary = 2, // La qualité ne change pas avec le temps 

    IncreaseBeforeSellIn = 3,// La qualité augmente jusqu'au jour SellIn puis ensuite à 0
    
    Conjured = 4// La qualité diminue 2 fois plus vite
}