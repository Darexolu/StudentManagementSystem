﻿using StudentManagementSystem.Shared.Models;
using StudentsManagementShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagementShared.StudentRepository
{
    public interface ICountryRepository
    {
        Task<Country> AddAsync(Country mod);
        Task<Country> UpdateAsync(Country mod);
        Task<Country> DeleteAsync(int id);
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
    }
}