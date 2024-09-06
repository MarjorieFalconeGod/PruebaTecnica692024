using Newtonsoft.Json;
using System.Text;
using WebAPI__Marjorie_Falcone_202496.Models;
namespace WebAPP_Marjorie_Falcone_202496.Service.Cliente
{
    public class ClienteServices: IClienteServices
    {
        private readonly HttpClient _httpClient;
        private readonly string APIBaseURL;
        private readonly string Controller = "Clientes";

        public ClienteServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            APIBaseURL = "https://localhost:44362";
            //APIBaseURL = Environment.GetEnvironmentVariable("APIBaseURL");


        }

        public async Task<List<WebAPI__Marjorie_Falcone_202496.Models.Cliente >> ConsultarTodos()
        {
            string url = $"{APIBaseURL}/{Controller}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List< WebAPI__Marjorie_Falcone_202496.Models.Cliente> Clientes = JsonConvert.DeserializeObject<List<WebAPI__Marjorie_Falcone_202496.Models.Cliente>>(responseBody);
                return Clientes;
            }

            throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");

        }



        public async Task<WebAPI__Marjorie_Falcone_202496.Models.Cliente> Actualizar(WebAPI__Marjorie_Falcone_202496.Models.Cliente Clientes)
        {
            string url = $"{APIBaseURL}/{Controller}";

            string jsonContent = JsonConvert.SerializeObject(Clientes);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        WebAPI__Marjorie_Falcone_202496.Models.Cliente ClienteActualizado = JsonConvert.DeserializeObject< WebAPI__Marjorie_Falcone_202496.Models.Cliente> (responseBody);

                        return ClienteActualizado;
                    }
                }
                throw new Exception("Error al actualizar el Cliente.");
            }
        }





        public async Task<WebAPI__Marjorie_Falcone_202496.Models.Cliente> ver(int codigo)
        {

            string url = $"{APIBaseURL}/{Controller}/{codigo}";

            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        WebAPI__Marjorie_Falcone_202496.Models.Cliente ageCliente = JsonConvert.DeserializeObject< WebAPI__Marjorie_Falcone_202496.Models.Cliente> (responseBody);
                        return ageCliente;
                    }
                }
                return null;
            }
        }

        public async Task<WebAPI__Marjorie_Falcone_202496.Models.Cliente> Crear(WebAPI__Marjorie_Falcone_202496.Models.Cliente Cliente)
        {
            string url = $"{APIBaseURL}/{Controller}";

            string jsonContent = JsonConvert.SerializeObject(Cliente);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        WebAPI__Marjorie_Falcone_202496.Models.Cliente ClienteActualizado = JsonConvert.DeserializeObject< WebAPI__Marjorie_Falcone_202496.Models.Cliente> (responseBody);

                        return ClienteActualizado;
                    }
                }
                throw new Exception("Error al actualizar el Cliente.");
            }
        }
    }
}
