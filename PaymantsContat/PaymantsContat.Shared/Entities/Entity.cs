using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace PaymantsContat.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        protected Entity() 
        {
            Id = Guid.NewGuid();
        }
    }
}