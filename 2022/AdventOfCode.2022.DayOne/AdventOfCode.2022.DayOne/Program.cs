var maxTotalValue = int.MinValue;
var currentTotal = 0;

foreach (var line in File.ReadLines("dump.txt"))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        if (currentTotal > maxTotalValue)
            maxTotalValue = currentTotal;

        currentTotal = 0;
        continue;
    }

    var value = int.Parse(line);
    currentTotal += value;
}
