var input = File.ReadAllText($"C:\\repos\\AoC\\AdventOfCode\\AdventOfCode\\input.txt");

var ranges = input.Split(",");
var invalidNumbers = new List<ulong>();
foreach (var range in ranges)
{
    var values = range.Split("-");
    var from = ulong.Parse(values[0]);
    var to = ulong.Parse(values[1]);

    for (ulong i = from; i <= to; i++)
    {
        if (IsInvalid(i))
        {
            Console.WriteLine($"Number {i} is invalid.");
            invalidNumbers.Add(i);
        }
    }
}

ulong result = 0;
foreach (var invalidNumber in invalidNumbers)
{
    result += invalidNumber;
}

Console.WriteLine(result);

static bool IsInvalid(ulong number)
{
    var chars = number.ToString();
    
    /* first star
    if (chars.Length % 2 != 0) return false;

    if (chars.Substring(0, chars.Length / 2) == chars.Substring(chars.Length / 2))
    {
        return true;
    }

    return false;
    */
    
    var possiblePatterns = new List<string>();

    for (int j = 0; j < chars.Length / 2; j++)
    {
        possiblePatterns.Add(chars.Substring(0, j + 1));
    }
    
    var result = false;
    foreach (var possiblePattern in possiblePatterns)
    {
        result = false;
        var rest = chars.Substring(possiblePattern.Length);

        if (rest.Length % possiblePattern.Length != 0) continue;

        var toCheck = Enumerable.Range(0, rest.Length / possiblePattern.Length)
            .Select(i => rest.Substring(i * possiblePattern.Length, possiblePattern.Length))
            .ToArray();

        foreach (var check in toCheck)
        {
            if (check == possiblePattern)
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }

        if (result)
        {
            return result;
        }
        // else
        // {
        //     result = false;
        // }
    }

    return result;
}
