using AutoMapper;
using GameshopMini.ModelsDTO;
using ShopGame.DAL.Models;

namespace GameshopMini.Infrastructure.ProfileForMapper;

public class OrderProfile:Profile
{
    public OrderProfile()
    {
        CreateMap<OrderDTO, Order>().
            ForMember(d => d.Id, opt =>
                opt.MapFrom(dd => dd.Id)).ReverseMap();
    }
}