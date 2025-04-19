using Core.Dto;
using Core.Entidade;

namespace Core.Contracts;

public interface IPacienteService
{
    public bool LoginPaciente(LoginDto loginDto);
    public Paciente GetPacientePorId(int id);
}
