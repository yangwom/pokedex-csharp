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
        public bool Put(int id, PokemonCatched newPokemon)
        {
            var pokemon = _pokemon.Find(p => p.Id == id);
            if (pokemon == null) return false;
            var index = _pokemon.IndexOf(pokemon);
            _pokemon[index] = newPokemon;
            return true;

        }
        public bool Remove(int id)
        {
            var pokemon = _pokemon.Find(p => p.Id == id);
            if (pokemon == null) return false;
            _pokemon.Remove(pokemon);
            return true;
        }

        public int GetNextIdValue()
        {
            return _pokemon.Count;
        }
    }
}