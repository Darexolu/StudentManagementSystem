﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

using System.Linq.Expressions;

namespace StudentsManagement.Repository
{
    public class SystemCodeRepository : ISystemCodeRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<SystemCode> AddAsync(SystemCode mod)
        {
            if (mod == null) return null;

            var data = _context.SystemCodes.Add(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }


        public async Task<SystemCode> DeleteAsync(int id)
        {
            var data = await _context.SystemCodes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.SystemCodes.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<SystemCode>> GetAllAsync()
        {
            var data = await _context.SystemCodes.ToListAsync();

            return data;
        }

        public async Task<SystemCode> GetByIdAsync(int id)
        {
            var data = await _context.SystemCodes.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<SystemCode> UpdateAsync(SystemCode mod)
        {
            if (mod == null) return null;

            var data = _context.SystemCodes.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }


    }
}