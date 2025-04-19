using Core.Dto;
using Core.Entidade;

namespace Core.Contracts;

public interface IMedicoService
{
    public List<Medico> GetMedicosPorFiltro(string filtro);
    public List<Medico> GetTodosMedicos();
    public bool LoginMedico(LoginDto loginDto);
}
