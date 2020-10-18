using System.Collections.Generic;
using System.Data;

namespace Euromonitor.DataHelper.Interfaces
{
    public interface IDapperService
    {
        List<T> Query<T>(string storedProcedure, object parameters = null);

        T QuerySingle<T>(string storedProcedure, object parameters = null);

        int Execute(string storedProcedure, object parameters = null);

        IDbConnection GetDbconnection();
    }
}
