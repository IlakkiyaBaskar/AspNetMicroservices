using Company.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Company.API.Data
{
    internal class CompaniesSeedData
    {
        internal static void SeedData(IMongoCollection<CompanyData> companies)
        {
            long exists = companies.Find(p => true).Count();
            if(exists < 1)
            {
                companies.InsertManyAsync(GetPreConfiguredCompanies());
            }
        }

        private static IEnumerable<CompanyData> GetPreConfiguredCompanies()
        {
            return new List<CompanyData>()
                {
                new CompanyData()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    CompanyName = "Company001",
                    CompanyCode = "001"
                },
                new CompanyData()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    CompanyName = "Company002",
                    CompanyCode = "002"
                },
                new CompanyData()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    CompanyName = "Company003",
                    CompanyCode = "003"
                },
                new CompanyData()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    CompanyName = "Company004",
                    CompanyCode = "004"
                },
                new CompanyData()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    CompanyName = "Company005",
                    CompanyCode = "005"
                },
                new CompanyData()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    CompanyName = "Company006",
                    CompanyCode = "006"
                }
            };
        }
    }
}