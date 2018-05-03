﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Events
{
    public interface IEventHandler<in TEvent>
        where TEvent :IEvent
    {
        void Handle(TEvent @event);
    }
}
