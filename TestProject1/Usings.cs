global using NUnit.Framework;
using C_aiguisé;

namespace TestProject1
{
    public class Using
    {

        [Test]
        [TestCase(100, 30, 70)]
        [TestCase(100, 70, 30)]
        [TestCase(100, 100, 0)]
        [TestCase(100, 200, 0)]
        public void TakeDamage(int hp, int damage, int result)
        {
            int finalHp = Tests.TakeDamage(hp, damage, result);
            Assert.That(finalHp, Is.EqualTo(result));
        }

        [Test]
        [TestCase(100, -200, -100)]
        public void CrashTakeDamage(int hp, int damage, int result)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                int finalHp = Tests.TakeDamage(hp, damage, result);
                Assert.That(finalHp, Is.EqualTo(result));
            });
        }

    }
}