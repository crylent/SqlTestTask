using System.Collections.Immutable;
using System.Data;
using SqlTestTask.Enums;
using MutableCatalog = System.Collections.Generic.Dictionary<string, int>;

namespace SqlTestTask.Services;

public class CatalogService : ICatalogService
{
    private readonly IDatabaseService _db;
    
    private readonly MutableCatalog _departments = [];
    private readonly MutableCatalog _posts = [];
    private readonly MutableCatalog _statuses = [];
    
    private readonly Dictionary<string, MutableCatalog> _catalogs;

    public CatalogService(IDatabaseService db)
    {
        _db = db;
        _catalogs = new Dictionary<string, MutableCatalog>
        {
            { "deps", _departments },
            { "posts", _posts },
            { "status", _statuses }
        };
    }

    public async Task LoadCatalogs()
    {
        ClearCatalogs();
        var table = await _db.SelectTable(StoredProcedure.GetCatalog);
        foreach (DataRow row in table.Rows)
        {
            _catalogs[(string) row["table"]].Add((string) row["name"], (int) row["id"]);
        }
    }

    public Catalog Departments => _departments.ToImmutableDictionary();
    public Catalog Posts => _posts.ToImmutableDictionary();
    public Catalog Statuses => _statuses.ToImmutableDictionary();

    private void ClearCatalogs()
    {
        _departments.Clear();
        _posts.Clear();
        _statuses.Clear();
    }
}