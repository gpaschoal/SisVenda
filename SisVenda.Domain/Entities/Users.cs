using SisVenda.Shared.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Entities
{
    public class Users : Entity
    {
        public Users(string name, string user, string password)
        {
            Name = name;
            User = user;
            Password = password;
        }

        [Column(TypeName = "char(150)")]
        [Required]
        public string Name { get; private set; }
        [Column(TypeName = "char(20)")]
        [Required]
        public string User { get; private set; }
        [Column(TypeName = "char(20)")]
        [Required]
        public string Password { get; private set; }
    }
}
