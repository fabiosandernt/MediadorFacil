
namespace MediadorFacil.Domain.SeedWorks
{
    public class Entity<T>    
    {
        public T Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        
    }
}
