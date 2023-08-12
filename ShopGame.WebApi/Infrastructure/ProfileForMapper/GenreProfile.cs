using AutoMapper;
using GameshopMini.ModelsDTO;
using ShopGame.DAL.Models;

namespace GameshopMini.Infrastructure.ProfileForMapper;

public class GenreProfile:Profile
{
    public GenreProfile()
    {
        CreateMap<GenreDTO, Genre>().
            ForMember(d => d.Id, opt =>
                opt.MapFrom(dd => dd.Id)).ReverseMap();
    }
}