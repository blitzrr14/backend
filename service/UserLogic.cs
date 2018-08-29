using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using service.interfaces;
using common.models;
using repository.interfaces;
using dal.models;
using webapi.Models;
using AutoMapper;
//using Microsoft.EntityFrameworkCore;

namespace service
{

    public class UserLogic : IUserLogic
    {

        private IRepository _repository;
        private IMapper _mapper;
        
        public UserLogic(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SysUserDto>> GetAll()
        {
            var listofuser = await _repository.GetAllAsync<SysUser>( i => i.OrderBy(o => o.CreatedAt), "person,UserRoles", null,null);
            if(listofuser != null)
            {
                var listOfUserDto =  _mapper.Map<IEnumerable<SysUser>,IEnumerable<SysUserDto>>(listofuser);
               return listOfUserDto;
       
            }
            return null;

        }

        public async Task<SysUserDto> GetByUsernamePassword(LoginViewModel model)
        {
            try
            {
                var user = await _repository.GetFirst<SysUser>(i=> i.Username == model.Username && i.Password == model.Password,null,"person,UserRoles");
                if(user!= null)
                {
                    var dto = _mapper.Map<SysUser,SysUserDto>(user);
                    return dto;
                }

                return null;
               
           
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }


        public async Task<SysUserDto> GetByIDAsync(int id)
        {
            var user = await _repository.GetFirst<SysUser>(i => i.Id == id,null,"person,UserRoles");
            if(user != null)
            {
                var userDto = _mapper.Map<SysUser,SysUserDto>(user);
          
                return userDto;
            }
            return null; 
           
        }


        public async Task Create(SysUserDto user)
        {
            var userContext = _mapper.Map<SysUserDto,SysUser>(user);
            
            userContext.UserRoles = new List<UserRole>();
            userContext.UserRoles.Add(
                new UserRole{
                    UserID = user.Id,
                    RoleID = 1
              }
            );
           // _repository.Create<UserRole>(userroles, userroles.CreatedBy);
            _repository.Create<SysUser>(userContext, userContext.CreatedBy);
             await _repository.SaveAsync();
        }

        public async Task Update(updateUserReq user)
        {
            var repo = await _repository.GetFirst<SysUser>(i => i.Id == user.Id,i=> i.OrderBy(o => o.CreatedAt),"person");
            
            var _person = _mapper.Map<PersonDto,Person>(user.person);
            repo.person = _person;
            repo.Username = user.Username;
    
            _repository.Update<SysUser>(repo);
             await _repository.SaveAsync();
        }

        public async Task<SysUser> UpdatePassword(changePasswordReq user)
        {
             var repo = await _repository.GetFirst<SysUser>(i => i.Password == user.Password && i.Username == user.Username,i=> i.OrderBy(o => o.CreatedAt),"person");
             
             if(repo != null)
             {
                repo.Password = user.NewPassword;            
                _repository.Update<SysUser>(repo);
                await _repository.SaveAsync();
             }
             return repo;
        }

        public async Task<SysUser> DeActivateUser(object id)
        {
            var result = await _repository.GetByIdAsync<SysUser>(id);
            if(result != null)
            {
                result.isActivate = 0;
                
              _repository.Update<SysUser>(result);
              await _repository.SaveAsync();
            
            }
            return result;

            
        }

        public async Task Delete(object id)
        {
            _repository.Delete<SysUser>(id);
             await _repository.SaveAsync();
        }

   

     
    }

}