using Microsoft.AspNetCore.Mvc;
using RepositoryAndUnitOfWorkPattern.Data.Models;
using RepositoryAndUnitOfWorkPattern.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWorkPattern.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public DepartmentController(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync() =>
            await _unitOfWork.GetRepository<Department>().GetAllAsync();

        [HttpGet]
        public async Task<Department> GetDepartmentByIdAsync(Guid id) =>
            await _unitOfWork.GetRepository<Department>().GetAsync(id);

        [HttpPost]
        public async Task<int> AddDepartmentAsync(Department newDepartment)
        {
            await _unitOfWork.GetRepository<Department>().AddAsync(newDepartment);

            return await _unitOfWork.Save();
        }

        [HttpPut]
        public async Task<int> UpdateDepartmentAsync(Department updateDepartment)
        {
            _unitOfWork.GetRepository<Department>().Update(updateDepartment);

            return await _unitOfWork.Save();
        }

        [HttpDelete]
        public async Task<int> DeleteDepartmentAsync(Department deleteDepartment)
        {
            _unitOfWork.GetRepository<Department>().Delete(deleteDepartment);

            return await _unitOfWork.Save();
        }

        #endregion
    }
}
