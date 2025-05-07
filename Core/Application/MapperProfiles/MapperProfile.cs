using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Features.MediatR.PetComments.Commands;
using Application.Features.MediatR.PetComments.Results;
using Application.Features.MediatR.PetLikes.Commands;
using Application.Features.MediatR.PetLikes.Results;
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

            //Pet
            CreateMap<Pet,CreatePetCommand>().ReverseMap();
            CreateMap<Pet,UpdatePetCommand>().ReverseMap();
            CreateMap<Pet, GetAllPetQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName));
            CreateMap<Pet, GetByIdPetQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName));

            //PetComment
            CreateMap<PetComment, CreatePetCommentCommand>().ReverseMap();
            CreateMap<PetComment, UpdatePetCommentCommand>().ReverseMap();
            CreateMap<PetComment, GetAllPetCommentByPetIdQueryResult>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name));

            //PetLike
            CreateMap<PetLike, CreatePetLikeCommand>().ReverseMap();
            CreateMap<PetLike, UpdatePetLikeCommand>().ReverseMap();
            CreateMap<PetLike, GetAllPetLikeByPetIdQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));
            CreateMap<PetLike, GetAllPetLikeByUserIdQueryResult>()
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name));

            //AdoptionRequest
            CreateMap<AdoptionRequest, CreateAdoptionRequestCommand>().ReverseMap();
            CreateMap<AdoptionRequest, UpdateAdoptionRequestCommand>().ReverseMap();


        }
    }
}
