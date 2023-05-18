using GreetingProgram.cs;

namespace TestGreeting
{
    public class UnitTest1
    {
        private readonly IGreeting _sut;

        public UnitTest1()
        {
            _sut = new Greeting();
        }

        [Fact]
        public void Should_Interpolate_Name_In_Greeting()
        {
            Assert.Equal("Hello, Bob.", _sut.Greet("Bob"));
            Assert.Equal("Hello, my friend.", _sut.Greet((string?)null));
            Assert.Equal("HELLO, BOB!", _sut.Greet("BOB"));
            Assert.Equal("Hello, Jin and Jane.", _sut.Greet(new string[] { "Jin", "Jane" }));

        }
    }
}