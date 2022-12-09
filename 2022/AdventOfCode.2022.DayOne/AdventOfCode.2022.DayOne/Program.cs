var currentTotal = 0;
var pr = new PriorityQueue<int, int>();

foreach (var line in File.ReadLines("dump.txt"))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        pr.Enqueue(currentTotal, -currentTotal);

        currentTotal = 0;
        continue;
    }

    var value = int.Parse(line);
    currentTotal += value;
}

Console.WriteLine(pr.Dequeue() + pr.Dequeue() + pr.Dequeue());
