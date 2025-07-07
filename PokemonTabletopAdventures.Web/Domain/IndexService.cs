using PokemonTabletopAdventures.Models.Indicies;
using PokemonTabletopAdventures.Web.Constants;

namespace PokemonTabletopAdventures.Web.Domain;

internal class IndexService(IConfiguration configuration) : AbstractService(configuration, string.Empty), IIndexService
{
    public Task<Response<IndexCollectionResponse>> GetBerriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetFeaturesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetKeyItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetMedicalItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetMovesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetOriginsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetPokeballsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Response<IndexCollectionResponse>> GetPokemonFormsAsync(int offset, int limit)
    {
        return await SendAsync<IndexCollectionResponse>($"{Routes.PokemonForms}?offset={offset}&limit={limit}", HttpMethod.Get);
    }

    public Task<Response<IndexCollectionResponse>> GetPokemonItemsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetTrainerClassesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<IndexCollectionResponse>> GetTrainerItemsAsync()
    {
        throw new NotImplementedException();
    }

    public bool IsReady => IsReadyInternal;
}
