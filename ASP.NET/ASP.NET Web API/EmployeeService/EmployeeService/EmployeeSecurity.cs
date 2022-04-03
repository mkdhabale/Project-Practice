using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                return entities.Users1.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}