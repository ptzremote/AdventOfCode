var result = 0;

foreach(var line in File.ReadLines("dump.txt")) {
    var parts = line.Split(',');

    var firstSections = parts[0].Split('-');
    var firstSectionStart = int.Parse(firstSections[0]);
    var firstSectionEnd = int.Parse(firstSections[1]);

    var secondSections = parts[1].Split('-');
    var secondSectionStart = int.Parse(secondSections[0]);
    var secondSectionEnd = int.Parse(secondSections[1]);

    if ((firstSectionStart >= secondSectionStart && firstSectionStart <= secondSectionEnd) ||
        (firstSectionEnd >= secondSectionStart && firstSectionEnd <= secondSectionEnd) ||
        (firstSectionStart <= secondSectionStart && firstSectionEnd >= secondSectionEnd))
        result++;
}

Console.WriteLine(result);