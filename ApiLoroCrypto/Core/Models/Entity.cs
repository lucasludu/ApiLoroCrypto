using System.ComponentModel.DataAnnotations;

namespace ApiLoroCrypto.Core.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
