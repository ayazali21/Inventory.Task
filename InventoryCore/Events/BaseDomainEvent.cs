﻿using MediatR;
using System;
namespace InventoryCore.Events
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}

