using Newtonsoft.Json;
using System.Text;
using WebAPI__Marjorie_Falcone_202496.Models;

namespace WebAPP_Marjorie_Falcone_202496.Service.Clientes
{
    public class ClienteServices: IClienteServices
    {
        private readonly HttpClient _httpClient;
        private readonly string APIBaseURL;
        private readonly string Controller = "Clientes";

        public ClienteServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            APIBaseURL = Environment.GetEnvironmentVariable("APIBaseURL");


        }

        public async Task<List<Cliente>> ConsultarTodos()
        {
            string url = $"{APIBaseURL}/{Controller}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Cliente> Clientes = JsonConvert.DeserializeObject<List<Cliente>>(responseBody);
                return Clientes;
            }

            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");

        }



        public async Task<Cliente> Actualizar(Cliente Clientes)
        {
            string url = $"{APIBaseURL}/{Controller}";
            string jsonContent = JsonConvert.SerializeObject(Clientes);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Cliente ClienteActualizado = JsonConvert.DeserializeObject< Cliente> (responseBody);
                return ClienteActualizado;
            }
            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        public async Task<Cliente> ver(int codigo)
        {

            string url = $"{APIBaseURL}/{Controller}/{codigo}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Cliente Clientes = JsonConvert.DeserializeObject<Cliente>(responseBody);
                return Clientes;
            }

            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        public async Task<Cliente> Crear(Cliente Cliente)
        {
            string url = $"{APIBaseURL}/{Controller}";

            string jsonContent = JsonConvert.SerializeObject(Cliente);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Cliente ClienteActualizado = JsonConvert.DeserializeObject< Cliente> (responseBody);

                return ClienteActualizado;
            }
            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");

        }
    }
}
