using WebAPI__Marjorie_Falcone_202496.Models;

namespace WebAPP_Marjorie_Falcone_202496.Service.Cliente
{
    public interface IClienteServices
    {
        Task<List<WebAPI__Marjorie_Falcone_202496.Models.Cliente >> ConsultarTodos();


        Task<WebAPI__Marjorie_Falcone_202496.Models.Cliente > Actualizar(WebAPI__Marjorie_Falcone_202496.Models.Cliente cliente );


        Task<WebAPI__Marjorie_Falcone_202496.Models.Cliente > ver(int codigo);
        Task<WebAPI__Marjorie_Falcone_202496.Models.Cliente > Crear(WebAPI__Marjorie_Falcone_202496.Models.Cliente cliente );
    }
}
