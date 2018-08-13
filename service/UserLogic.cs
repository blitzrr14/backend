using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using service.interfaces;
using common.models;
using repository.interfaces;
using dal.models;
using webapi.Models;
//using Microsoft.EntityFrameworkCore;

namespace service
{

    public class UserLogic : IUserLogic
    {

        private IRepository _repository;
        
        public UserLogic(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listofuser = await _repository.GetAllAsync<User>( i => i.OrderBy(o => o.Created), "address,role", null,null);
            if(listofuser != null)
            {
                var listofpetDto = listofuser.Select(user => new UserDto 
                {
                    fullname = user.fullname,
                    address = new AddressDto 
                    {
                        street = user.address.street,
                        city = user.address.city,
                        zipcode = user.address.zipcode,
                        Id = user.Id
                    },
                    Id = user.Id,
                    Username = user.Username,
                    isActivate = user.isActivate,
                    role = new RoleDto 
                    {
                        Id = user.Id,
                        name = user.role.name
                    }
                });
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
                     var dto = new UserDto
                    {
                        Username = user.Username,
                        Password = user.Password,
                        role = new RoleDto 
                        {
                            name = user.role.name
                        }
                    };
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
                var userDto = new UserDto 
                {
                    fullname = user.fullname,
                    address = new AddressDto 
                    {
                        street = user.address.street,
                        city = user.address.city,
                        zipcode = user.address.zipcode,
                        Id = user.Id
                    },
                    Id = user.Id,
                    Username = user.Username,
                    isActivate = user.isActivate,
                    role = new RoleDto 
                    {
                        Id = user.Id,
                        name = user.role.name
                        
                    }

                };
                return userDto;
            }
            return null; 
           
        }


        public async Task Create(UserDto user)
        {
            var userContext = new User
            {
              fullname = user.fullname,
                address = new Address 
                {
                    street = user.address.street,
                    city = user.address.city,
                    zipcode = user.address.zipcode,
                    Id = user.address.Id
                },
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                role = new Role 
                {
                    name = user.role.name
                }
            };
            _repository.Create<User>(userContext, userContext.CreatedBy);
             await _repository.SaveAsync();
        }

        public async Task Update(updateUserReq user)
        {

            var userDto = new User
            {
                fullname = user.fullname,
                address = new Address 
                {
                    street = user.address.street,
                    city = user.address.city,
                    zipcode = user.address.zipcode,
                    Id = user.address.Id
                },
                Id = user.Id,
                Username = user.Username,

            };
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