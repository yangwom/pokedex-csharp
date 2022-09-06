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
        public PokemonsController()
        {
     
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<PokemonCatched>> Get()
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public ActionResult<PokemonCatched> GetById()
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public ActionResult Post()
        {
            throw new NotImplementedException();
        }

        
        [HttpPut]
        public ActionResult Put()
        {
            throw new NotImplementedException();
        }


        
        [HttpDelete]
        public ActionResult Remove()
        {
            throw new NotImplementedException();
        }
    }
}