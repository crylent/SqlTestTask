global using Catalog = System.Collections.Immutable.ImmutableDictionary<string, int>;

namespace SqlTestTask.Services;

public interface ICatalogService
{
    public Task LoadCatalogs();

    public Catalog Departments { get; }
    public Catalog Posts { get; }
    public Catalog Statuses { get; }
}