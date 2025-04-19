using Core.Dados;
using Core.Dto;
using Core.Entidade;

namespace Core.Services;

public class MedicoService(CoreDbContext context)
{
    public List<Medico> GetMedicosPorFiltro(string filtro) =>
         [.. context.Medicos.Where(x => x.Nome == filtro || x.Nome == filtro)];

    public List<Medico> GetTodosMedicos() =>
        [.. context.Medicos];

    public bool LoginMedico(LoginDto loginDto)
    {
        bool isLoginValido = false;

        isLoginValido = context.Medicos.Any(x => x.Crm == loginDto.Usuario && x.Senha == loginDto.Senha);

        return isLoginValido;
    }
}
