using Facade.Abstractions.Errors;
using Facade.Endpoints.MusicEndpoints;
using Facade.Errors;

namespace Facade.Abstractions.Services.Music;

public interface IMusicService
{
    Task<ErrorOr<GetMusicResponse>> GetMusic();
    Task<ErrorOr<CreateMusicResponse>> CreateMusic(CreateMusicRequest request);
    Task<IErrorOr> DeleteMusic(DeleteMusicRequest request);
}