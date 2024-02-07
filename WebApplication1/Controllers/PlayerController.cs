using AutoMapper;
using Contracts;
using Entites;
using Entites.Dtos;
using Entites.ReponseType.DataShaping;
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/Player")]
    [ApiController]
    public class PlayerController : ControllerBase  //派生类继承Base抽象类
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;

        public PlayerController(IRepositoryWapper repository, ILogger<PlayerController> logger, IMapper mapper) //构造函数注入仓储包装器、日志和映射
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayer([FromQuery] PlayerParameter parameter)
        {
            if (!parameter.ValidDataCreatedRange) 
            {
                return BadRequest("开始日期不能大于结束日期！");
            }

            try
            {
                var players = await _repository.Player.GetPlayer(parameter);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(players.MetaData));

                var result = _mapper.Map<IEnumerable<PlayerDto>>(players)//泛型是映射目标→映射数据集
                    .ShapeData(parameter.Fields);  //对结果进行构型
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpGet("{id}", Name = "PlayerById")]
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
        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerForCreationDto player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求数据");
                }
                var playEntity = _mapper.Map<Player>(player);
                _repository.Player.Create(playEntity);
                await _repository.Save();

                var createPlayer = _mapper.Map<PlayerDto>(playEntity);
                return CreatedAtRoute(routeName: "PlayerById", routeValues: new //调用其他路由返回
                {
                    id = createPlayer.Id
                }, value: createPlayer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpPut(template: "{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] PlayerForUpdateDto player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("无效的请求数据");
                }
                var playEntity = await _repository.Player.GetPlayerById(id);
                if (playEntity is null)
                {
                    return NotFound("待修改的玩家不存在");
                }
                _mapper.Map(player, playEntity);
                _repository.Player.Update(playEntity);
                await _repository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            try
            {
                var player = await _repository.Player.GetPlayerWithCharacter(id);
                if (player is null)
                {
                    return BadRequest("该玩家不存在");
                }
                if (player.Characters.Any())
                {
                    return NotFound("该玩家有关联人物角色，不能删除！！");
                }
                _repository.Player.Delete(player);
                await _repository.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return StatusCode(500);
            }
        }


    }
}
