using AutoMapper;
using Contracts;
using Entites;
using Entites.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/Player")]
    [ApiController]
    public class PlayerController : ControllerBase  //派生类继承Base抽象类
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IRepositoryWapper repository, ILogger<PlayerController> logger, IMapper mapper) //构造函数注入仓储包装器和日志
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlayer()
        {
            try
            {
                var players = await _repository.Player.GetAllPlayer();
                var result = _mapper.Map<IEnumerable<PlayerDto>>(players);//泛型是映射目标→映射数据集
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpGet("{id}", Name ="PlayerId")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerById(id);
                if (player == null)
                {
                    return NotFound();
                }
                var result = _mapper.Map<PlayerDto>(player);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}/character")]
        public async Task<IActionResult> GetPlayerWithCharacter(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerWithCharacter(id);
                if (player == null)
                {
                    return NotFound();
                }
                var result = _mapper.Map<PlayerWithCharacterDto>(player);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
