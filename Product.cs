﻿using System;

namespace protopkuis1
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Name}, Price: {Price}, Stock: {Stock}";
        }
    }
}
