using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;

namespace pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            // inject the service into the controller
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var pokemons = await _pokemonService.GetPokemonsAsync();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPokemon(string id)
        {
            return Ok(await _pokemonService.GetPokemonByIdAsync(id));
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult> GetPokemonByName(string name)
        {
            var pokemon = await _pokemonService.GetPokemonByNameAsync(name);
            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult> AddPokemon(Pokemon newPokemon)
        {
            var pokemon = await _pokemonService.AddPokemonAsync(newPokemon);
            return Ok(pokemon);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdatePokemon(string id, Pokemon updatedPokemon)
        {
            var pokemon = await _pokemonService.UpdatePokemonAsync(id, updatedPokemon);
            return Ok(pokemon);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePokemon(string id)
        {
            var pokemon = await _pokemonService.DeletePokemonAsync(id);
            return NoContent();
        }
    }
}
