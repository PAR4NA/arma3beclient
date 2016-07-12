﻿using Arma3BE.Client.Infrastructure.Events.Models;
using Prism.Events;

namespace Arma3BE.Client.Infrastructure.Events
{
    public class CreateViewEvent<T> : PubSubEvent<CreateViewModel<T>>
    {
    }
}