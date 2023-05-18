using System.Text;

using TestGreeting;

namespace GreetingProgram.cs;

public class Greeting : IGreeting
{
    public string Greet(string? name)
    {
        StringBuilder result = new StringBuilder();
        result.Append("Hello, ");
        if (name is null)
        {
            return result.Append("my friend.").ToString();
        }
        else
        {
            result.Append(name!);
        }

        if (name!.All(p => char.IsUpper(p)))
        {
            result = new StringBuilder(result.ToString().ToUpper());
            result.Append('!');
        }
        else
        {
            result.Append('.');
        }

        return result.ToString();
    }

    public string Greet(string[]? names)
    {
        if (names is null)
            return Greet("my friends.");
        var handledNullElements = names.Select(x => string.IsNullOrWhiteSpace(x) ? "you" : x);
        string argument = String.Join(',', handledNullElements.Take(handledNullElements.Count() - 1));
        string result = $"{argument} and {names.Last()}";
        return Greet(result);
    }
}
