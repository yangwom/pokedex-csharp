using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pokemon.Test
{
    public class PokemonServiceFake : IPokemonService
    {
        private readonly List<PokemonCatched> _pokemon;
        public PokemonServiceFake()
        {
            _pokemon = new List<PokemonCatched>()
            {                
                             
            };
        }

        public PokemonCatched Add()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PokemonCatched> GetAllPokemons()
        {
            throw new NotImplementedException();
        }

        public PokemonCatched GetById()
        {
            throw new NotImplementedException();
        }

        public void Put()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}