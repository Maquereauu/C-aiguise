using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_aiguisé
{
    public class Battle
    {
        private enum Actions
        {
            Attack,
            Magic,
            Item,
            Flee,
            Total
        }
        private List<Player> _allies;
        private List<Summon> _summons;
        private List<Enemy> _enemies;
        private List<float> _speeds;
        private List<float> _baseSpeeds;
        private List<Character> _characters;
        private List<Actions> _actions = new List<Actions> { Actions.Attack , Actions.Magic,Actions.Item,Actions.Flee };
        private Actions _selectedAction = Actions.Attack;
        private int _selectedTarget;
        private int _indexSpeedList;
        private float _maxSpeed;
        public event Action needsToUpdate;

        private bool Enemy = true;

        public Battle(List<Player> allies, List<Summon> summons, List<Enemy> enemies) {
            _allies = allies;
            _summons = summons;
            _enemies = enemies;
            _speeds = new List<float>();
            _baseSpeeds = new List<float>();
            _characters = new List<Character>();
            for (int i = 0; i < allies.Count; i++)
            {
                _speeds.Add(_allies[i]._mSpeed);
                _baseSpeeds.Add(_allies[i]._mSpeed);
                _characters.Add(_allies[i]);
            }
            for (int i = 0; i < summons.Count; i++)
            {
                _speeds.Add(summons[i]._mSpeed);
                _baseSpeeds.Add(summons[i]._mSpeed);
                _characters.Add(summons[i]);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                _speeds.Add(enemies[i]._mSpeed);
                _baseSpeeds.Add(enemies[i]._mSpeed);
                _characters.Add(enemies[i]);
            }
            _indexSpeedList = 0;
            _maxSpeed = 0;
            _selectedTarget = _allies.Count - 1;
        }
        public void checkTurn()
        {
            for (int i = 0; i < _speeds.Count; i++)
            {
                if (_speeds[i] > _maxSpeed)
                {
                    _maxSpeed = _speeds[i];
                    _indexSpeedList = i;
                }
            }
        }
        public void addSpeed()
        {
            for (int i = 0; i < _speeds.Count; i++)
            {
                if (i != _indexSpeedList)
                {
                    _speeds[i] += _baseSpeeds[i];
                }
            }
        }

        public void switchAction()
        {
            _selectedAction = (Actions)(((int)_selectedAction + 1) % (int)Actions.Total);
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void switchTarget()
        {
            if(Enemy)
            {
                _selectedTarget = (_selectedTarget + 1) % (_enemies.Count);
            }
            else
            {
                _selectedTarget = (_selectedTarget + 1) % (_allies.Count);
            }
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void Start()
        {
            EventManager._downArrow += switchAction;
            EventManager._rightArrow -= EventManager.MoveRight;
            EventManager._leftArrow -= EventManager.MoveLeft;
            EventManager._downArrow -= EventManager.MoveDown;
            EventManager._upArrow -= EventManager.MoveUp;

            EventManager._enter += SelectMove;

            needsToUpdate += Display;
            needsToUpdate += Update;
        }

        public void Display()
        {
            for (int i = 0; i < _allies.Count; i++)
            {
                Console.WriteLine(_allies[i]._mSprite + _allies[i]._mHp);
            }
            for (int i = 0; i < _enemies.Count; i++)
            {
                Console.WriteLine(_enemies[i]._mSprite + _enemies[i]._mHp);
            }
            for (int i = 0; i < _summons.Count; i++)
            {
                Console.WriteLine(_summons[i]._mSprite);
            }
        }


        public void SelectMove()
        {
            switch ((int)_selectedAction)
            {
                case (int)Actions.Attack:
                    Console.WriteLine("attack!");
                    break;
                case (int)Actions.Magic:
                    Console.WriteLine("magic!");
                    break;
                case (int)Actions.Item:
                    Console.WriteLine("item!");
                    break;
                case (int)Actions.Flee:
                    Console.WriteLine("flee!");
                    break;
            }
            EventManager._downArrow -= switchAction;
            EventManager._downArrow += switchTarget;
            EventManager._enter -= SelectMove;
            EventManager._enter += ExecuteAction;
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void ExecuteAction()
        {
            if (Enemy)
            {
                switch ((int)_selectedAction)
                {
                    case (int)Actions.Attack:
                        _enemies[_selectedTarget].TakeDamage(_allies[_indexSpeedList].Attack());
                        break;
                    case (int)Actions.Magic:
                        break;
                    case (int)Actions.Item:
                        break;
                    case (int)Actions.Flee:
                        break;
                }
                Console.WriteLine(_enemies[_selectedTarget]._mSprite);
            }
            else
            {
                Console.WriteLine(_allies[_selectedTarget]._mSprite);
            }
            EventManager._downArrow += switchAction;
            EventManager._downArrow -= switchTarget;
            EventManager._enter += SelectMove;
            EventManager._enter -= ExecuteAction;
            checkTurn();
            addSpeed();
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void Update()
        {
            int counter = 0;
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i]._mIsDead)
                {
                    counter++;
                }
            }
            if (counter == _enemies.Count)
            {
                EventManager._downArrow -= switchAction;
                EventManager._enter -= SelectMove;
                Console.WriteLine("Victoire!");
                End();
                return;
            }
            Console.WriteLine("Index de l'attaquant: " + _indexSpeedList);
            Console.WriteLine("Action choisie: " + _selectedAction);
            Console.WriteLine("Ennemi ciblé: " + _selectedTarget);
            if (_characters[_indexSpeedList]._mIsDead)
            {
                checkTurn();
                addSpeed();
                return;
            }
            if(_indexSpeedList >= _allies.Count)
            {
                _allies[0].TakeDamage(10);
                checkTurn();
                addSpeed();
                Console.Clear();
                needsToUpdate?.Invoke();
            }
        }

        public void End()
        {
            needsToUpdate -= Display;
            needsToUpdate -= Update;
            EventManager._downArrow -= switchAction;
            EventManager._rightArrow += EventManager.MoveRight;
            EventManager._leftArrow += EventManager.MoveLeft;
            EventManager._downArrow += EventManager.MoveDown;
            EventManager._upArrow += EventManager.MoveUp;
        }
    }
}