using pokedex.Models;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace pokedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly IPokemonService _service;

        public PokemonsController(IPokemonService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PokemonCatched>> Get()
        {
            var result = _service.GetAllItems();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<PokemonCatched> GetById(int id)
        {
           
                var result = _service.GetById(id);
                if (result == null) return NotFound();
                return Ok(result);
         }
        

        [HttpPost]
        public ActionResult Post(PokemonCatched request)
        {
            if (request.Id == null) return BadRequest();
            var result = _service.Add(request);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, PokemonCatched newPokemon)
        {
            var result = _service.Put(id, newPokemon);
            if (!result) return NotFound();
            return Ok();
        }



        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            bool result = _service.Remove(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}