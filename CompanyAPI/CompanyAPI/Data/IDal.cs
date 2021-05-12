using CompanyAPI.Entities;
using System.Collections.Generic;

namespace CompanyAPI.Data
{
    public interface IDal
    {
        IList<CompanyGetEntity> CompanySelectAll();
        IList<CompanyGetEntity> CompanySelectByCompanyID(int companyId);
        IList<CompanyGetEntity> CompanySelectByISIN(string isin);
        int InsertCompany(CompanyEntity companyEntity);
        int UpdateCompany(CompanyEntity companyUpdateEntity);
    }
}