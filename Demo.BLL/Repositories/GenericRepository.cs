﻿using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MVCAppDbContext _dbContext;

        public GenericRepository(MVCAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T item)
        {
           await _dbContext.AddAsync(item);
        }

        public void Delete(T item)
        {
            _dbContext.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Employee))
            {
                return  (IEnumerable<T>) await _dbContext.Employees.Include(E=>E.Department).ToListAsync();
            }
              return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task <T> GetbyIdAsync(int id)
       => await _dbContext.Set<T>().FindAsync(id);

        public void Update(T item)
        {
            _dbContext.Update(item);
        }
    }
}
