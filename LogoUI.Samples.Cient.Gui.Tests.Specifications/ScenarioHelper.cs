﻿using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications
{
    static class ScenarioHelper
    {
        private const string RootObjectFactoryKey = "rootObjectFactory";
        private const string RootObjectKey = "rootObject";
        private const string ContainerKey = "container";

        internal static void Initialize(
            IIocContainer iocContainer,
            IRootObjectFactory rootObjectFactory)
        {
            ScenarioContext.Current.Add(ContainerKey, iocContainer);
            ScenarioContext.Current.Add(RootObjectFactoryKey, rootObjectFactory);
        }

        internal static void CreateRootObject()
        {
            var rootObjectFactory = (IRootObjectFactory)ScenarioContext.Current[RootObjectFactoryKey];
            ScenarioContext.Current.Add(RootObjectKey, rootObjectFactory.CreateRootObject());            
        }        

        internal static void Clear()
        {
            ScenarioContext.Current.Clear();
        }

        internal static object Container
        {
            get { return ScenarioContext.Current[ContainerKey]; }
        }

        internal static object RootObject
        {
            get { return ScenarioContext.Current[RootObjectKey]; }
        }
    }
}