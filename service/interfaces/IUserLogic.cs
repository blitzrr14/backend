using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.models;
using dal.models;
using webapi.Models;

namespace service.interfaces 
{

    public interface IUserLogic
    {
      //  Task<IEnumerable<Customer>> GetSearchScreen(DateTime? startDate, DateTime? endDate, string search);

        Task Create(SysUserDto model);

        Task<IEnumerable<SysUserDto>> GetAll();

        // Task<PetDto> GetFirstAsync();
         Task<SysUserDto> GetByIDAsync(int id);

         Task Update(updateUserReq model);
         Task Delete(object id);

         Task<SysUser> DeActivateUser(object id);
         Task<SysUser> UpdatePassword(changePasswordReq model);

        Task<SysUserDto> GetByUsernamePassword(LoginViewModel model);
    }

}