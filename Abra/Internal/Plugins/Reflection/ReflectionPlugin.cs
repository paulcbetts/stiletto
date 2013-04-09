﻿using System;

namespace Abra.Internal.Plugins.Reflection
{
    internal sealed class ReflectionPlugin : IPlugin
    {
        public Binding GetInjectBinding(string key, string className, bool mustBeInjectable)
        {
            Type t;

            try {
                t = Type.GetType(className, true);
            }
            catch (TypeLoadException exception) {
                throw new ArgumentException("Failed to load the type '" + className + "'.", exception);
            }

            if (t.IsInterface)
            {
                return null;
            }

            return ReflectionInjectBinding.Create(t, mustBeInjectable);
        }

        public RuntimeModule GetRuntimeModule(Type moduleType, object moduleInstance)
        {
            var attr = moduleType.GetSingleAttribute<ModuleAttribute>();

            if (moduleType.BaseType != typeof(object))
            {
                throw new ArgumentException("Modules must inherit only from System.Object.");
            }

            return new ReflectionRuntimeModule(moduleType, attr);
        }
    }
}