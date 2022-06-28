using MongoDB.Driver;
using Company.API.Entities;

namespace Company.API.Data
{
    public interface ICompanyContext
    {
        IMongoCollection<CompanyData> Companies { get; }
    }
}
