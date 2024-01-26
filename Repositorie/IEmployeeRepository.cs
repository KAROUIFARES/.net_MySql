using MySql.Model;
namespace repositorie
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeeAsync();
    }
}