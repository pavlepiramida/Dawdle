using Dawdle.API.Controllers;
using NUnit.Framework;

namespace Dawdle.API.Test.Controllers
{
    class ValuesControllerTest
    {
        [Test]
        public void Get_Should_Return_String_Array()
        {
            // A
            var controller = new ValuesController();

            // A
            var actual = controller.Get();

            // A

            Assert.AreEqual(typeof(string[]), actual.Value.GetType());

        }

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        public int Get_Given_Int_Should_Return_Same_int(int data)
        {
            // A
            var controller = new ValuesController();

            // A
            var actual = controller.Get(data);

            // A
            return actual.Value;
        }
    }
}
