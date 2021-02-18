using System;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Domain
{
   public class Entity
   {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}