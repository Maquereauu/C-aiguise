using C_aiguisé;
using System;
using System.Runtime.Remoting;

namespace TestProject1
{
    public class Tests
    {

        [Test]
        public static void Test1()
        {
            Weapon noeil = new Weapon("salut");
            Tank tank = new Tank();
            Player p1 = new Player(noeil,tank);
            tank.setPlayer(p1);
            tank.setAttack();
            List<Player> p = new List<Player>() { p1 };
            Enemy e1= new Enemy();
            Enemy e2= new Enemy();
            Enemy e3= new Enemy();
            List<Enemy> e = new List<Enemy>() { e1,e2,e3 };
            //Battle battle = new Battle(p,e);
            Potion HealingPotion = new Potion(25);
            p1._mCritChance = 0;
            p1._mDodgeChance = 0;
            e1._mDodgeChance = 0;
            e1._mCritChance = 0;
            e2._mDodgeChance = 0;
            e2._mCritChance = 0;
            e3._mDodgeChance = 0;
            e3._mCritChance = 0;

            e1.TakeDamage(p1.Attack(p1._mAttackMoves[0], e1));


            Assert.That(e1._mHp,Is.EqualTo(60));
            e1.TakeDamage(p1.Attack(p1._mAttackMoves[0], e1));
            Assert.That(e1._mHp, Is.EqualTo(20));
            e1.TakeDamage(p1.Attack(p1._mAttackMoves[0], e1));
            Assert.That(e1._mHp, Is.EqualTo(0));
            e1.TakeDamage(p1.Attack(p1._mAttackMoves[0], e1));
            Assert.That(e1._mHp, Is.EqualTo(0));
            Assert.That(e1._mIsDead, Is.EqualTo(true));
            p1.TakeDamage(e1.Attack(e1._mAttackMoves[0],p1));
            Assert.That(p1._mHp, Is.EqualTo(80));
            p1._mRole.Update();
            Assert.That(p1._mHp, Is.EqualTo(85));
            HealingPotion.Update(p1);
            Assert.That(p1._mHp, Is.EqualTo(100));
            e2._mType = 1;
            e2.TakeDamage(p1.Attack(p1._mAttackMoves[0], e2));
            Assert.That(e2._mHp, Is.EqualTo(80));
            e2._mType = 2;
            e2.TakeDamage(p1.Attack(p1._mAttackMoves[0], e2));
            Assert.That(e2._mHp, Is.EqualTo(0));
            e3._mDodgeChance = 100;
            e3.TakeDamage(p1.Attack(p1._mAttackMoves[0], e3));
            Assert.That(e3._mHp, Is.EqualTo(100));
            e3._mDodgeChance = 0;
            p1._mCritChance = 100;
            p1._mCritDamage = 50;
            e3.TakeDamage(p1.Attack(p1._mAttackMoves[0], e3));
            Assert.That(e3._mHp, Is.EqualTo(40));

        }

        public static int TakeDamage(int hp, int damage, int result )
        {
            if (damage < 0) 
            {
                throw new ArgumentException("Damage can't be negative");
            }
            if ( result < 0)
            {
                throw new ArgumentException("Final hp can't be negative");
            }
            Player player = new Player();
            player._mHp = hp;
            player.TakeDamage(damage);

            return player._mHp;
        }

    }
}