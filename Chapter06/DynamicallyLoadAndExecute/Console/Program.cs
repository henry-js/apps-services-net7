Assembly? thisAssembly = Assembly.GetEntryAssembly();
if (thisAssembly is null)
{
    WriteLine("Could not get the entry assembly.");
    return;
}
OutputAssemblyInfo(thisAssembly);
DemoAssemblyLoadContext loadContext = new(thisAssembly.Location);
string assemblyPath = Path.Combine(Path.GetDirectoryName(thisAssembly.Location) ?? "", "Library.dll");
WriteLine($"""
Creating load context for:
  {Path.GetFileName(thisAssembly.Location)}
Loading:
  {Path.GetFileName(assemblyPath)}
""");

Assembly dogAssembly = loadContext.LoadFromAssemblyPath(assemblyPath);
OutputAssemblyInfo(dogAssembly);
Type? dogType = dogAssembly.GetType("DynamicLoadAndExecute.Library.Dog");
if (dogType is null)
{
    WriteLine("Could not get the Dog type.");
    return;
}
MethodInfo? method = dogType.GetMethod("Speak");
if (method != null)
{
    object? dog = Activator.CreateInstance(dogType);
    for (int i = 0; i < 10; i++)
    {
        method.Invoke(dog, new object[] { "Fido" });
    }
}

WriteLine();
WriteLine("Unloading context and assemblies.");
loadContext.Unload();
