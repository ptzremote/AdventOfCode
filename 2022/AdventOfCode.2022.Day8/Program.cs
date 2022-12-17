var firstLineProcessed = false;
var forest = new Tree[0, 0];

var lineIndex = 0;
foreach (var line in File.ReadLines("dump.txt"))
{
    var trees = line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

    if (firstLineProcessed == false)
    {
        forest = new Tree[trees.Length, trees.Length];
    }

    for (int i = 0; i < trees.Length; i++)
    {
        forest[lineIndex, i] = new Tree { Height = trees[i] };
    }

    lineIndex++;
    firstLineProcessed = true;
}

var forestLength = forest.GetLength(0);
for (int i = 1; i < forestLength - 1; i++)
{
    for (int j = 1; j < forestLength - 1; j++)
    {
        var currentTree = forest[i, j];

        for (int k = j + 1; k < forestLength; k++)
        {
            var rightTree = forest[i, k];
            
            currentTree.RightScore += 1;

            if (currentTree.Height <= rightTree.Height)
                break;
        }

        for (int k = j - 1; k >= 0; k--)
        {
            var leftTree = forest[i, k];
            
            currentTree.LeftScore += 1;

            if (currentTree.Height <= leftTree.Height)
                break;
        }

        for (int k = i + 1; k < forestLength; k++)
        {
            var upTree = forest[k, j];
            
            currentTree.UpScore += 1;

            if (currentTree.Height <= upTree.Height)
                break;
        }

        for (int k = i - 1; k >= 0; k--)
        {
            var bottomTree = forest[k, j];
            
            currentTree.BottomScore += 1;

            if (currentTree.Height <= bottomTree.Height)
                break;
        }
    }
}

var maxScore = 0;
foreach (var tree in forest)
{
    var currentScore = tree.LeftScore * tree.RightScore * tree.UpScore * tree.BottomScore;

    if (currentScore > maxScore)
        maxScore = currentScore;
}

Console.WriteLine(maxScore);

internal sealed class Tree
{
    public int Height { get; set; }
    public int RightScore { get; set; }
    public int LeftScore { get; set; }
    public int UpScore { get; set; }
    public int BottomScore { get; set; }
}
