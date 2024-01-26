using MySql.Data.MySqlClient;
using MySql.Model;
using repositorie;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly string DbName = "Test";
        private static readonly string TableName = "employee";
        private static readonly string EmployeeId = "employeeId";
        private static readonly string EmployeeName = "employeeName";
        private static readonly string DepartementName = "DepartementName";
        private static readonly string Salary = "salary";
        private string sqlDataSource;
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            sqlDataSource = configuration.GetConnectionString("EmployeeAppCon");

        }
        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            string query = "SELECT " + EmployeeId + "," + EmployeeName + "," + Salary + "," + DepartementName + " FROM " + DbName + "." + TableName;
            List<Employee> employees = new List<Employee>();
            using (MySqlConnection connection = new MySqlConnection(sqlDataSource))
            {
                await connection.OpenAsync();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new Employee
                            {
                                EmployeeId = Convert.ToInt32(reader[EmployeeId]),
                                EmployeeName = reader[EmployeeName].ToString(),
                                Salary = Convert.ToInt32(reader[Salary]),
                                DepartmentName = reader[DepartementName].ToString()
                            });
                        }
                    }
                }
            }
            return employees;
        }
    }
}