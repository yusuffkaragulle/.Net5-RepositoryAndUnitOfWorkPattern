using System;
using Microsoft.AspNetCore.Mvc;
using RepositoryAndUnitOfWorkPattern.Data.Models;
using RepositoryAndUnitOfWorkPattern.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWorkPattern.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public EmployeeController(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() =>
            await _unitOfWork.GetRepository<Employee>().GetAllAsync();

        [HttpGet]
        public async Task<Employee> GetEmployeeByIdAsync(Guid id) =>
            await _unitOfWork.GetRepository<Employee>().GetAsync(id);

        [HttpPost]
        public async Task<int> AddEmployeeAsync(Employee newEmployee)
        {
            await _unitOfWork.GetRepository<Employee>().AddAsync(newEmployee);

            return await _unitOfWork.Save();
        }

        [HttpPut]
        public async Task<int> UpdateEmployeeAsync(Employee updateEmployee)
        {
            _unitOfWork.GetRepository<Employee>().Update(updateEmployee);

            return await _unitOfWork.Save();
        }

        [HttpDelete]
        public async Task<int> DeleteEmployeeAsync(Employee deleteEmployee)
        {
            _unitOfWork.GetRepository<Employee>().Delete(deleteEmployee);

            return await _unitOfWork.Save();
        }

        #endregion
    }
}
