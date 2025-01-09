using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokedex.Models;
using pokedex.Services.MongoDB;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonContext _pokemonContext;

        public PokemonService(IPokemonContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }

        public async Task<List<Pokemon>> GetPokemonsAsync()
        {
            try
            {
                return await _pokemonContext.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Pokemon> GetPokemonByIdAsync(string id)
        {
            try
            {
                var pokemon = await _pokemonContext.GetAsync(id);
                if (pokemon == null)
                {
                    throw new KeyNotFoundException("Pokemon not found");
                }
                return pokemon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Pokemon>> GetPokemonByNameAsync(string name)
        {
            try
            {
                var pokemon = await _pokemonContext.GetPokemonByNameAsync(name);
                if (pokemon == null)
                {
                    throw new KeyNotFoundException("Pokemon not found");
                }
                return pokemon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Pokemon> AddPokemonAsync(Pokemon newPokemon)
        {
            try
            {
                newPokemon.Id = Guid.NewGuid().ToString();

                await _pokemonContext.CreateAsync(newPokemon);

                return newPokemon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Pokemon> UpdatePokemonAsync(string id, Pokemon updatedPokemon)
        {
            try
            {
                var pokemon = await _pokemonContext.GetAsync(id);
                if (pokemon is null)
                {
                    throw new KeyNotFoundException("Pokemon not found");
                }
                pokemon.Id = updatedPokemon.Id ?? pokemon.Id;
                pokemon.Name = updatedPokemon.Name ?? pokemon.Name;
                pokemon.Type = updatedPokemon.Type ?? pokemon.Type;
                pokemon.Ability = updatedPokemon.Ability ?? pokemon.Ability;
                pokemon.Level = updatedPokemon.Level ?? pokemon.Level;

                await _pokemonContext.UpdateAsync(id, pokemon);

                return pokemon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> DeletePokemonAsync(string id)
        {
            try
            {
                var pokemon = await _pokemonContext.DeleteAsync(id);
                if (pokemon is false)
                {
                    throw new KeyNotFoundException("Pokemon not found");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
