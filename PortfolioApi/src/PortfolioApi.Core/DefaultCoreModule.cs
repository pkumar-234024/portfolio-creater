﻿using Autofac;
using PortfolioApi.Core.Interfaces;
using PortfolioApi.Core.Services;

namespace PortfolioApi.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
