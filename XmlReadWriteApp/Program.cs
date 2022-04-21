﻿using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

// Config
const string CONFIG_FILE = "AppConfig/appsettings";
string base_dir = AppDomain.CurrentDomain.BaseDirectory;
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile($"{CONFIG_FILE}.development.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Data source path
string xmlSource = base_dir + configuration["XmlSources:Default"];

var xmlHandler = new XmlHandler(xmlSource);

IEnumerable<XElement> xmlWithRoot = xmlHandler.GetRootStructure();
string xmlRoot = xmlHandler.RootName.ToString();

Console.WriteLine($"\nXML Root <{xmlRoot ?? default}>:\n");
foreach (XElement key in xmlWithRoot)
    Console.WriteLine(key);
