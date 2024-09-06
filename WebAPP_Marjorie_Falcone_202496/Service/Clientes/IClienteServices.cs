using WebAPI__Marjorie_Falcone_202496.Models;

namespace WebAPP_Marjorie_Falcone_202496.Service.Clientes
{
    public interface IClienteServices
    {
        Task<List<Cliente>> ConsultarTodos();
        Task<Cliente> Actualizar(Cliente cliente );
        Task<Cliente> ver(int codigo);
        Task<Cliente> Crear(Cliente cliente );
    }
}
