using Newtonsoft.Json;
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
        protected int _critChance = 10;
        protected int _critDamage = 20;
        protected int _dodgeChance = 0;
        protected int _type = 0;
        protected float _speed;
        protected string _sprite;
        protected bool _isDead = false;
        protected List<AttackMove> _attackMoves = new List<AttackMove>();
        protected List<MagicMove> _magicMoves = new List<MagicMove>();

        #region get/set
        [JsonProperty]
        public float _mSpeed
        {
            get { return _speed; }
            protected set { _speed = value; }
        }

        [JsonProperty]
        public string _mSprite
        {
            get { return _sprite; }
            protected set { _sprite = value; }
        }

        [JsonProperty]
        public float _mHp
        {
            get { return _hp; }
            protected set { _hp = value; }
        }
        [JsonProperty]
        public float _mHpMax
        {
            get { return _hpMax; }
            protected set { _hpMax = value; }
        }

        [JsonProperty]
        public float _mMp
        {
            get { return _mp; }
            protected set { _mp = value; }
        }

        [JsonProperty]
        public float _mMpMax
        {
            get { return _mpMax; }
            protected set { _mpMax = value; }
        }

        [JsonProperty]
        public bool _mIsDead
        {
            get { return _isDead; }
            protected set { _isDead = value; }
        }
        [JsonProperty]
        public string _mName
        {
            get { return _name; }
            protected set { _name = value; }
        }

        [JsonProperty]
        public int _mDodgeChance
        {
            get { return _dodgeChance; }
            protected set { _dodgeChance = value; }
        }
        [JsonProperty]
        public int _mCritChance
        {
            get { return _critChance; }
            protected set { _critChance = value; }
        }
        [JsonProperty]
        public int _mCritDamage
        {
            get { return _critDamage; }
            protected set { _critDamage = value; }
        }
        [JsonProperty]
        public int _mLevel
        {
            get { return _level; }
            protected set { _level = value; }
        }
        [JsonProperty]
        public float _mExp
        {
            get { return _exp; }
            protected set { _exp = value; }
        }
        [JsonProperty]
        public string _mType
        {
            get { return _type; }
            protected set { _type = value; }
        }
        [JsonProperty]
        public List<AttackMove> _mAttackMove
        {
            get { return _attackMoves; }
            protected set { _attackMoves = value; }
        }
        [JsonProperty]
        public List<MagicMove> _mMagicMoves
        {
            get { return _magicMoves; }
            protected set { _magicMoves = value; }
        }
        #endregion

        public Character()
        {
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            if(_hp <= 0)
            {
                _hp = 0;
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
            _hp += hp;
            if(_hp > _hpMax)
            {
                _hp = _hpMax;
            }
        }
        public virtual int Attack(Move move, Character character)
        {
            Random random = new Random();
            if(move._mMpCost != null)
            {
                this._mp -= move._mMpCost;
/*                if (this._mp < 0)
                {
                    _mp = 0;
                }*/
            }
            if (random.Next(101) < character._mDodgeChance) {
                return 0;
            }
            if (Utils.MathHelper.Modulo(move._mType - 1, 3) == character._type)
            { if (random.Next(101) < _critChance)
                    return move._mDamage * 2 + move._mDamage * 2 * _critDamage / 100;
                return move._mDamage * 2; }
            else if (Utils.MathHelper.Modulo(move._mType + 1, 3) == character._type) {
                if (random.Next(101) < _critChance)
                    return move._mDamage + move._mDamage * _critDamage / 100;
            return (int)(move._mDamage * 0.5); }
            else if (random.Next(101) < _critChance)
                return move._mDamage + move._mDamage * _critDamage / 100;
            return move._mDamage;
        }
        public void AddAttack(AttackMove attack)
        {
            _attackMoves.Add(attack);
        }
        public void RemoveAttack(AttackMove attack)
        {
            _attackMoves.Remove(attack);
        }
        public void AddMagic(MagicMove magic)
        {
            _magicMoves.Add(magic);
        }
        public void RemoveMagic(MagicMove magic)
        {
            _magicMoves.Remove(magic);
        }
        public void AddAttack(List<AttackMove> attack)
        {
            for (int i = 0; i < attack.Count; i++)
            {
                _attackMoves.Add(attack[i]);
            }

        }
    }
}