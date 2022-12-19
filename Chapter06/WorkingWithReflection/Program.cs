using System.Reflection;
using System.Runtime.CompilerServices;
using Packt.Shared;

WriteLine("Assembly metadata:");
Assembly? assembly = Assembly.GetEntryAssembly();
if (assembly is null)
{
    WriteLine("Failed to get entry assembly");
    return;
}
WriteLine($"""
Full name: {assembly.FullName}
Location: {assembly.Location}
Entry point: {assembly.EntryPoint?.Name}
  Assembly-level attributes:
""");
var attributes = assembly.GetCustomAttributes();
foreach (var a in attributes)
{
    WriteLine($"    {a.GetType()}");
}
AssemblyInformationalVersionAttribute? version = assembly
  .GetCustomAttribute<AssemblyInformationalVersionAttribute>();
WriteLine($"  Assembly Informational Version: {version?.InformationalVersion}");
AssemblyCompanyAttribute? company = assembly
  .GetCustomAttribute<AssemblyCompanyAttribute>();
WriteLine($"  Assembly Company: {company?.Company}");
WriteLine();
ForegroundColor = ConsoleColor.Green;
WriteLine("*Types:");
Type[] types = assembly.GetTypes();
foreach (Type type in types)
{
    var compGenerated = type.GetCustomAttribute<CompilerGeneratedAttribute>();
    if (compGenerated is not null) continue;

    WriteLine();
    ForegroundColor = ConsoleColor.Red;
    WriteLine($"  Type: {type.FullName}");
    MemberInfo[] members = type.GetMembers();
    foreach (MemberInfo member in members)
    {
        ForegroundColor = member.MemberType switch
        {
            MemberTypes.Constructor => ConsoleColor.DarkGreen,
            MemberTypes.Method => ConsoleColor.Cyan,
            MemberTypes.Property => ConsoleColor.Yellow,
            _ => ConsoleColor.White
        };
        WriteLine($"    {member.MemberType}: {member.Name} ({member.DeclaringType?.Name})");
        IOrderedEnumerable<CoderAttribute> coders = member.GetCustomAttributes<CoderAttribute>()
                                                          .OrderByDescending(c => c.LastModified);
        foreach (var coder in coders)
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"      -> Modified by {coder.Coder}, {coder.LastModified.ToShortDateString()}");
            ResetColor();
        }
    }
}
