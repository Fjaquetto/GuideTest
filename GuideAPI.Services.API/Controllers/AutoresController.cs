using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideAPI.Application.Interfaces;
using GuideAPI.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuideAPI.Services.API.Controllers
{
    [Route("api/autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresAppService _autoresAppService;

        public AutoresController(IAutoresAppService autoresAppService)
        {
            _autoresAppService = autoresAppService;
        }

        [HttpGet]
        public async Task<List<AutoresViewModel>> Get()
        {
            return await _autoresAppService.ObterTodos();
        }

        [HttpPost]
        public async Task<IActionResult> Post(IEnumerable<AutoresViewModel> autores)
        {
            await _autoresAppService.Adicionar(autores);

            return Ok();
        }
    }
}
