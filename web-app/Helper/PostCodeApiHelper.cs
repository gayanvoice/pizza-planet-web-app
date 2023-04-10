using web_app.Models.Api;

namespace web_app.Helper
{
    public static class PostCodeApiHelper
    {
        public static async Task<PostcodeApiModel?> GetFromPostCodesIo(string postCode)
        {
            string apiEndpoint = $"https://api.postcodes.io/postcodes/{postCode}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<PostcodeApiModel>(content);
                }
                else
                {
                    return new PostcodeApiModel();
                }
            }
        }
       
    }
}
