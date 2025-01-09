using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using pokedex.Models;
using pokedex.Options;
using pokedex.Services.MongoDB;

namespace pokedex.Services.MongoDB;

public class PokemonContext : MongoContext<Pokemon>, IPokemonContext
{
    public PokemonContext(IOptions<MongoDbOptions> options)
        : base(options, "pokemons") { }

    public async Task<List<Pokemon>> GetPokemonByNameAsync(string name)
    {
        return await (
            _collection.Find(
                Builders<Pokemon>.Filter.Regex(p => p.Name, new BsonRegularExpression($"/{name}/i"))
            )
        ).ToListAsync();
    }
}
