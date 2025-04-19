using Core.Dados;
using Core.Dto;
using Core.Entidade;

namespace Core.Services;

public class PacienteService(CoreDbContext context)
{
    public bool LoginPaciente(LoginDto loginDto)
    {
        bool isLoginValido = false;

        isLoginValido = context.Pacientes.Any(x => (x.Cpf == loginDto.Usuario || x.Email == loginDto.Usuario) &&
                        x.Senha == loginDto.Senha);

        return isLoginValido;
    }

    public Paciente GetPacientePorId(int id) =>
         context.Pacientes.FirstOrDefault(x => (x.Codigo == id));
}
