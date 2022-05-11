// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using NpgSqlMultipleContexts;

using (var db = new TestContext2())
{
    db.Products.Add(new Product
    {
        Id = Guid.NewGuid(),
        Name = $"product-{DateTime.UtcNow.Ticks}"
    });

    db.SaveChanges();

    Console.WriteLine(JsonSerializer.Serialize(db.Products.ToList()));
}

using (var db = new TestContext())
{
    db.Clients.Add(new Client
    {
        Id = Guid.NewGuid(),
        ClientType = ClientType.Regular
    });

    db.Clients.Add(new Client
    {
        Id = Guid.NewGuid(),
        ClientType = ClientType.Vip
    });

    db.SaveChanges();

    Console.WriteLine(JsonSerializer.Serialize(db.Clients.ToList()));
}
