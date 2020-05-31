using SisVenda.Domain.Base.Entities;
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

        [Required]
        [Column(TypeName = "char(150)")]
        public string Name { get; private set; }
        [Required]
        [Column(TypeName = "char(20)")]
        public string User { get; private set; }
        [Required]
        [Column(TypeName = "char(20)")]
        public string Password { get; private set; }
    }
}
