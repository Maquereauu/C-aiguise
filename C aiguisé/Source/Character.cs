using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Character : GameObject
    {
        protected enum Type
        {
            Red,
            Blue,
            Green
        } 
        protected string _name;
        protected float _hp;
        protected float _mp;
        protected float _hpMax;
        protected float _mpMax;
        protected int _level;
        protected float _exp;
        protected int _critChance = 5;
        protected int _critDamage = 20;
        protected int _dodgeChance = 0;
        protected string _type;
        protected float _speed;
        protected string _sprite;
        protected bool _isDead = false;
        protected List<AttackMove> attackMoves = new List<AttackMove>();
        public float _mSpeed
        {
            get { return _speed; }
            protected set { _speed = value; }
        }

        public string _mSprite
        {
            get { return _sprite; }
            protected set { _sprite = value; }
        }

        public float _mHp
        {
            get { return _hp; }
            protected set { _hp = value; }
        }

        public float _mHpMax
        {
            get { return _hpMax; }
            protected set { _hpMax = value; }
        }

        public float _mMp
        {
            get { return _mp; }
            protected set { _mp = value; }
        }

        public float _mMpMax
        {
            get { return _mpMax; }
            protected set { _mpMax = value; }
        }

        public bool _mIsDead
        {
            get { return _isDead; }
            protected set { _isDead = value; }
        }
        public string _mName
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public int _mDodgeChance
        {
            get { return _dodgeChance; }
            protected set { _dodgeChance = value; }
        }
        public int _mCritChance
        {
            get { return _critChance; }
            protected set { _critChance = value; }
        }
        public int _mCritDamage
        {
            get { return _critDamage; }
            protected set { _critDamage = value; }
        }
        public void TakeDamage(int damage)
        {
            _hp -= damage;
            if(_hp <= 0)
            {
                _isDead = true;
            }
        }
        public virtual void Update() { }
        public void Heal()
        {
            _hp = _hpMax;
            _mp = _mpMax;
        }
        public void Heal(int hp)
        {
            _hp += hp % _hpMax;
        }
        public virtual int Attack(/*Attack attack*/Character character)
        {
            Random random = new Random();
            if (random.Next(101) < character._mDodgeChance) {  
                return 0;
            }
            //if(MathHelper.Mod(attack.type - 1,3) == character.type )
            //if(random.Next(101) < _critChance)
            //return attack.damage * 2 + attack.damage * 2 * _critDamage/100
            //return attack.damage*2 
            //else if(MathHelper.Mod(attack.type + 1,3) == character.type )
            //if(random.Next(101) < _critChance)
            //return attack.damage + attack.damage * _critDamage/100
            //return attack.damage*0.5
            //else
            //if(random.Next(101) < _critChance)
            //return attack.damage + attack.damage * _critDamage/100
            //return attack.damage
            return 10;
        }
        public void AddAttack(AttackMove attack)
        {
            attackMoves.Add(attack);
        }
    }
}