using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Character : GameObject
    {
        protected string _name;
        protected float _hp;
        protected float _mp;
        protected float _hpMax;
        protected float _mpMax;
        protected int _level;
        protected float _exp;
        /*protected int _iCritChance = 5;
        protected int _iCritDamage = 0;*/
        protected float _dodgeChance = 0.0f;
        protected string _type;
        protected float _speed;
        protected string _sprite;
        protected bool _isDead = false;
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
        public float _mExp
        {
            get { return _exp; }
            protected set { _exp = value; }
        }
        public int _mLevel
        {
            get { return _level; }
            protected set { _level = value; }
        }
        public string _mType
        {
            get { return _type; }
            protected set { _type = value; }
        }
        public float _mDodgeChance
        {
            get { return _dodgeChance; }
            protected set { _dodgeChance = value; }
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
    }
}