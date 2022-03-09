using Black_Mesa_HRMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Services
{
    public class EmployeeFormService
    {
        DataContext _context;
        public EmployeeFormService( DataContext context)
        {
            _context = context;
        }

        public List<Nationality> GetNationalities()
        {
            List<Nationality> nationalitiesBase = _context.Nationalities.ToList();
            return nationalitiesBase;
        }
        public List<Sector> GetSectors()
        {
            List<Sector> sectorBase = _context.Sectors.ToList();
            return sectorBase;
        }
        public List<Department> GetDepartments(int? sectorID)
        {
            List<Department> departments = _context.Departments.Where(x => x.Sector.Id == sectorID).ToList();
            return departments;
        }

        public List<Job> GetJobs(int? departmentId)
        {
            List<Job> jobs = _context.Jobs.Where(x => x.DepartmentId == departmentId).ToList();
            return jobs;
        }

        public List<JobPosition> GetJobPositions(int? jobId )
        {
            List<JobPosition> jobPositions = _context.JobPositions.Include(x => x.Position).Where(y => y.JobId == jobId).ToList();
            return jobPositions;
        }
    }
}
