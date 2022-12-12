using System.Text.RegularExpressions;

var rx = new Regex(@"\d+");
var initRead = false;

var initDict = new Dictionary<int, List<char>>();
var dict = new Dictionary<int, Stack<char>>();

foreach (var line in File.ReadLines("dump.txt"))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        initRead = true;
        dict = initDict.ToDictionary(c => c.Key, v =>
        {
            v.Value.Reverse();
            return new Stack<char>(v.Value);
        });
        continue;
    }

    if (initRead)
    {
        var numbers = rx.Matches(line).Select(c => int.Parse(c.Value)).ToArray();

        var moves = numbers[0];
        var buffer = new Stack<char>();
        do
        {
            var value = dict[numbers[1]].Pop();
            buffer.Push(value);
            moves--;
        } while (moves > 0);

        while (buffer.Count > 0)
        {
            var value = buffer.Pop();
            dict[numbers[2]].Push(value);
        }
    }
    else
        ProcessInit(line);
}

foreach (var key in dict.Keys.OrderBy(c => c))
{
    Console.Write(dict[key].Peek());
}

void ProcessInit(string line)
{
    var parts = line.Chunk(4);

    var index = 1;
    foreach (var part in parts)
    {
        var values = part.Where(c => c != ' ' && c != '[' && c != ']');
        foreach (var value in values)
        {
            if (value != default && !int.TryParse(value.ToString(), out _))
            {
                if (!initDict.TryGetValue(index, out var queue))
                {
                    queue = new List<char>();
                    initDict[index] = queue;
                }

                queue.Add(value);
            }
        }

        index++;
    }
}
