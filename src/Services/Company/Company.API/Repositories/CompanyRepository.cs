using Company.API.Data;
using Company.API.Entities;
using Company.API.Repositories.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ICompanyContext _context;

        public CompanyRepository(ICompanyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateCompanyData(CompanyData CompanyData)
        {
            await _context.Companies.InsertOneAsync(CompanyData);
        }

        public async Task<bool> DeleteCompanyData(string id)
        {
            FilterDefinition<CompanyData> filterDefinition = Builders<CompanyData>.Filter.Eq(p=>p.Id ,id);
            DeleteResult deleteResult = await _context.Companies.DeleteOneAsync(filterDefinition);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


        public async Task<IEnumerable<CompanyData>> GetCompanyDataByName(string name)
        {
            FilterDefinition<CompanyData> filter = Builders<CompanyData>.Filter.Regex(p => p.CompanyName, BsonRegularExpression.Create(name));

            return await _context
                            .Companies
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<CompanyData>> GetCompanyData()
        {
            return await _context.Companies.Find(p => true).ToListAsync();
        }
        public async Task<CompanyData> GetCompanyData(string id)
        {
            FilterDefinition<CompanyData> filter = Builders<CompanyData>.Filter.Eq(p => p.Id, id);

            return await _context
                            .Companies
                            .Find(filter).FirstOrDefaultAsync();


        }

        public async Task<bool> UpdateCompanyData(CompanyData CompanyData)
        {

            var updateResult = await _context.Companies.ReplaceOneAsync(filter: p => p.Id == CompanyData.Id, replacement: CompanyData);

            return updateResult.IsAcknowledged &&
                updateResult.ModifiedCount > 0;
        }
    }
}
