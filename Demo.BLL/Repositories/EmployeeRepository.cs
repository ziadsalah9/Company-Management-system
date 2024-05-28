using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {

        private readonly MVCAppDbContext _dbContext;

        public EmployeeRepository(MVCAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> SearchEmployeeByName(string SearchValue)
        {
            return _dbContext.Employees.Where(E => E.Name.ToLower().Contains(SearchValue.ToLower()));
        }









        // private readonly MVCAppDbContext _dbContext;

        // public EmployeeRepository(MVCAppDbContext dbContext)
        // {
        //    _dbContext = dbContext;
        // }

        // public int Add(Employee employee)
        // {
        //     _dbContext.Add(employee);
        //     return _dbContext.SaveChanges();
        // }

        // public int Delete(Employee employee)
        // {
        //     _dbContext.Remove(employee);
        //     return _dbContext.SaveChanges();
        // }

        // public IEnumerable<Employee> GetAll()
        //=> _dbContext.Employees.ToList();

        // public Employee GetById(int id)
        //=> _dbContext.Employees.Find(id);

        // public int Update(Employee employee)
        // {
        //     _dbContext.Update(employee);
        //     return _dbContext.SaveChanges();
        // }

    }

}

