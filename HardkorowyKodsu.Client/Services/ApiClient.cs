using HardkorowyKodsu.Client.Services.Interfaces;
using Refit;

namespace HardkorowyKodsu.Client.Services
{
    public static class ApiClient
    {
        public static IDatabaseApiService CreateClient(string baseUrl)
        {
            return RestService.For<IDatabaseApiService>(baseUrl);
        }
    }
}
