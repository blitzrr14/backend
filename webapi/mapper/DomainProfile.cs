

using System.Collections.Generic;
using AutoMapper;
using common.models;
using dal.models;

public class DomainProfile : Profile
{
	public DomainProfile()
	{
		CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
        CreateMap<updateUserReq, User>();
		CreateMap<SysUserDto, SysUser>();
		//CreateMap<SysUser, SysUserDto>();

		CreateMap<PersonDto, Person>();
		CreateMap<Person, PersonDto>();
		CreateMap<AddressDto, Address>();
		CreateMap<Address, AddressDto>();

		CreateMap<UserRole,UserRoleDto>().ReverseMap();

		CreateMap<SysUser, SysUserDto>()
                .ForMember(d => d.UserRoles, m => m.MapFrom(s => s.UserRoles));

	
	}
}