using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.Models;
using Commander.Data;
using AutoMapper;
using Commander.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers
{

    [Route("api/commands")]

    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));

        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));

            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO cmd)
        {
            var commandModel = _mapper.Map<Command>(cmd);
            _repository.CreateCommnad(commandModel);
            _repository.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDTO.Id }, commandReadDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {

            var commandModel = _repository.GetCommandId(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            //Map(From, To)
            _mapper.Map(commandUpdateDTO, commandModel);

            _repository.UpdateCommand(commandModel);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]

        public ActionResult UpdateCommandPatch(int id, JsonPatchDocument<CommandUpdateDTO> patchdoc)
        {
            var commandModel = _repository.GetCommandId(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModel);

            patchdoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {

                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModel);

            _repository.UpdateCommand(commandModel);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteCommand(int id)
        {
            var commandModel = _repository.GetCommandId(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModel);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}