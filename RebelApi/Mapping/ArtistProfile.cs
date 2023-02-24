using Api.Models;
using AutoMapper;
using Core.Entities;

namespace API.Mappings
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistViewModel>();
            CreateMap<ArtistInputModel, Artist>();

        }
    }
}
