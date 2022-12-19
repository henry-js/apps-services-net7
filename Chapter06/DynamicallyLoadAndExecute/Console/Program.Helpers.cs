partial class Program
{
    static void OutputAssemblyInfo(Assembly a)
    {
        WriteLine($"""
        FullName: {a.FullName}
        Location: {Path.GetDirectoryName(a.Location)}
        IsCollectible: {a.IsCollectible}
        Defined types:
        """);
        foreach (TypeInfo info in a.DefinedTypes)
        {
            if (!info.Name.EndsWith("Attribute"))
            {
                WriteLine($"  Name: {info.Name}, Members: {info.GetMembers().Length}");
            }
        }
    }
}
