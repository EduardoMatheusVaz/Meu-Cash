using MeuCash.Application.DTOs.Input_Models;
using MeuCash.Application.DTOs.View_Models;
using MeuCash.Application.Services.Interfaces;
using MeuCash.Core.Entidades;
using MeuCash.Core.Repositories;

namespace MeuCash.Application.Services.Implementacoes
{
    public class EntradaService : IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;

        public EntradaService(IEntradaRepository entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

        public async Task<EntradaDetalhesViewModel> ConsultarEntradaPeloId(int id)
        {
            var entrada = await _entradaRepository.ConsultarEntradaPeloId(id: id);

            var entradaViewModel = new EntradaDetalhesViewModel
                (
                    id: entrada.Id, 
                    idConta: entrada.IdConta, 
                    valor: entrada.Valor, 
                    data: entrada.Data, 
                    descricao: entrada.Descricao
                );

            return entradaViewModel;
        }

        public async Task<List<EntradasViewModel>> ConsultarEntradasPeloIdConta(int idConta)
        {
            var entradas = await _entradaRepository.ConsultarEntradasPelaConta(idConta: idConta);

            var entradasViewModel = entradas.Select(x => new EntradasViewModel(
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return entradasViewModel;
        }

        public async Task<List<EntradasViewModel>> ConsultarEntradas()
        {
            var entradas = await _entradaRepository.ConsultarEntradas();

            var entradasViewModel = entradas.Select(x => new EntradasViewModel(
                id: x.Id,
                idConta: x.IdConta,
                valor: x.Valor,
                data: x.Data
            )).ToList();

            return entradasViewModel;
        }

        public async Task CriarEntrada(EntradaInputModel entradaInputModel)
        {
            var novaEntrada = new Entrada
                (
                    idConta: entradaInputModel.IdConta,
                    valor: entradaInputModel.Valor,
                    data: entradaInputModel.Data,
                    descricao: entradaInputModel.Descricao
                );
            
            await _entradaRepository.CriarEntrada(entrada: novaEntrada);
        }
    }
}
