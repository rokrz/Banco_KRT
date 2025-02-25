using BancoKRT.Models;

namespace BancoKRT.Repositories
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task<Cliente> Buscar(string agencia, string conta);
        Task Deletar(string agencia, string conta);
    }
}
