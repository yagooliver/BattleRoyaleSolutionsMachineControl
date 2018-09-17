﻿using CommonServiceLocator;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleRoyaleSolutions.IOC
{
    public class SimpleInjectorServiceLocatorAdapter : IServiceLocator
    {
        private readonly Container container;
        public SimpleInjectorServiceLocatorAdapter(Container container)
        {
            this.container = container;
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return this.container.GetAllInstances(typeof(TService)).Cast<TService>();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            IServiceProvider serviceProvider = this.container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var collection = (IEnumerable<object>)serviceProvider.GetService(collectionType);
            return collection ?? Enumerable.Empty<object>();
        }

        public TService GetInstance<TService>(string key)
        {
            return (TService)this.GetInstance(typeof(TService));
        }

        public TService GetInstance<TService>()
        {
            return (TService)this.container.GetInstance(typeof(TService));
        }

        public object GetInstance(Type serviceType, string key)
        {
            return this.GetInstance(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return this.container.GetInstance(serviceType);
        }

        public object GetService(Type serviceType)
        {
            IServiceProvider serviceProvider = this.container;
            return serviceProvider.GetService(serviceType);
        }
    }
}