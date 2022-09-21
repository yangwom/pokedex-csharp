using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public interface IPokemonService
    {
       public PokemonCatched Add(PokemonCatched newPokemon);
       public IEnumerable<PokemonCatched> GetAllItems();

       public PokemonCatched? GetById(int id);

       public bool Put (int id, PokemonCatched newPokemon);

       public bool Remove(int id);

       public int GetNextIdValue();
    }
}
