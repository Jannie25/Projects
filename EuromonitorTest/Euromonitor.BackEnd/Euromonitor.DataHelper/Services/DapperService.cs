using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Euromonitor.DataHelper.Interfaces;
using Euromonitor.DataHelper.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Euromonitor.DataHelper.Services
{
    public class DapperService : IDapperService
    {
        private readonly ConnectionStrings _connectionStrings;

        public DapperService(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value; 
        }
        public void Dispose()
        {

        }

        public int Execute(string storedProcedure, object parameters = null)
        {
            using IDbConnection db = GetDbconnection();
            return db.Execute(storedProcedure, parameters, null, 60, CommandType.StoredProcedure);
        }

        public List<T> Query<T>(string storedProcedure, object parameters = null)
        {
            using IDbConnection db = GetDbconnection();
            return db.Query<T>(storedProcedure, parameters, null, true, 60, CommandType.StoredProcedure).ToList();
        }

        public T QuerySingle<T>(string storedProcedure, object parameters = null)
        {
            using IDbConnection db = GetDbconnection();
            return db.QuerySingle<T>(storedProcedure, parameters, null, 60, CommandType.StoredProcedure);
        }

        public IDbConnection GetDbconnection()
        {
            return new SqlConnection(_connectionStrings.DefaultConnectionString);
        }
    }
}  