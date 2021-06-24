using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using CSharp_CallStarWarsAPIAssignment.Models;

namespace CSharp_CallStarWarsAPIAssignment.BusinessLogic
{
    public class CharacterBL
    {
        public async Task<List<StarWarsCharacterModel>> GetListOfAllCharacterInfo()
        {            
            string url = $"http://localhost:8086/api/StarWarsCharacters/";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var jsonString = response.Content.ReadAsStringAsync().Result;

                    List<StarWarsCharacterModel> starWarsCharacters = JsonConvert.DeserializeObject<List<StarWarsCharacterModel>>(jsonString, settings);                  

                    return starWarsCharacters;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<StarWarsCharacterModel> GetCharacterInfoByName(string name)
        {
            string url = $"http://localhost:8086/Api/StarWarsCharacters/GetCharacterByName?name={name}";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var jsonString = response.Content.ReadAsStringAsync().Result;

                    StarWarsCharacterModel starWarsCharacter = JsonConvert.DeserializeObject<StarWarsCharacterModel>(jsonString, settings);

                    return starWarsCharacter;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<StarWarsCharacterModel>> GetListOfCharacterInfoByAllegiance(string allegiance)
        {
            string url = $"http://localhost:8086/Api/StarWarsCharacters/GetCharactersByAllegiance/?allegiance={allegiance}";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var jsonString = response.Content.ReadAsStringAsync().Result;

                    List<StarWarsCharacterModel> starWarsCharacters = JsonConvert.DeserializeObject<List<StarWarsCharacterModel>>(jsonString, settings);

                    return starWarsCharacters;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<StarWarsCharacterModel>> GetListOfCharacterInfoByTrilogy(string trilogy)
        {
            string url = $"http://localhost:8086/Api/StarWarsCharacters/GetCharactersByTrilogy/?trilogy={trilogy}";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var jsonString = response.Content.ReadAsStringAsync().Result;

                    List<StarWarsCharacterModel> starWarsCharacters = JsonConvert.DeserializeObject<List<StarWarsCharacterModel>>(jsonString, settings);

                    return starWarsCharacters;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
