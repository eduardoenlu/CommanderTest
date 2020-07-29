using System;
using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CommandsController(ICommanderRepo repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        // private readonly MockCommanderRepo _Repo = new MockCommanderRepo();

        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            // var results = _repository.GetAppCommands();
            return Ok(_configuration.GetConnectionString("AgendaElectronicaDB"));
            // return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(results));
        }

        // [HttpGet("{id}", Name="GetCommandById")]
        // public ActionResult <CommandReadDto> GetCommandById(int id)
        // {
        //     var result = _repository.GetCommandById(id);
        //     if(result != null)
        //     {
        //         return Ok(_mapper.Map<CommandReadDto>(result));
        //     }
        //     return NotFound();
        // }

        [HttpGet("{id}", Name="GetCommandBySPId")]
        public ActionResult <CommandReadDto> GetCommandBySPId(int id)
        {
            var result = _repository.GetCommandBySPId(id);
            
            // ICommanderRepo mysql = new MySqlCommanderRepo(SqlHerramienta.Conectar(_configuration.GetConnectionString("AgendaElectronicaDB")));
            
            // var result = mysql.GetCommandByMysqlId(id);
            if(result != null)
            {
                // return Ok(_mapper.Map<CommandReadDto>(result));
                return Ok(result);
            }
            return NotFound();
            

            
        }

        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto cmd)
        {
            var commandModel = _mapper.Map<Command>(cmd);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            // return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
            return Ok(_mapper.Map<CommandReadDto>(commandModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDto)
        {   
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDto.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

             _mapper.Map(commandToPatch, commandModelFromRepo);

             _repository.UpdateCommand(commandModelFromRepo);

             _repository.SaveChanges();

             return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
             var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
