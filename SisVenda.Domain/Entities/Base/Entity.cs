using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Domain.Base.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "");
            DtRegister = DateTime.Now;
        }

        [Key()]
        [Column(TypeName = "varchar(32)")]
        public string Id { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? DtDeleted { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime DtRegister { get; private set; }

        public void Delete()
        {
            DtDeleted = DateTime.Now;
        }
    }
}
