using pokedex.Models;

namespace pokedex.Services.MongoDB;

public interface IPokemonContext : IMongoContext<Pokemon>
{
    // pokemon specific methods
    Task<List<Pokemon>> GetPokemonByNameAsync(string name);
}
