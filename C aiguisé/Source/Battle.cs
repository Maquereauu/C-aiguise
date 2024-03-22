using C_aiguisé.Source;
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

        private bool Flee = false;
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
            if(_indexSpeedList < _allies.Count)
            {
                _allies[_indexSpeedList]._mRole.Update();
                _allies[_indexSpeedList]._mSummonBar += 10;
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

        public void switchActionDown()
        {
            _selectedAction = (Actions)(((int)_selectedAction + 1) % (int)Actions.Total);
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void switchActionUp()
        {
            _selectedAction = (Actions)MathHelper.Mod(((int)_selectedAction - 1), (int)Actions.Total);
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void switchTargetDown()
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

        public void switchTargetUp()
        {
            if (Enemy)
            {
                _selectedTarget = MathHelper.Mod((_selectedTarget - 1) , (_enemies.Count));
            }
            else
            {
                _selectedTarget = MathHelper.Mod((_selectedTarget - 1), (_allies.Count));
            }
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void Start()
        {
            needsToUpdate += Display;
            needsToUpdate += Update;
            needsToUpdate?.Invoke();
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < _allies.Count; i++)
            {
                Console.WriteLine(_allies[i]._mName);
                Console.WriteLine(_allies[i]._mSprite + " " + _allies[i]._mHp + "/" + _allies[i]._mHpMax);
            }
            for (int i = 0; i < _enemies.Count; i++)
            {
                Console.WriteLine(_enemies[i]._mName);
                Console.WriteLine(_enemies[i]._mSprite + " " + _enemies[i]._mHp + "/" + _enemies[i]._mHpMax);
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
            EventManager._downArrow -= switchActionDown;
            EventManager._downArrow += switchTargetDown;
            EventManager._upArrow -= switchActionUp;
            EventManager._upArrow += switchTargetUp;
            EventManager._enter -= SelectMove;
            EventManager._enter += ExecuteAction;
            EventManager._backspace += Cancel;
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
                        if(_enemies[_selectedTarget]._mHp <= 0)
                        {
                            return;
                        }
                        _enemies[_selectedTarget].TakeDamage(_allies[_indexSpeedList].Attack());
                        break;
                    case (int)Actions.Magic:
                        break;
                    case (int)Actions.Item:
                        break;
                    case (int)Actions.Flee:
                        Flee = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine(_allies[_selectedTarget]._mSprite);
            }
            EventManager._downArrow += switchActionDown;
            EventManager._downArrow -= switchTargetDown;
            EventManager._upArrow += switchActionUp;
            EventManager._upArrow -= switchTargetUp;
            EventManager._enter += SelectMove;
            EventManager._enter -= ExecuteAction;
            EventManager._backspace -= Cancel;
            checkTurn();
            addSpeed();
            Console.Clear();
            needsToUpdate?.Invoke();
        }
        public void Cancel()
        {
            EventManager._backspace -= Cancel;
            EventManager._downArrow += switchActionDown;
            EventManager._downArrow -= switchTargetDown;
            EventManager._upArrow += switchActionUp;
            EventManager._upArrow -= switchTargetUp;
            EventManager._enter += SelectMove;
            EventManager._enter -= ExecuteAction;
        }
        public void Update()
        {
            if(Flee)
            {
                for(int i = 0; i<_enemies.Count;i++)
                {
                    _enemies[i].Heal();
                }

                EventManager._downArrow -= switchActionDown;
                EventManager._upArrow -= switchActionUp;
                EventManager._enter -= SelectMove;
                Console.WriteLine("Vous prenez la fuite");
                End();
                return;
            }
            int counter = 0;
            for (int i = 0; i < _allies.Count; i++)
            {
                if (_allies[i]._mIsDead)
                {
                    counter++;
                }
            }
            if (counter == _allies.Count)
            {
                EventManager._downArrow -= switchActionDown;
                EventManager._upArrow -= switchActionUp;
                EventManager._enter -= SelectMove;
                Console.WriteLine("Défaite..");
                End();
                return;
            }
            counter = 0;
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i]._mIsDead)
                {
                    counter++;
                }
            }
            if (counter == _enemies.Count)
            {
                EventManager._downArrow -= switchActionDown;
                EventManager._upArrow -= switchActionUp;
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
            if(_indexSpeedList >= _allies.Count + _summons.Count)
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
            SceneManager.SwitchScene("Game");
        }
    }
}