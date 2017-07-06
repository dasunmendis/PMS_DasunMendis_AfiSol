using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Entities;

namespace PMS_DAL.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly PMSDBContext _context = new PMSDBContext();

        private GenericRepository<Employee> _employeeRepository;
        private GenericRepository<Designation> _designationRepository;

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                    this._employeeRepository = new GenericRepository<Employee>(_context);
                return _employeeRepository;
            }
        }

        public GenericRepository<Designation> DesignationRepository
        {
            get
            {
                if (this._designationRepository == null)
                    this._designationRepository = new GenericRepository<Designation>(_context);
                return _designationRepository;
            }
        }
                        
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
