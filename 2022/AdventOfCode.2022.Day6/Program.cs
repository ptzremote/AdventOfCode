var chars = File.ReadAllText("dump.txt").ToCharArray();
var markerCount = 4;

var startIndex = 0;
var queue = new Queue<char>();

foreach (var @char in chars)
{
	startIndex++;

	queue.Enqueue(@char);

	if (queue.Count > markerCount)
		queue.Dequeue();

	if (queue.ToHashSet().Count == markerCount)
		break;
}

Console.WriteLine(startIndex);