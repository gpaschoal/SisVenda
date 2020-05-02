using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisVenda.Shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key()]
        public Guid Id { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? DtDeleted { get; private set; }
    }
}
