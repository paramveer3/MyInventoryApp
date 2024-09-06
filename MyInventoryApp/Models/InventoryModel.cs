using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyInventoryApp.Models
{
    public class InventoryModel
    {
        
           
            public string Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }

    }

}
