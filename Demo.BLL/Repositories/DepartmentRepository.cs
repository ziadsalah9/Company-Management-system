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
    public class DepartmentRepository : GenericRepository<Department>, IdepartmentRepository
    {

        private MVCAppDbContext _dbcontext;

        public DepartmentRepository(MVCAppDbContext dbContext):base(dbContext) 
        {
           // _dbcontext = dbContext;
        }

        //    private MVCAppDbContext _dbcontext;

        //    public DepartmentRepository(MVCAppDbContext dbContext)
        //    {
        //        _dbcontext = dbContext;
        //    }

        //    public int Add(Department department)
        //    {
        //        _dbcontext.Add(department);
        //        return _dbcontext.SaveChanges();
        //    }

        //    public int Delete(Department department)
        //    {
        //        _dbcontext.Remove(department);
        //        return _dbcontext.SaveChanges();
        //    }

        //    public IEnumerable<Department> GetAll()       
        //    =>_dbcontext.Departments.ToList();


        //    public Department GetById(int id)
        //    {
        //        //var department = _dbcontext.Departments.Local.Where(D=>D.Id==id).FirstOrDefault();
        //        //if (department is null)         
        //        //    _dbcontext.Departments.Where(D => D.Id == id).FirstOrDefault();
        //        //return department;

        //        return _dbcontext.Departments.Find(id);

        //    }

        //    public int Update(Department department)
        //    {
        //       _dbcontext.Update(department);
        //        return _dbcontext.SaveChanges();
        //    }
     }
}
