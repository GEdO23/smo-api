using Domain.Interfaces.Settings;

namespace Settings.MongoDb;

public class MongoDbSettings : IMongoDbSettings
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
    public string? CollectionName { get; set; }
}