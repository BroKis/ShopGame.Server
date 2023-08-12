using AutoMapper;
using GameshopMini.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using ShopGame.DAL.Models;
using ShopGame.DAL.Repository.Interfaces;

namespace GameshopMini.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderApiController:ControllerBase
{
    private IOrderRepository _orderRepository;
    private IMapper _mapper;

    public OrderApiController(IMapper mapper, IOrderRepository repository)
    {
        _mapper = mapper;
        _orderRepository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Create(OrderDTO order)
    {
        try
        {
            var reversed = _mapper.Map<Order>(order);
            var resp = await _orderRepository.Insert(reversed);
            if (resp)
                return Ok();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest();
        }

      
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAll()
    {
        try
        {
            var data = await _orderRepository.GetAll();
            var mapped = _mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }
        catch (Exception e)
        {
            return BadRequest();
        }

      
    }
    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrderByUserId(int userId)
    {
        try
        {
            var mapped = await _orderRepository.GetByUserId(userId);
            if (mapped != null)
            {
                var reverseMapped = _mapper.Map<List<OrderDTO>>(mapped);
                return reverseMapped;
            }
    
            return NotFound();
    
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
}