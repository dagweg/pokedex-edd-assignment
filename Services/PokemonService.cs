using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokedex.Models;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        // In-memory list of pokemons (will get replaced by a database)
        static List<Pokemon> pokemons = new List<Pokemon>()
        {
            new Pokemon()
            {
                Id = "1",
                Name = "Pikachu",
                Type = "Electric",
                Ability = "Static",
                Level = 50,
            },
            new Pokemon()
            {
                Id = "2",
                Name = "Charmander",
                Type = "Fire",
                Ability = "Blaze",
                Level = 50,
            },
            new Pokemon()
            {
                Id = "3",
                Name = "Squirtle",
                Type = "Water",
                Ability = "Torrent",
                Level = 50,
            },
            new Pokemon()
            {
                Id = "4",
                Name = "Bulbasaur",
                Type = "Grass",
                Ability = "Overgrow",
                Level = 50,
            },
        };

        public async Task<List<Pokemon>> GetPokemonsAsync()
        {
            await Task.CompletedTask; // delete when using actual db call

            return pokemons;
        }

        public async Task<Pokemon> GetPokemonByIdAsync(string id)
        {
            await Task.CompletedTask; // delete when using actual db call

            var pokemon = pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon == null)
            {
                throw new Exception("Pokemon not found");
            }
            return pokemon;
        }

        public async Task<Pokemon> GetPokemonByNameAsync(string name)
        {
            await Task.CompletedTask; // delete when using actual db call

            var pokemon = pokemons.FirstOrDefault(pokemon => pokemon.Name == name);
            if (pokemon == null)
            {
                throw new Exception("Pokemon not found");
            }
            return pokemon;
        }

        public async Task<Pokemon> AddPokemonAsync(Pokemon newPokemon)
        {
            await Task.CompletedTask; // delete when using actual db call

            Guid id = Guid.NewGuid();
            newPokemon.Id = id.ToString();

            pokemons.Add(newPokemon);

            return newPokemon;
        }

        public async Task<Pokemon> UpdatePokemonAsync(string id, Pokemon updatedPokemon)
        {
            await Task.CompletedTask; // delete when using actual db call

            var index = pokemons.FindIndex(pokemon => pokemon.Id == id);
            if (index == -1)
            {
                throw new Exception("Pokemon not found");
            }
            pokemons[index] = updatedPokemon;
            return updatedPokemon;
        }

        public async Task<bool> DeletePokemonAsync(string id)
        {
            await Task.CompletedTask; // delete when using actual db call

            var pokemon = pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon == null)
            {
                throw new Exception("Pokemon not found");
            }
            pokemons.Remove(pokemon);
            return true;
        }
    }
}
