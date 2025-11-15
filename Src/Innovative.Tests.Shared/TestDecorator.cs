using NUnit.Framework;

namespace Innovative.Tests.Shared
{
    public class Assert2
    {
        public static void AreEqual(object x, object y)
        {
            Assert.That(x, Is.EqualTo(y));
        }

        public static void IsTrue(bool value)
        {
            Assert.That(value, Is.EqualTo(true));
        }

        public static void AreSame(object x, object y)
        {
            Assert.That(x, Is.SameAs(y));
        }
    }
}
