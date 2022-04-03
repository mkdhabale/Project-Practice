using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.CustomAuthentication
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                return entities.ASP_NETWebAPI_Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}