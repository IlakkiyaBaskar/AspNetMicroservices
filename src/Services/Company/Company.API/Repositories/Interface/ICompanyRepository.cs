using Company.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Repositories.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyData>> GetCompanyData();
        Task<CompanyData> GetCompanyData(string id);

        Task<IEnumerable<CompanyData>> GetCompanyDataByName(string name);
        
        Task CreateCompanyData(CompanyData CompanyData);
        Task<bool> UpdateCompanyData(CompanyData CompanyData);
        Task<bool> DeleteCompanyData(string id);
    }
}
