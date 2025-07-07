using PokemonTabletopAdventures.Models.Indicies;
using PokemonTabletopAdventures.Web.Domain;

namespace PokemonTabletopAdventures.Web.Services
{
    public interface IIndexService
    {
        public Task<Response<IndexCollectionResponse>> GetPokemonFormsAsync(int offset, int limit);
        public Task<Response<IndexCollectionResponse>> GetBerriesAsync();
        public Task<Response<IndexCollectionResponse>> GetFeaturesAsync();
        public Task<Response<IndexCollectionResponse>> GetKeyItemsAsync();
        public Task<Response<IndexCollectionResponse>> GetMedicalItemsAsync();
        public Task<Response<IndexCollectionResponse>> GetPokeballsAsync();
        public Task<Response<IndexCollectionResponse>> GetPokemonItemsAsync();
        public Task<Response<IndexCollectionResponse>> GetTrainerItemsAsync();
        public Task<Response<IndexCollectionResponse>> GetMovesAsync();
        public Task<Response<IndexCollectionResponse>> GetTrainerClassesAsync();
        public Task<Response<IndexCollectionResponse>> GetOriginsAsync();

       public bool IsReady { get; }
    }
}
