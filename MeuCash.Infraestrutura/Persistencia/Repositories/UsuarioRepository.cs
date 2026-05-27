using MeuCash.Core.DTOs;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeuCash.Infraestrutura.Persistencia.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MeuCashDbContext _dbContext;

        public UsuarioRepository(MeuCashDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            await _dbContext.SaveChangesAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UsuariosDTO>> ConsultarUsuarioPeloNome(string nomeUsuario)
        {

            nomeUsuario.ToLower().Normalize();



            throw new NotImplementedException();
        }

        public async Task<Usuario> ConsultarUsuarioPeloId(int id)
        {
            var usuario = await _dbContext.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return usuario;
        }

        public async Task<List<UsuariosDTO>> ConsultarUsuarios()
        {
            var usuarios = await _dbContext.Usuarios
                .AsNoTracking()
                .ToListAsync();

            var usuariosDTO = usuarios.Select(x => new UsuariosDTO(
                id: x.Id,
                nome: x.Nome,
                email: x.Email,
                numeroCelular: x.NumeroCelular
            )).ToList();

            return usuariosDTO;
        }

        public async Task DeletePeloId(int id)
        {
            //TODO: Eduardo Matheus Vaz | 14/05 | Estrutura como vai ser no caso de delete para não apagar demais objetos no banco
        }

        public async Task UpdatePeloId(int id, string nome, string username, string senha, string email, string numeroCelular)
        {
            var usuario = await _dbContext.Usuarios
                .SingleOrDefaultAsync(x => x.Id == id);

            usuario.AtualizarUsuario(
                nome: nome,
                username: username,
                senha: senha,
                email: email,
                numeroCelular: numeroCelular);

            await _dbContext.SaveChangesAsync();
        }
    }
}
