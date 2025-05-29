using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Features.MediatR.AdoptionRequests.Results;
using Application.Features.MediatR.AdoptionTrackings.Commands;
using Application.Features.MediatR.AdoptionTrackings.Results;
using Application.Features.MediatR.PetComments.Commands;
using Application.Features.MediatR.PetComments.Results;
using Application.Features.MediatR.PetFavorites.Commands;
using Application.Features.MediatR.PetFavorites.Results;
using Application.Features.MediatR.PetImages.Results;
using Application.Features.MediatR.PetLikes.Commands;
using Application.Features.MediatR.PetLikes.Results;
using Application.Features.MediatR.Pets.Commands;
using Application.Features.MediatR.Pets.Results;
using Application.Features.MediatR.PetTypes.Results;
using Application.Features.MediatR.Users.Commands;
using Application.Features.MediatR.Users.Results;
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
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName))
                .ForMember(dest => dest.UserSurname, opt => opt.MapFrom(src => src.User.Surname))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
                .ForMember(dest => dest.UserCreatedDate, opt => opt.MapFrom(src => src.User.CreatedDate))
                .ForMember(dest => dest.UserCity, opt => opt.MapFrom(src => src.User.City))
                .ForMember(dest => dest.UserDistrict, opt => opt.MapFrom(src => src.User.District))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PetLikeCount, opt => opt.MapFrom(src => src.PetLikes.Count()))
                .ForMember(dest => dest.UserImageUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl));
            CreateMap<Pet, GetAllPetByOwnerIdQueryResult>()
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName))
                .ForMember(dest => dest.RequestCount, opt => opt.MapFrom(src => src.AdoptionRequests.Count(r => r.DeletedDate == null)));
            CreateMap<Pet,GetAllActivePetByOwnerIdQueryResult>()
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName))
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.PetLikes.Count(l => l.DeletedDate == null)))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.PetComments.Count(c => c.DeletedDate == null)));
            CreateMap<Pet, GetAllAdoptedPetByOwnerIdQueryResult>()
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName));
            CreateMap<Pet, GetAllFilterPetQueryResult>()
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName))
                .ForMember(dest => dest.PetLike, opt => opt.MapFrom(src => src.PetLikes.Count()));
            CreateMap<Pet, GetFeaturedPetQueryResult>()
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.PetLikes.Count(c => c.DeletedDate == null)))
                .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName));

            //PetComment
            CreateMap<PetComment, CreatePetCommentCommand>().ReverseMap();
            CreateMap<PetComment, UpdatePetCommentCommand>().ReverseMap();
            CreateMap<PetComment, GetAllPetCommentByPetIdQueryResult>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name))
            .ForMember(dest => dest.UserImageUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId));

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
            CreateMap<AdoptionRequest, GetAllAdoptionRequestByPetIdQueryResult>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.Name))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.Name))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name));
            //CreateMap<AdoptionRequest, GetAllAdoptionRequestByUserIdQueryResult>()
            //    .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.Name))
            //    .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.Name))
            //    .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name));
            CreateMap<AdoptionRequest, GetAllAdoptionRequestQueryResult>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.Name))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.Name))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name));
            CreateMap<AdoptionRequest, GetByIdAdoptionRequestQueryResult>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.Name))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.Name))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name));
            CreateMap<AdoptionRequest, GetAllAdoptionRequestBySenderIdQueryResult>()
              .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name))
              .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.Name));
            CreateMap<AdoptionRequest, GetAllIncomingAdoptionByOwnerIdQueryResult>()
            .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name))
            .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.Name + " " + src.Sender.Surname))
            .ForMember(dest => dest.SenderImageUrl, opt => opt.MapFrom(src => src.Sender.ProfilePictureUrl))
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.Sender.UserId));

            //User
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserByAdminCommand>().ReverseMap();
            CreateMap<User, GetAllUserQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
            CreateMap<User, GetByIdUserQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
            CreateMap<User, GetByIdUserDetailsForAdminQueryResult>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));


            //AdoptionTracking
            CreateMap<AdoptionTracking,CreateAdoptionTrackingCommand>().ReverseMap(); 
            CreateMap<AdoptionTracking,UpdateAdoptionRequestCommand>().ReverseMap();
            CreateMap<AdoptionTracking, GetAllAdoptionTrackingQueryResult>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.AdoptionRequest.Owner.Name))
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.AdoptionRequest.Sender.Name))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.AdoptionRequest.Pet.Name));
            CreateMap<AdoptionTracking,GetByIdAdoptionTrackingQueryResult>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.AdoptionRequest.Owner.Name))
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.AdoptionRequest.Sender.Name))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.AdoptionRequest.Pet.Name));

            //FavoritePet
            CreateMap<PetFavorite, CreatePetFavoriteCommand>().ReverseMap();
            CreateMap<Pet,GetAllFavoritePetQueryResult>()
                 .ForMember(dest => dest.PetTypeName, opt => opt.MapFrom(src => src.PetType.PetTypeName))
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.PetLikes.Count(x => x.DeletedDate == null)))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.PetComments.Count(x => x.DeletedDate == null)));


            //PetType
            CreateMap<PetType,GetAllPetTypeQueryResult>().ReverseMap();

            //PetImage
            CreateMap<PetImage, GetPetImagesByPetIdQueryResult>().ReverseMap();
        }
    }
}
