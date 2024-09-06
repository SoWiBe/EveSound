using Facade.Abstractions.Repositories;
using Facade.Abstractions.Services.Music;
using Facade.Endpoints.MusicEndpoints;
using Facade.Errors;

namespace Facade.Infrastructure.Services.Music;

public class MusicService : IMusicService
{
    private readonly string MUSIC_SERVICE_API = "http://localhost:8080/api/v1/music";
    private readonly IApiRepository _apiRepository;
    
    public MusicService(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }

    public async Task<ErrorOr<GetMusicResponse>> GetMusic()
    {
        var url = MUSIC_SERVICE_API;
        var result = await _apiRepository.GetResponseAsync<IEnumerable<Common.Models.Music>>(url);

        var response = new GetMusicResponse
        {
            Musics = result.Value
        };
        
        return response;
    }

    public Task<ErrorOr<CreateMusicResponse>> CreateMusic(CreateMusicRequest request)
    {
        throw new NotImplementedException();
    }
}