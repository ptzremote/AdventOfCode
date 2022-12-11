var result = 0;

var index = 0;
var alphabetDict = Enumerable.Range('a', 26).Concat(Enumerable.Range('A', 26))
    .Select(num => ((char)num)).ToDictionary(@char => @char, @char => ++index);

foreach (var rucksack in File.ReadLines("dump.txt"))
{
    var compartmentOne = rucksack[..(rucksack.Length / 2)];
    var compartmentTwo = rucksack[(rucksack.Length / 2)..];

    var hash = compartmentTwo.ToHashSet();

    foreach (var @char in compartmentOne.Where(@char => hash.Contains(@char)))
    {
        result += alphabetDict[@char];
        break;
    }
}

Console.WriteLine(result);