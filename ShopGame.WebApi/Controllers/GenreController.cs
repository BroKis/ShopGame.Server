using AutoMapper;
using GameshopMini.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using ShopGame.DAL.Repository.Interfaces;

namespace GameshopMini.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreApiController:ControllerBase
{
    private IGenreRepository _genreRepository;
    private IMapper _mapper;
    
    public GenreApiController(IGenreRepository genreRepository,
         IMapper mapper)
    {
       
        _genreRepository = genreRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GenreDTO>>> GetGenres()
    {
        try
        {
            var data = await _genreRepository.GetAll();
            var mapped = _mapper.Map<List<GenreDTO>>(data);
            return mapped;
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
}