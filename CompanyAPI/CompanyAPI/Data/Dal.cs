using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CompanyAPI.Entities;
using Dapper;

namespace CompanyAPI.Data
{
    public class Dal: IDal
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int InsertCompany(CompanyEntity companyEntity)
        {
            var indentity = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("dbo.CompanyInsert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ISIN", SqlDbType.VarChar).Value = companyEntity.ISIN;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = companyEntity.Name;
                    command.Parameters.Add("@Exchange", SqlDbType.VarChar).Value = companyEntity.Exchange;
                    command.Parameters.Add("@Ticker", SqlDbType.VarChar).Value = companyEntity.Ticker;
                    command.Parameters.Add("@Website", SqlDbType.VarChar).Value = companyEntity.Website;

                    if (connection == null)
                        connection.Open();

                    indentity = (int)command.ExecuteScalar();

                    if (connection == null)
                        connection.Close();
                }
            }

            return indentity;
        }

        public IList<CompanyGetEntity> CompanySelectAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<CompanyGetEntity>(
                        sql: "dbo.pCompanySelectAll", 
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public IList<CompanyGetEntity> CompanySelectByCompanyID(int companyId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<CompanyGetEntity>(
                        sql: "dbo.pCompanySelectByCompanyID",
                        param: new { companyId },
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IList<CompanyGetEntity> CompanySelectByISIN(string isin)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<CompanyGetEntity>(
                        sql: "dbo.pCompanySelectByISIN",
                        param: new { isin},
                        commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int UpdateCompany(CompanyEntity companyUpdateEntity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using( var command = new SqlCommand("dbo.CompanyUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = companyUpdateEntity.CompanyID;
                    command.Parameters.Add("@ISIN", SqlDbType.VarChar).Value = companyUpdateEntity.ISIN;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = companyUpdateEntity.Name;
                    command.Parameters.Add("@Exchange", SqlDbType.VarChar).Value = companyUpdateEntity.Exchange;
                    command.Parameters.Add("@Ticker", SqlDbType.VarChar).Value = companyUpdateEntity.Ticker;
                    command.Parameters.Add("@Website", SqlDbType.VarChar).Value = companyUpdateEntity.Website;

                    if(connection == null)
                        connection.Open();

                    command.ExecuteNonQuery();

                    if (connection == null)
                        connection.Close();
                }  
            }

            return 0;
        }
    }
}