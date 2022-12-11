var result = 0;

var index = 0;
var alphabetDict = Enumerable.Range('a', 26).Concat(Enumerable.Range('A', 26))
    .Select(num => ((char)num)).ToDictionary(@char => @char, @char => ++index);
foreach (var rucksacks in File.ReadLines("dump.txt").Chunk(3))
{
    var r1 = rucksacks[0];
    var r2 = rucksacks[1].ToHashSet();
    var r3 = rucksacks[2].ToHashSet();

    foreach (var @char in r1.Where(@char => r2.Contains(@char) && r3.Contains(@char)))
    {
        result += alphabetDict[@char];
        break;
    }
}

Console.WriteLine(result);