using MediadorFacil.Domain.InstrumentoColetivo;
using MediadorFacil.Domain.SeedWorks;

namespace MediadorFacil.Domain.Account
{
    public class Empresa : Entity<Guid>
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }       
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Sindicato> Sindicatos { get; set; } = new List<Sindicato>();
    }
}
