using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PuppyPaws.Contracts;
using PuppyPaws.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PuppyPaws.InstagramApi
{
    public class InstagramPhotoService : IInstagramPhotoService
    {
        private static readonly Uri BaseURI = new Uri("https://api.instagram.com/");

        public async Task<Media[]> FindRecentMediaByTag(string tag, int count, InstagramContext context)
        {
            const string url = "/v1/tags/{0}/media/recent?count={1}&client_id={2}";

            var finalUrl = string.Format(url, tag, count, context.ClientId);

            var response = await PerformGet(finalUrl);

            string content = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(content);        

            var media = from item in json["data"]
                        let images = item["images"]
                        let thumbnail = images["thumbnail"]["url"]
                        let low = images["low_resolution"]["url"]
                        let standard = images["standard_resolution"]["url"]
                        select new Media()
                        {
                            Thumbnail = new Uri((string)thumbnail),
                            LowResolution = new Uri((string)low),
                            StandardResolution = new Uri((string)standard)
                        };

            return media.ToArray();
        }

        private Task<HttpResponseMessage> PerformGet(string resource)
        {
            var client = new HttpClient();

            var uri = new Uri(BaseURI, resource);

            return client.GetAsync(uri);
        }
    }
}
