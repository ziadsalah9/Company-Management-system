﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }

        public IdepartmentRepository DepartmentRepository { get; set; }

         Task <int> CompleteAsync();

    }
}
