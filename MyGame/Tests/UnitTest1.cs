using System.Threading;
using NUnit.Framework;
using MyGame;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game(10);
        }

        [Test]
        public void TestOne()
        {

        }
    }
}