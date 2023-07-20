

using Mediafy.Checkout.DataAccess.Context;
using Mediafy.Checkout.DataAccess.Implementation;
using Mediafy.Checkout.DataAccess.Interfaces;
using Mediafy.Checkout.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

MediafyInMemoryContext context = new(DbContextOptions<MediafyInMemoryContext> options);
IProductData productdata = new ProductData(context);
List<Product> products = productdata.GetAllProducts();

foreach (var product in productdata.GetAllProducts())
{
    Console.WriteLine(product.Name);
}

Console.Read();