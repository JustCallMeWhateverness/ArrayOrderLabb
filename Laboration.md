# Övning: Orderhanteringssystem med arrayer
## Scenario
Ni arbetar med att bygga ett orderhanteringssystem för en webbutik. På grund av begränsningar i systemet får ni inte använda några inbyggda samlingsklasser som `List<T>` eller funktioner i `Array` för sökning och sortering. Istället måste ni använda arrayer för att hantera produkter och order. Detta innebär att ni måste implementera egna algoritmer för att:

- Söka och filtrera produkter.
- Sortera produkter.
- Dynamiskt hantera storleken på arrayer.

### Viktiga begränsningar 
> Ni får **inte** använda några inbyggda samlingsklasser eller funktioner för sökning, sortering eller filtrering.
>
> **Vad innebär detta?**
> - Ni får **inte** använda `List<T>`, `Dictionary<TKey, TValue>` eller andra samlingsklasser. Alla data ska hanteras med arrayer.
> - Ni får **inte** använda inbyggda funktioner som:
>   - `Array.Sort` – för sortering.
>   - `Array.Find` eller `Array.FindIndex` – för sökning.
>   - `Array.BinarySearch` – för effektiv sökning.
>   - LINQ-metoder som `Where`, `OrderBy`, `Select`, etc.

## Kravspecifikation
### 1. Produkthantering
Produkterna ska lagras i en array. Ni ska implementera följande funktioner:

- Lägga till en produkt i arrayen (hantera om arrayen blir full genom att skapa en ny, större array).
- Ta bort en produkt från arrayen baserat på dess Id.
- Söka efter en produkt baserat på namn eller kategori (implementera en linjär sökalgoritm).

### 2. Lagersaldo
#### Skapa en metod som heter `UpdateStock` i klassen `Product`. Den ska:

*   Ta två parametrar:
    *   `int amount` – Antalet produkter som ska läggas till eller tas bort från lagret.
    *   `bool isDelivery` – Om `true` är det en leverans till lagret (öka lagret), annars är det en försäljning (minska lagret).
*   Uppdatera lagersaldot (`ILager`) för produkten baserat på dessa parametrar.
*   Validera indata och hantera följande situationer:
    *   Om `amount` är 0 eller negativt, kasta en `ArgumentException` med ett tydligt felmeddelande.
    *   Om `isDelivery` är `false` (försäljning) och `amount` är större än lagersaldot, kasta en `InvalidOperationException`.
    *   Om `isDelivery` är `true` och `amount` överstiger 10 000 (valfri gräns för stora leveranser), kasta en `InvalidOperationException` (valfritt för att skapa fler testfall).

#### Tester för `UpdateStock`
Eftersom metoden har flera möjliga utfall beroende på indata, behöver vi skriva flera tester för att täcka alla scenarier.

##### Testfall för leveranser (`isDelivery = true`):
*   Vanlig leverans (öka lagret).
*   Leverans med ogiltig mängd (0 eller negativt värde).
*   Leverans som överstiger gränsen (valfritt krav).

##### Testfall för försäljning (`isDelivery = false`):
*   Vanlig försäljning (minska lagret).
*   Försäljning med ogiltig mängd (0 eller negativt värde).
*   Försäljning som överskrider lagersaldot.

### 2. Sortering av produkter
Implementera egna algoritmer för att sortera arrayen med produkter:

- Sortering efter pris (stigande och fallande).
- Sortering efter namn (alfabetisk ordning).
- Sortering efter kategori.

### 3. Filtrering av produkter
Implementera en filtreringsfunktion som returnerar en ny array med produkter baserat på:

- Prisintervall.
- Lagerstatus (om produkter finns i lager).
- Kategori.


## Exempel på användning
```csharp
var productManager = new ProductManager(5); // Skapa en manager med initial kapacitet för 5 produkter
productManager.AddProduct(new Product(1, "Laptop", "Elektronik", 15000, 5));
productManager.AddProduct(new Product(2, "T-shirt", "Kläder", 200, 20));
productManager.AddProduct(new Product(3, "Bok", "Böcker", 150, 10));

var sortedByPrice = productManager.SortByPrice(ascending: true); // Sortera med egen algoritm
var filteredByCategory = productManager.FilterByCategory("Elektronik"); // Filtrera produkter

var order = new Order(5); // Skapa en order med initial kapacitet för 5 produkter
order.AddProduct(productManager.GetProductById(1), 1); // Lägg till produkten i ordern
```

