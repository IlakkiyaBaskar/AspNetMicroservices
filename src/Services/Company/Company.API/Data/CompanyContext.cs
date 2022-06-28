using Company.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Data
{
    public class CompanyContext : ICompanyContext
    {
        public CompanyContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettigns:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettigns:DatabaseName"));
            Companies = database.GetCollection<CompanyData>(configuration.GetValue<string>("DatabaseSettigns:CollectionName"));
            CompaniesSeedData.SeedData(Companies);
        }

        public IMongoCollection<CompanyData> Companies { get; }
    }
}
