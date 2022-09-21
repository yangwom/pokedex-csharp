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

       public void Put (int id, dynamic fields);

       public void Remove(int id);

       public int GetNextIdValue();
    }
}