### Hantera orderrader i en array
Implementera följande metoder:

- `AddProduct(Product product, int quantity)`: Lägg till en produkt i ordern.
- Dra av kvantiteten från lagersaldot.

### Detaljerad arbetsgång
#### 1. Produkthantering
Skapa en `Product`-klass:
Egenskaper: `Id`, `Namn`, `Kategori`, `Pris`, `ILager`.
Skapa en `ProductManager`-klass:
Hantera produkter i en array.
Implementera följande metoder:
- `AddProduct(Product product)`: Lägg till en ny produkt i arrayen.
- `RemoveProduct(int productId)`: Ta bort en produkt från arrayen genom att skapa en ny array utan produkten.
- `SearchProductByName(string name)`: Implementera en linjär sökning för att hitta en produkt baserat på namn.

#### 2. Sortering av produkter
Implementera en bubblesort eller selection sort för att sortera produkter i arrayen.
Sortera efter pris (stigande och fallande).
Sortera efter namn (alfabetiskt).
Sortera efter kategori.
Exempel på bubblesort för pris:
```csharp
public Product[] SortByPrice(bool ascending)
{
    var sortedArray = (Product[])_products.Clone();
    for (int i = 0; i < sortedArray.Length - 1; i++)
    {
        for (int j = 0; j < sortedArray.Length - i - 1; j++)
        {
            bool condition = ascending
                ? sortedArray[j].Pris > sortedArray[j + 1].Pris
                : sortedArray[j].Pris < sortedArray[j + 1].Pris;

            if (condition)
            {
                var temp = sortedArray[j];
                sortedArray[j] = sortedArray[j + 1];
                sortedArray[j + 1] = temp;
            }
        }
    }
    return sortedArray;
}
```

#### 3. Filtrering av produkter
Implementera en metod som returnerar en ny array med produkter som uppfyller vissa villkor.
Filtrera efter prisintervall.
Filtrera efter lagerstatus.
Filtrera efter kategori.
Exempel på filtrering efter kategori:
```csharp
public Product[] FilterByCategory(string category)
{
    int count = 0;
    foreach (var product in _products)
    {
        if (product != null && product.Kategori == category)
        {
            count++;
        }
    }

    var result = new Product[count];
    int index = 0;
    foreach (var product in _products)
    {
        if (product != null && product.Kategori == category)
        {
            result[index++] = product;
        }
    }
    return result;
}
```

#### 4. Orderhantering
Skapa en `Order`-klass:
Hantera orderrader i en array.
Implementera följande metoder:
- `AddProduct(Product product, int quantity)`: Lägg till en produkt i ordern.
- Dra av kvantiteten från lagersaldot.
- `CalculateTotal()`: Beräkna totalkostnaden för ordern och applicera rabatter.
Exempel på beräkning av totalkostnad:
```csharp
public decimal CalculateTotal()
{
    decimal total = 0;
    foreach (var item in _orderItems)
    {
        if (item != null)
        {
            total += item.Product.Pris * item.Quantity;
        }
    }

    if (total > 1000) total *= 0.9m; // 10% rabatt
    return total;
}
```

## Begränsningar och Utmaningar
- Dynamiska arrayer:
  Studenterna måste själva hantera storleksförändringar i arrayerna.
- Algoritmer:
  Alla sorteringar, sökningar och filtreringar ska implementeras manuellt.
- Prestanda:
  Diskutera med studenterna hur algoritmernas komplexitet påverkar prestandan (t.ex., O(n²) för bubblesort jämfört med effektivare algoritmer).

## Diskussionsfrågor
- Hur kan vi optimera våra algoritmer för att hantera större datamängder?
- Vad är fördelarna och nackdelarna med att använda arrayer jämfört med listor?
- Hur kan vi generalisera våra lösningar för att återanvända funktionalitet?

## Syfte med övningen
- Algoritmiskt tänkande: Tvingar studenterna att förstå och implementera grundläggande algoritmer.
- Datastrukturhantering: Ger insikt i hur arrayer fungerar och hur de kan hanteras manuellt.
- TDD: Uppmuntrar att utveckla lösningen steg för steg med hjälp av tester.