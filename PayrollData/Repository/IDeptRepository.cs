using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using PayrollModels.Models;

namespace PayrollData.Repository
{
    public interface IDeptRepository
    {
        public Task<List<Departments>> GetAllDepartments();

        public Task<Departments> GetDepartmentByIdAsync(int Id);

        public Task<int> AddDepartmentAsync(Departments depts);

        public Task UpdateDepartmentAsync(int Id, Departments depts);

        public Task DeleteDepartmentAsync(int Id);

        public Task UpdateDepartmentPatchAsync(int Id, JsonPatchDocument depts);
    }
}
