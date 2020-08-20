using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context){
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync(){

            return await _context.Department.OrderBy(x => x.Name)
                                      .ToListAsync();
        }

    }
}