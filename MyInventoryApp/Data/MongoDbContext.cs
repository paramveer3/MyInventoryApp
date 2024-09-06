using MongoDB.Driver;
using MyInventoryApp.Models;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        _database = client.GetDatabase("InventoryDb");
    }

    public IMongoCollection<InventoryModel> InventoryItems => _database.GetCollection<InventoryModel>("InventoryItems");
}
