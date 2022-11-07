using Microsoft.Data.SqlClient;
using System.Data;
using YardScanAPI.Models;

namespace Yard_Scan_API.Services.UserService
{
    public class UserService : IUserService
    {
        public static string GetUser(SqlConnection sqlConnection, string userCode)
        {
            var username = string.Empty;
            var sql = "select top 1 username from users where code = @userCode";
            try
            {
                using var command = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                command.Parameters.Add("usercode", SqlDbType.NVarChar).Value = userCode;
                username = command.ExecuteScalar() == DBNull.Value ? null : command.ExecuteScalar().ToString();
            }
            catch (Exception)
            {

            }
            finally
            {
                if(sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return username;
        }
    }
}
