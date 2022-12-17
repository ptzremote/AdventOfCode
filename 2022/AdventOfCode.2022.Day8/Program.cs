var firstLineProcessed = false;
var forest = new int[0, 0];

var visibleTrees = new HashSet<TreePosition>();

var lineIndex = 0;
foreach (var line in File.ReadLines("dump.txt"))
{
    var trees = line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

    if (firstLineProcessed == false)
    {
        forest = new int[trees.Length, trees.Length];
    }

    for (int i = 0; i < trees.Length; i++)
    {
        forest[lineIndex, i] = trees[i];
    }

    lineIndex++;
    firstLineProcessed = true;
}

for(int line = 0; line < forest.GetLength(0); line++)
{
    var minHeight = int.MinValue;
    for (int column = 0; column < forest.GetLength(0); column++)
    {
        var currentTreeHeight = forest[line, column];

        if (currentTreeHeight > minHeight)
        {
            minHeight = currentTreeHeight;
            visibleTrees.Add(new TreePosition(line, column));
        }
    }

    minHeight = int.MinValue;
    for (int column = forest.GetLength(0) - 1; column >= 0; column--)
    {
        var currentTreeHeight = forest[line, column];;

        if (currentTreeHeight > minHeight)
        {
            minHeight = currentTreeHeight;
            visibleTrees.Add(new TreePosition(line, column));
        }
    }
}

for (int column = 0; column < forest.GetLength(0); column++)
{
    var minHeight = int.MinValue;
    for (int line = 0; line < forest.GetLength(0); line++)
    {
        var currentTreeHeight = forest[line, column];

        if (currentTreeHeight > minHeight)
        {
            minHeight = currentTreeHeight;
            visibleTrees.Add(new TreePosition(line, column));
        }
    }

    minHeight = int.MinValue;
    for (int line = forest.GetLength(0) - 1; line >= 0; line--)
    {
        var currentTreeHeight = forest[line, column];

        if (currentTreeHeight > minHeight)
        {
            minHeight = currentTreeHeight;
            visibleTrees.Add(new TreePosition(line, column));
        }
    }
}

Console.WriteLine(visibleTrees.Count);

public record TreePosition(int X, int Y);
