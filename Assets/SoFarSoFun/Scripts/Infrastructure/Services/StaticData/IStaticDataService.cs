using StaticData;
using Window;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void LoadData();
        GameStaticData GameConfig();
        WindowConfig ForWindow(WindowTypeId windowTypeId);
    }
}