using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfChoice.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameOfCoice.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }
        [HttpGet("/game")]
        public IActionResult Index()
        {
            var games = _service.List();
            return new OkObjectResult(games);
        }
        [HttpPost("/game")]
        public IActionResult Create([FromBody]string name)
        {
            var game = new Game();
            game = _service.CreateGame();
            return new CreatedResult($"/game/{game.Id}", game);
        }

        [HttpGet("/game/{id}")]
        public IActionResult Get(string id)
        {
            var game = _service.Get(id);
            return new OkObjectResult(game);
        }
        [HttpPost("/game/{id}/play")]
        public IActionResult Play([FromRoute]string id, [FromForm]string playerName)
        {
            _service.Play(id, playerName);
            return new OkResult();
        }

        [HttpPost("/game/{id}/challenge")]
        public IActionResult Challenge([FromRoute]string id, [FromForm]string challengerName)
        {
            _service.Challenge(id, challengerName);
            return new OkResult();
        }

        [HttpPost("/game/{id}/play/{choice}")]
        public IActionResult Play([FromRoute]string id, [FromRoute]Choices.Choice choice, [FromForm]string playerName)
        {
            _service.Choose(id, playerName, choice);
            return new OkResult();
        }

        [HttpPost("/game/{id}/challenge/{choice}")]
        public IActionResult Challenge([FromRoute]string id, [FromRoute]Choices.Choice choice, [FromForm]string playerName)
        {
            _service.Choose(id, playerName, choice);
            return new OkResult();
        }

        [HttpGet("/game/{id}/winner")]
        public IActionResult Winner([FromRoute]string id)
        {
            var winner = _service.Winner(id);
            return new OkObjectResult(winner);
        }

    }
}