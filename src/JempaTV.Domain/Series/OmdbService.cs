using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JempaTV.Series
{
    public class OmdbService : ISerieApiService
    {

        private static readonly string apiKey = "b059b513";
        private static readonly string omdbUrl = "http://www.omdbapi.com/";
        private int id = 0;

        public async Task<ICollection<SerieDto>> GetSeriesAsync(string title, string gender)
        {

            try
            {
                using HttpClient client = new HttpClient();

                //Formamos la url con los datos
                string url = $"{omdbUrl}?s={title}&apikey={apiKey}&type=series";

                //Obtenemos la respuesta de forma asincrona
                var response = await client.GetAsync(url);

                //Pasamos la respuesta a un JSON
                string jsonResponse = await response.Content.ReadAsStringAsync();

                //Deserializamos el JSON a un Objeto
                var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(jsonResponse);

                //Finalmente obtenemos la lista de series similares
                var omdbSeriesList = searchResponse?.List ?? new List<omdbSerie>();

                var matchedSeries = new List<SerieDto>();

                foreach (var serie in omdbSeriesList)
                {
                    //Asignacion de Ids
                    id = id + 1;
                    matchedSeries.Add(new SerieDto { Title = serie.Title, Id = id });
                }

                return matchedSeries;

            }
            catch (HttpRequestException e)
            {

                throw new Exception("Error al acceder a los datos de la API: ", e);
            }

        }

        private class SearchResponse
        {
            [JsonProperty("Search")]
            public List<omdbSerie> List { get; set; }
        }

        private class omdbSerie
        {
            public String Title { get; set; }

            public String Genero { get; set; }

            public DateTime LastModification { get; set; }

            public DateTime Year { get; set; }

            public String Director { get; set; }

            public String Actors { get; set; }

            public String Plot { get; set; }

            public String Poster { get; set; }

            public float Imdb { get; set; }
        }

    }
}
