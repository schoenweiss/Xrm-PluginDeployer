# Xrm.Plugin.Deployer

This tool automates and simplifies the deployment of assemblies, its plugins / workflows, all its steps and images for Microsoft Dynamics 365 / Dynamics CRM in a multi system landscape. It is based on [PowerArgs](https://github.com/adamabdelhamed/PowerArgs) and supports four different scenarios currently.

## Options
```
Usage - Xrm.PluginDeployer -options

GlobalOption              Description
AssemblyPath* (-A)        Path to assembly dll
SourceSystem (-S)         Connection string to source system. If this string is given, the Plugins, Steps and Images
                          will be synchronized.
DestinationSystem* (-D)   Connection string to the destination system.
Sync (-Sy)                Syncs steps and images. (Old) steps will be deleted [Default='False']
Create (-C)               Creates assembly, its plugins, steps and images in destination system [Default='False']
Prefix (-P)               If Sync was set to true a solution will be created. Choose prefix of this solution here.
                          [Default='PluginDeployer']
Publisher (-Pu)           Publisher needed to create and transport solution [Default='microsoftdynamics']
```

## Scenarios
1. Creation of all assembly related plugins, all steps and all images based on custom [attribute class](https://docs.microsoft.com/en-us/dotnet/api/system.attribute?view=netframework-4.8) decorator. :heart_eyes:
```Bash
Xrm.PluginDeployer.exe -A "pathToAssembly/Assembly.dll" -D "connectionStringToCRMDestinationSystem" -C true
```
2. Update of plugin assembly only. This option also creates new Plugins of updated assembly (default execution). :smiley:
```Bash
Xrm.PluginDeployer.exe -A "pathToAssembly/Assembly.dll" -D "connectionStringToCRMDestinationSystem"
```
3. Update of plugin assembly and synchronisation of its plugins. This will also delete all plugins which are not present in local plugin project anymore. :open_mouth:
```Bash
Xrm.PluginDeployer.exe -A "pathToAssembly/Assembly.dll" -D "connectionStringToCRMDestinationSystem" -Sy true
```
4. Update of plugin assembly and synchronisation of its plugins, steps and images. This will be done by solution transport from source- to destination-system. :fearful:
```Bash
Xrm.PluginDeployer.exe -A "pathToAssembly/Assembly.dll" -D "connectionStringToCRMDestinationSystem" -Sy true -S "connectionStringToCRMSourceSystem" -Pu "XrmPublisher" -P "XrmPluginDeployer"
```

## Credits
[Kjeld Ingemann Poulsen - dynamics-plugin](https://github.com/kip-dk/dynamics-plugin)

