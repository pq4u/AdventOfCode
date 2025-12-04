var lines =  File.ReadAllLines("C:\\repos\\AoC\\AdventOfCode\\AdventOfCode.Day4\\input.txt");
long totalOutput = 0;

foreach (var line in lines)
{
    var joltage = new int[12];
    var left = line.Length;
    var toTake = 12;

    var listToWorkWith = line.Select(c => c - '0').ToList();
    var numbersTaken = 0;
    var currentIndexToFill = 0;
    
    for (int j = 0; j < joltage.Length; j++)
    {
        currentIndexToFill = j;

        for (int i = 0; i < listToWorkWith.Count; i++)
        {
            var num = int.Parse(listToWorkWith[i].ToString());

            if (toTake > left)
            {
                listToWorkWith = listToWorkWith.Skip(numbersTaken + 1).ToList();
                break;
            }

            if (num > joltage[currentIndexToFill])
            {
                joltage[currentIndexToFill] = num;
                numbersTaken = i;
            }
        
            left--;
        }
        left = listToWorkWith.Count();
        numbersTaken = 0;
        toTake--;
    }

    // very memory friendly way of converting array to string
    var joltageString = "";
    
    for (int i = 0; i < joltage.Length; i++)
    {
        joltageString += joltage[i];
    }

    Console.WriteLine(joltageString);
    totalOutput += long.Parse(joltageString);
}

Console.WriteLine($"Total: {totalOutput}");