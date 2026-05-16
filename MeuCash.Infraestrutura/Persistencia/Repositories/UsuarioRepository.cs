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

        public async Task<Usuario> ConsultarUsuarioPeloNome(string nomeUsuario)
        {
            //TODO: Eduardo Matheus Vaz | 14/05 | Estrutura como vai ser (nome, username, e se vai trazer mais de um no caso de ter o nome igual)
            throw new NotImplementedException();
        }

        public async Task<Usuario> ConsultarUsuarioPorId(int id)
        {
            var usuario = await _dbContext.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return usuario;
        }

        public async Task<List<Usuario>> ConsultarUsuarios()
        {
            var usuarios = await _dbContext.Usuarios
                .AsNoTracking()
                .ToListAsync();

            return usuarios;
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
