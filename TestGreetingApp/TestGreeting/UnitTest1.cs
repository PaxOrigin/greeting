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
        public void Should_Interpolate_Name_In_Greeting_Lowercase()
        {
            Assert.Equal("Hello, Bob.", _sut.Greet("Bob"));


        }

        [Fact]
        public void Should_Handle_Null_Value()
        {
            Assert.Equal("Hello, my friend.", _sut.Greet((string?)null));
        }

        [Fact]
        public void Should_Handle_UpperCase_With_Shouting()
        {
            Assert.Equal("HELLO BOB!", _sut.Greet("BOB"));
        }

        [Fact]
        public void Should_Handle_String_Arrays_Simple()
        {
            Assert.Equal("Hello, Jin and Jane.", _sut.Greet(new string[] { "Jin", "Jane" }));
        }

        [Fact]
        public void Should_Handle_String_Arrays_With_Uppercase()
        {
            Assert.Equal("Hello, Jin and Jane. AND HELLO BOB!", _sut.Greet(new string?[] { "Jin", "Jane", "BOB" }));
            Assert.Equal("Hello, you. AND HELLO BOB!", _sut.Greet(new string?[] { null, "BOB" }));
            Assert.Equal("Hello, Jin and Jane.", _sut.Greet(new string?[] { "Jin", "Jane" }));
            Assert.Equal("Hello, you and you.", _sut.Greet(new string?[] { null, null }));
            String?[]? a = null;
            Assert.Equal("Hello, my friends.", _sut.Greet(a));
            Assert.Equal("Hello, you and you. AND HELLO BOB!", _sut.Greet(new string?[] { null, null, "BOB" }));
        }

        [Fact]
        public void Should_Handle_Strings_With_Commas()
        {
            Assert.Equal("Hello, Bob, Dianne and Jon.", _sut.Greet(new string?[] { "Bob", "Dianne,Jon" }));
        }

        [Fact]
        public void Should_Handle_Strings_With_Quotes()
        {
            Assert.Equal("Hello, Bob and Dianne, and Jon.", _sut.Greet(new string?[] { "Bob", "\"Dianne, and Jon\"" }));
        }
    }
}