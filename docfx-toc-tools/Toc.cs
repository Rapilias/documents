using VYaml.Annotations;

namespace TocFixer;

// https://dotnet.github.io/docfx/docs/table-of-contents.html
[YamlObject]
public partial class Toc
{
    public string name { get; set; } = string.Empty;
    public string href { get; set; } = string.Empty;
    public Toc[] items { get; set; } = Array.Empty<Toc>();
    public bool expanded { get; set; } = false;
    public int order { get; set; } = 0;
}
