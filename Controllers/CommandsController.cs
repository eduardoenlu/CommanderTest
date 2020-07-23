using System;
using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        private readonly MockCommanderRepo _Repo = new MockCommanderRepo();

        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var results = _repository.GetAppCommands();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var result = _repository.GetCommandById(id);

            return Ok(result);
        }
    }
}
