namespace Domain.Interfaces.Settings;

public interface IMongoDbSettings
{
    string? ConnectionString { get; set; }
    string? DatabaseName { get; set; }
    string? CollectionName { get; set; }
}