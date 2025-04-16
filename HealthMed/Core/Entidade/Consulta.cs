namespace Core.Entidade
{
    public class Consulta : Entidade
    {
        public int PacienteId { get; set; }
        public Paciente Customer { get; private set; }
        public int AgendaId { get; set; }
        public Agenda Agenda { get; private set; }
        public int MedicoId { get; set; }
        public Agenda Medico { get; private set; }
    }
}
