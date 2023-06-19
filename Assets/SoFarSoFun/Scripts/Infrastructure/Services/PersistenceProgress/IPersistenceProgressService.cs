using Infrastructure.Services.PersistenceProgress.Player;

namespace Infrastructure.Services.PersistenceProgress
{
    public interface IPersistenceProgressService
    {
        PlayerData PlayerData { get; set; }
    }
}