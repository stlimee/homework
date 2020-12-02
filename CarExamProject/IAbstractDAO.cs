using System;
using System.Data;

namespace CarExamProject
{
    interface IAbstractDAO
    {
        IDbConnection GetConnection();
        void ReleaseConnection(IDbConnection connection);
    }
}
