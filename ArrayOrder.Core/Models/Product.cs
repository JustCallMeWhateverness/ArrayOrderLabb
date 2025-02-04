namespace ArrayOrder.Core.Models;
public class Product
{
    public int Id { get; set; } // Unikt ID för produkten
    public string Namn { get; set; } // Namn på produkten
    public string Kategori { get; set; } // Kategori, t.ex., "Elektronik", "Kläder"
    public decimal Pris { get; set; } // Pris i kronor
    public int ILager { get; set; } // Antal produkter i lager

    public Product(int id, string namn, string kategori, decimal pris, int iLager)
    {
        Id = id;
        Namn = namn;
        Kategori = kategori;
        Pris = pris;
        ILager = iLager;
    }

    public void UpdateStock(int amount, bool isDelivery)
    {
        // TODO: Implement stock update
    }

    public override string ToString()
    {
        return $"{Id}: {Namn} ({Kategori}) - {Pris} kr, Lager: {ILager}";
    }
}