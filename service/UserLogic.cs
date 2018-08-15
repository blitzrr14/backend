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


        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listofuser = await _repository.GetAllAsync<User>( i => i.OrderBy(o => o.Created), "address,role", null,null);
            if(listofuser != null)
            {
                var listofpetDto = listofuser.Select(user => _mapper.Map<User,UserDto>(user));
               return listofpetDto;
       
            }
            return null;

        }

        public async Task<UserDto> GetByUsernamePassword(LoginViewModel model)
        {
            try
            {
                var user = await _repository.GetFirst<User>(i=> i.Username == model.Username && i.Password == model.Password,null,"role");
                if(user!= null)
                {
                    var dto = _mapper.Map<User,UserDto>(user);
                    return dto;
                }

                return null;
               
           
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }


        public async Task<UserDto> GetByIDAsync(int id)
        {
             
            
            var user = await _repository.GetFirst<User>(i => i.Id == id,i=> i.OrderBy(o => o.Created),"role,address");
            if(user != null)
            {
                var userDto = _mapper.Map<User,UserDto>(user);
                return userDto;
            }
            return null; 
           
        }


        public async Task Create(UserDto user)
        {
            var userContext = _mapper.Map<UserDto,User>(user);
            _repository.Create<User>(userContext, userContext.CreatedBy);
             await _repository.SaveAsync();
        }

        public async Task Update(updateUserReq user)
        {
            var userDto = _mapper.Map<updateUserReq,User>(user);
            _repository.Update<User>(userDto);
             await _repository.SaveAsync();
        }

        public async Task<User> UpdatePassword(changePasswordReq user)
        {

             var repo = await _repository.GetFirst<User>(i => i.Password == user.Password && i.Username == user.Username,i=> i.OrderBy(o => o.Created),"role,address");
             
             if(repo != null)
             {
                repo.Password = user.NewPassword;            
                _repository.Update<User>(repo);
                await _repository.SaveAsync();
             }

             return repo;
            
        }

        public async Task<User> DeActivateUser(object id)
        {
            var result = await _repository.GetByIdAsync<User>(id);
            if(result != null)
            {
                result.isActivate = 0;
                
              _repository.Update<User>(result);
              await _repository.SaveAsync();
            
            }
            return result;

            
        }

        public async Task Delete(object id)
        {
            _repository.Delete<User>(id);
             await _repository.SaveAsync();
        }
        
    }

}