var root = new Node("/");
var nodes = new List<Node> { root };
var currentNode = root;

foreach (var line in File.ReadLines("dump.txt").Skip(1)) // first always 'cd /'
{
    if (line.StartsWith("$"))
        HandleCommand(line[2..]);
    else
        HandleList(line);
}

void HandleList(string line)
{
    if (line.StartsWith("dir"))
    {
        var node = new Node(line[3..])
        {
            Parent = currentNode
        };
        nodes.Add(node);
        currentNode.Children.Add(node);
    }
    else
    {
        var parts = line.Split(' ');
        var value = long.Parse(parts[0]);

        currentNode.Value += value;

        UpdateNodeValue(currentNode, value);
    }
}

void UpdateNodeValue(Node node, long value)
{
    if (node.Parent == null)
        return;

    node.Parent.Value += value;

    UpdateNodeValue(node.Parent, value);
}

void HandleCommand(string command)
{
    if (command.StartsWith("cd"))
    {
        currentNode = command[3..] == ".."
            ? currentNode.Parent
            : currentNode.Children.First(c => c.Name == command[2..]);
    }

    // else ls
}

var requiredSize = 70000000 - root.Value - 30000000;

var currentFolderSize = long.MaxValue;
foreach (var node in nodes)
{
    if(node.Value < currentFolderSize && node.Value > -requiredSize)
        currentFolderSize = node.Value;
}

Console.WriteLine(currentFolderSize);

sealed class Node
{
    public Node(string name)
    {
        Name = name;
    }

    public Node? Parent { get; set; }
    public List<Node> Children { get; set; } = new();
    public string? Name { get; set; }
    public long Value { get; set; } = 0;
}