using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokedex.Models;

namespace pokedex.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetPokemonsAsync();
        Task<Pokemon> GetPokemonByIdAsync(string id);
        Task<List<Pokemon>> GetPokemonByNameAsync(string name);
        Task<Pokemon> AddPokemonAsync(Pokemon newPokemon);
        Task<Pokemon> UpdatePokemonAsync(string id, Pokemon updatedPokemon);
        Task<bool> DeletePokemonAsync(string id);
    }
}
