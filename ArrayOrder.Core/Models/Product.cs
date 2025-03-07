﻿namespace ArrayOrder.Core.Models;
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
        if (amount <= 0)
        {
            throw new ArgumentException("Invalid amount, needs to be more than zero");
        }
        else if (amount > ILager && isDelivery == false)
        {
            throw new InvalidOperationException("Invalid amount, exceeds amount in stock");
        }
        else if (isDelivery == true && amount > 10000)
        {
            throw new InvalidOperationException("Invalid amount, exceeded allowed amount to purchase.");
        }

        if (isDelivery)
        {
            ILager += amount;
        }
        else
        { ILager -= amount; }

    }

    public override string ToString()
    {
        return $"{Id}: {Namn} ({Kategori}) - {Pris} kr, Lager: {ILager}";
    }
}