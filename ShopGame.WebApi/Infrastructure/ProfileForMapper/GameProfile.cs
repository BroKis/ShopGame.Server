using AutoMapper;
using GameshopMini.ModelsDTO;
using ShopGame.DAL.Models;

namespace GameshopMini.Infrastructure.ProfileForMapper;

public class GameProfile:Profile
{
    public GameProfile()
    {
        CreateMap<GameDTO, Game>().
            ForMember(d => d.Id, opt =>
                opt.MapFrom(dd => dd.Id))
            .ReverseMap();
    }
}