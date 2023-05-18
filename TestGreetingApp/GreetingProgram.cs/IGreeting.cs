namespace TestGreeting
{
    public interface IGreeting
    {
        public string Greet(string? name);
        public string Greet(string?[]? name);
    }
}