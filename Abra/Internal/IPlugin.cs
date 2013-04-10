﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abra.Internal
{
    internal interface IPlugin
    {
        Binding GetInjectBinding(string key, string className, bool mustBeInjectable);
        Binding GetLazyInjectBinding(string key, object requiredBy, string lazyKey);
        RuntimeModule GetRuntimeModule(Type moduleType, object moduleInstance);
    }
}
