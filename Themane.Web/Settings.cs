﻿using Microsoft.Extensions.Configuration;
using System;

namespace Themane.Web
{
#pragma warning disable CS1591
  public static class Settings
  {
    public static string LOG_CONNECTION_STRING(IConfiguration config) => Environment.GetEnvironmentVariable("LOG_CONNECTION_STRING") ?? config["Log:ConnectionString"];

    public static string DATASTORE_CONNECTION(IConfiguration config) => Environment.GetEnvironmentVariable("DATASTORE_CONNECTION") ?? config["RepositoryDatabase:Connection"];
    public static string DATASTORE_CONNECTION_TYPE(IConfiguration config, string connection) => Environment.GetEnvironmentVariable("DATASTORE_CONNECTION_TYPE") ?? config[$"RepositoryDatabase:{connection}:Type"];
    public static string DATASTORE_CONNECTION_STRING(IConfiguration config, string connection) => (Environment.GetEnvironmentVariable("DATASTORE_CONNECTION_STRING") ?? config[$"RepositoryDatabase:{connection}:ConnectionString"]);
  }
#pragma warning restore CS1591
}
