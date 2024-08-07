using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

//using Azure;
using Microsoft.EntityFrameworkCore;
using PayrollModels.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace PayrollData.Repository
{
    public class DeptRepository :IDeptRepository
    {
        PayrollManagementContext _context;
        public DeptRepository(PayrollManagementContext context) {
            _context = context;
        }

        public async Task<List<Departments>> GetAllDepartments()
        {
            var records = await _context.Depatments.Select(u => new Departments()
            {
                Id = u.Id,
                dName=u.dName
            }).ToListAsync();
            return records;
        }

        public async Task<Departments> GetDepartmentByIdAsync(int Id)
        {
            var records = await _context.Depatments.Where(u => u.Id == Id).Select(u => new Departments()
            {
                Id = u.Id,
                dName = u.dName,
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<int> AddDepartmentAsync(Departments depts)
        {
            var dept = new Departments()
            {
                Id = depts.Id,
                dName=depts.dName,
            };
            _context.Depatments.Add(dept);
            await _context.SaveChangesAsync();
            return dept.Id;
        }

        public async Task UpdateDepartmentAsync(int Id, Departments depts)
        {
            var dept = await _context.Depatments.FindAsync(Id);
            if (dept != null)
            {
                //dept.Id = depts.Id;
                dept.dName = depts.dName;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int Id)
        {
            var dept = new Departments()
            {
                Id = Id
            };
            _context.Depatments.Remove(dept);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentPatchAsync(int Id, JsonPatchDocument depts)
        {
            var dept = await _context.Depatments.FindAsync(Id);
            if (dept != null)
            {
                depts.ApplyTo(dept);
                await _context.SaveChangesAsync();
            }
        }
    }
}
