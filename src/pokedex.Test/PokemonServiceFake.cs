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
                new PokemonCatched() { Id = 0, Name = "Ifarnaipe"  },
                new PokemonCatched() { Id = 1, Name = "chalizart" },         
            };
        }

          public PokemonCatched Add(PokemonCatched newPokemon)
        {

          _pokemon?.Add(newPokemon);
          return newPokemon;
        }
        public IEnumerable<PokemonCatched> GetAllItems()
        {
         var data = _pokemon!.ToList();

         return data;
        }
        public PokemonCatched GetById(int id)
        {
         var data = _pokemon!.Find(pokemon => pokemon.Id == id);
         
         return data;
        }
        public void Put (int id, dynamic fields)
        {
          var data = _pokemon!.Find(pokemon => pokemon.Id == id);
          
          var index = _pokemon.IndexOf(data);
          _pokemon[index] = fields;

        }
        public void Remove(int id)
        {
         var data = _pokemon.Find(pokemon => pokemon.Id == id);
          _pokemon.Remove(data);

        }

           public int GetNextIdValue()
        {
            return _pokemon.Count;
        }
    }
}