using System.Text;

using TestGreeting;

namespace GreetingProgram.cs;

public class Greeting : IGreeting
{
    public string Greet(string? name)
    {
        StringBuilder result = new StringBuilder();
        result.Append("Hello");
        if (name is null)
        {
            return result.Append(", my friend.").ToString();
        }


        if (name.All(p => char.IsUpper(p)))
        {
            result = new StringBuilder(result.ToString().ToUpper());
            result.Append(' ');
            result.Append(name);
            result.Append('!');
        }
        else
        {
            result.Append(", ");
            result.Append(name);
            result.Append('.');
        }

        return result.ToString();
    }

    private string JoinStrings(IEnumerable<string> strings)
        => String.Join(", ", strings.Take(strings.Count()));

    private string GetElementsBetweenCommas(string word)
        => new string(new String(word.Take(word.Count() - 1).Skip(1).ToArray()));

    private string?[] HandleCommas(IEnumerable<string?> x)
    {

        List<string?> allNames = new List<string?>();
        foreach (var name in x)
        {
            if (name is null)
            {
                allNames.Add(name);
                continue;
            }

            if (name.First() == '"' && name.Last() == '"')
            {
                allNames.Add(GetElementsBetweenCommas(name));
            }
            else if (name.Contains(','))
            {

                allNames.AddRange(name.Split(',').ToList());
            }
            else
            {
                allNames.Add(name!);
            }
        }
        return allNames.ToArray();
    }

    private bool IsUpper(string word)
        => word.All(p => char.IsUpper(p));

    private string HandleCaseStrings(IEnumerable<string> names, bool isUpper)
    {
        if (names.Count() == 0)
            return "";
        string lastElement = names.Last();
        string separator = isUpper ? " AND " : " and ";
        string result = names.Count() == 1 ? lastElement : $"{JoinStrings(names.SkipLast(1))}{separator}{lastElement}";
        return result;
    }

    private IEnumerable<string> SwitchNullWithWord(IEnumerable<string?> words)
           => words.Select(x => string.IsNullOrWhiteSpace(x) ? "you" : x);

    public string Greet(string?[]? names)
    {
        if (names is null)
            return Greet("my friends");

        string?[] allNamesSeparatedWithComa = HandleCommas(names);
        var handledNullElements = SwitchNullWithWord(allNamesSeparatedWithComa);

        StringBuilder result = new StringBuilder();

        var handledNullElementsUppercase = handledNullElements.Where(p => IsUpper(p));
        var handledNullElementsLowercase = handledNullElements.Where(p => !IsUpper(p));

        string resultLowercase = string.Empty;
        string resultUppercase = string.Empty;

        resultUppercase = HandleCaseStrings(handledNullElementsUppercase, true);
        resultLowercase = HandleCaseStrings(handledNullElementsLowercase, false);

        if (resultUppercase == "")
            result.Append(Greet(resultLowercase));
        else if (resultLowercase == "")
            result.Append(Greet(resultUppercase));
        else
        {
            result.Append(Greet(resultLowercase));
            result.Append(" AND ");
            result.Append(Greet(resultUppercase));
        }

        return result.ToString();
    }
}
