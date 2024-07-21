namespace ProtivitiTest.WebAPI.Services.AvatarService
{
    public class AvatarService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AvatarService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GetAvatarAsync(string fullName)
        {
            try
            {
                string avaratBaseUri = _config["AvaratBaseUri"];
                string uri = $"{avaratBaseUri}?name={Uri.EscapeDataString(fullName)}&format=svg";
                var response = await _httpClient.GetStringAsync(uri);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

