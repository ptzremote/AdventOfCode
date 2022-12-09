var beatMap = new[,]
{                     // X  Y  Z
    /* (A) rock */     { 3, 6, 0 },
    /* (B) paper */    { 0, 3, 6 },
    /* (C) Scissors */ { 6, 0, 3 }
};

var chooses = new Dictionary<string, (int index, int value)>
{
    { "A", (0, -1) }, { "B", (1, -1) }, { "C", (2, -1) },
    { "X", (0, 1) }, { "Y", (1, 2) }, { "Z", (2, 3) }
};

var totalScore = 0;

foreach (var round in File.ReadLines("dump.txt"))
{
    var selected = round.Split(' ');
    var opponent = selected[0];
    var you = selected[1];

    var opponentChoose = chooses[opponent];
    var youChoose = chooses[you];

    var result = beatMap[opponentChoose.index, youChoose.index];

    totalScore += youChoose.value + result;
}

Console.WriteLine(totalScore);
