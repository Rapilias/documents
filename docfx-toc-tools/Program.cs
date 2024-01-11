using TocFixer;
using VYaml.Serialization;

var BasePath = "docs/";
var TocPath = BasePath + "toc.yml";

int GetOrder(Toc node)
{
    if (string.IsNullOrEmpty(node?.href))
        return 0;

    var file = File.ReadAllLines(BasePath + node.href);
    if(file.Length == 0)
        return 0;
    if (file[0].StartsWith("---"))
    {
        for(var i = 0; i < file.Length; i++)
        {
            if (file[i].StartsWith("order:"))
            {
                var order = file[i].Split(":").Last().Trim();
                if (int.TryParse(order, out var result))
                    return result;
            }
        }
    }

    return 0;
}


Toc? toc = null;
{
    using var stream = File.OpenRead(TocPath);
    toc = await YamlSerializer.DeserializeAsync<Toc>(stream);
}
{
    void UpdateTocNode(Toc node, int hierarchy = 0)
    {
        if (string.IsNullOrEmpty(node.name) == false)
        {
            var directory = Path.GetDirectoryName(node.href);
            if (directory != null)
            {
                if (node.href.EndsWith("index.md", StringComparison.OrdinalIgnoreCase))
                    node.name = directory.Split(Path.DirectorySeparatorChar).Last();
                else
                    node.name = Path.GetFileNameWithoutExtension(node.href);
            }
        }
        node.order = GetOrder(node);
        node.expanded = true;

        // 階層処理
        if(node.items == null || node.items.Length == 0)
            return;

        // hrefの無い子をエラーにする
        var href = string.IsNullOrEmpty(node.href) ? string.Empty : node.href;
        foreach(var item in node.items)
            if(string.IsNullOrEmpty(item.href))
                throw new InvalidOperationException($"{node.href}/{item.name} is hierarchy but, not contained index.md file.");

        // ツールにより生成されてしまった重複したindexを削除
        node.items = node.items
            .Where(m => m.href.Equals(href, StringComparison.OrdinalIgnoreCase) == false)
            .ToArray();
        foreach (var item in node.items)
        {
            Console.WriteLine($"{new string(' ', hierarchy * 2)}{item.name}: {item.href}");
            UpdateTocNode(item, hierarchy + 1);
        }
        node.items = node.items.OrderBy(m => m.order).ThenBy(m => m.name).ToArray();
    }

    UpdateTocNode(toc);
}
{
    var text = YamlSerializer.Serialize(toc);
    await File.WriteAllBytesAsync(TocPath, text.ToArray());
    Console.WriteLine("docfx-toc-tools: toc.yml fixed.");
}
