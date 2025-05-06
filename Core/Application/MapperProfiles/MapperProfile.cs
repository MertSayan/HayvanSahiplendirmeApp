using Application.Features.MediatR.PetComments.Commands;
using Application.Features.MediatR.Pets.Commands;
using Application.Features.MediatR.Pets.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Pet,CreatePetCommand>().ReverseMap();
            CreateMap<Pet,UpdatePetCommand>().ReverseMap();
            CreateMap<Pet, GetAllPetQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName));
            CreateMap<Pet, GetByIdPetQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName));

            CreateMap<PetComment, CreatePetCommentCommand>().ReverseMap();
            CreateMap<PetComment, UpdatePetCommentCommand>().ReverseMap();




        }

        
    }
}
