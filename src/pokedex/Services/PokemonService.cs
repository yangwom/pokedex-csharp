using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly List<PokemonCatched>? _dbPokedex;


        public PokemonService(List<PokemonCatched> dbpokedex)
        {
            _dbPokedex = dbpokedex;
        }

        public PokemonCatched Add(PokemonCatched newPokemon)
        {

            _dbPokedex?.Add(newPokemon);
            return newPokemon;
        }
        public IEnumerable<PokemonCatched> GetAllItems()
        {
            var data = _dbPokedex.ToList();

            return data;
        }
        public PokemonCatched GetById(int id)
        {
            var data = _dbPokedex.Find(pokemon => pokemon.Id == id);

            return data;
        }
        public bool Put(int id, PokemonCatched newPokemon)
        {
            var pokemon = _dbPokedex.Find(p => p.Id == id);
            if (pokemon == null) return false;
            var index = _dbPokedex.IndexOf(pokemon);
            _dbPokedex[index] = newPokemon;
            return true;

        }
        public bool Remove(int id)
        {
            var pokemon = _dbPokedex.Find(p => p.Id == id);
            if (pokemon == null) return false;
            _dbPokedex.Remove(pokemon);
            return true;
        }
        public int GetNextIdValue()
        {
            return _dbPokedex.Count;
        }
    }
}
