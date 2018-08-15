

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
	}
}