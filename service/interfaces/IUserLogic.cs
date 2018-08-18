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

        Task<IEnumerable<UserDto>> GetAll();

        // Task<PetDto> GetFirstAsync();
         Task<UserDto> GetByIDAsync(int id);

         Task Update(updateUserReq model);
         Task Delete(object id);

         Task<User> DeActivateUser(object id);
         Task<User> UpdatePassword(changePasswordReq model);

        Task<SysUserDto> GetByUsernamePassword(LoginViewModel model);
    }

}