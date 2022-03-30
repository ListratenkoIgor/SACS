using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SACS_Server.Data.Entities;

namespace SACS_Server.Data.Repositories
{
    public class DepartmentsRepository: RepositoryBase<Department>
    {
        public DepartmentsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { }
    }
}