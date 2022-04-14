using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Data;
using SampleWebApp.Dtos;
using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SampleWebApp.Controllers
{
    [Route(template:"api")]
    [ApiController]
    public class RetroController: Controller
    {
        private readonly IRetroRepository _repository;
        public RetroController(IRetroRepository repository)
        {
            _repository = repository;
        }
        [HttpGet(template:"getretros")]
        public IActionResult GetRetro()
        {
            List <Retro>  retro = _repository.GetRetro();
            return Ok(retro);
        }

        [HttpGet(template: "getretronames")]
        public IActionResult GetRetroNames()
        {
            List<string> retroNames = _repository.GetRetroNames();
            return Ok(retroNames);
        }

        [HttpPost(template: "getretrosbydate")]
        public IActionResult GetRetroByDate(GetByDateDto dto)
        {
            List<Retro> retro = _repository.GetRetroByDate(dto.Date);
            return Ok(retro);
        }

        [HttpPost(template:"addretro")]
        public IActionResult AddRetro(AddRetroDto dto)
        {
            if (String.IsNullOrEmpty(dto.Date) || dto.PName.Count == 0) return BadRequest("One of the field is Empty");
            if (_repository.IsRetroNameExist(dto.RName)) return BadRequest("Duplicate Retrospective names not allowed");
            Retro retro = new Retro
            {
                RName = dto.RName,
                Date = dto.Date,
                PName = dto.PName,
                Summary = dto.Summary
            };
            return Created("Success", _repository.AddRetro(retro));
        }

        [HttpPost(template: "addfeedback")]
        public IActionResult AddFeedback(AddFeedbackDto dto)
        {
            Feedback feedback = new Feedback
            {
                PName = dto.PName,
                RName = dto.RName,
                Body = dto.Body,
                Type = dto.Type
            };
            return Created("Success", _repository.AddFeedBack(feedback));
        }
    }
}
