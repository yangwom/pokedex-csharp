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
        public void Put (int id, dynamic fields)
        {
          var data = _dbPokedex.Find(pokemon => pokemon.Id == id);
          var index = _dbPokedex.IndexOf(data);
          _dbPokedex[index] = fields;

        }
        public void Remove(int id)
        {
         var data = _dbPokedex!.Find(pokemon => pokemon.Id == id);
    
          _dbPokedex.Remove(data);

        }

           public int GetNextIdValue()
        {
            return _dbPokedex.Count;
        }
    }
    }
