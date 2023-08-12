using AutoMapper;
using GameshopMini.ModelsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopGame.DAL.Models;
using ShopGame.DAL.Repository.Interfaces;

namespace GameshopMini.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameApiController : ControllerBase
{
    private IGameRepository _gameRepository;
    
    private IMapper _mapper;

    public GameApiController(IGameRepository gameRepository,IMapper mapper)
    {
        _gameRepository = gameRepository;
        
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> CreateGameRecord(GameDTO game)
    {
        try
        {
            var reverseMapped = _mapper.Map<Game>(game);
            var signal = await _gameRepository.Insert(reverseMapped);
            if (signal)
            {
                return Ok();
            }

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDTO>>> GetGames()
    {
        try
        {
            var mapped = await _gameRepository.GetAll();
            var reversedMapped = _mapper.Map<List<GameDTO>>(mapped);
            return reversedMapped;
        }
        catch (Exception e)
        {
            return  NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDTO>> GetGameById(int id)
    {
        try
        {
            var mapped = await _gameRepository.GetID(id);
            if (mapped != null)
            {
                 var reverseMapped = _mapper.Map<GameDTO>(mapped);
                            return reverseMapped;
            }

            return NotFound();

        }
        catch (Exception e)
        {
            return NotFound();
        }
        
    }
    
    [HttpPut]
    public async Task<ActionResult<bool>> UpdateGame(GameDTO game)
    {
        var mapped = _mapper.Map<Game>(game);
        var resp = await _gameRepository.Update(mapped);
        if (resp)
            return Ok();
        return NoContent();
    }
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudio(int id)
    {
        var resp = await _gameRepository.Delete(id);
        if (resp)
            return Ok();
        return NotFound();
    }
        

    
    private bool GameExist(int id)
    {
        return (_gameRepository.GetAll().Result?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}