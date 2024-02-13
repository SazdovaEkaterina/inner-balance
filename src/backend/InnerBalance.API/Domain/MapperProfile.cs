using AutoMapper;
using InnerBalance.API.Domain.DTO;
using InnerBalance.API.Domain.Models;

namespace InnerBalance.API.Domain;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<YogaClass, YogaClassDto>();
        CreateMap<YogaClassDto, YogaClass>();
        
        CreateMap<Room, RoomDto>();
        CreateMap<RoomDto, Room>();
        
        CreateMap<Style, StyleDto>();
        CreateMap<StyleDto, Style>();
        
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        
        CreateMap<YogaStudent, YogaStudentDto>();
        CreateMap<YogaStudentDto, YogaStudent>();
        
        CreateMap<YogaTeacher, YogaTeacherDto>();
        CreateMap<YogaTeacherDto, YogaTeacher>();
    }
}