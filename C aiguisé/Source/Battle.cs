using C_aiguisé;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

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
        private int _selectedAttack = 0;
        private int _selectedMagic = 0;
        private int _selectedTarget;
        private int _indexSpeedList;
        private float _maxSpeed;
        public event Action needsToUpdate;
        private List<(int, int)> _hudList;
        private bool Flee = false;
        private bool Enemy = true;

        public Battle(List<Player> allies, List<Summon> summons, List<Enemy> enemies) {
            _hudList = new List<(int, int)>() { (89, 43), (144, 43), (89, 48),(144,48) }; // list of pos (x, y)
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
            _selectedAction = (Actions)(((int)_selectedAction + 2) % (int)Actions.Total);
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void switchActionUp()
        {
            _selectedAction = (Actions)Utils.MathHelper.Modulo(((int)_selectedAction - 2), (int)Actions.Total);
            Console.Clear();
            needsToUpdate?.Invoke();
        }
        public void switchActionRight()
        {
            int totalActionsPerLine = 2;
            int totalActions = (int)Actions.Total;

            int currentActionIndex = (int)_selectedAction;
            int nextActionIndex = (currentActionIndex + 1) % totalActions;

            if ((currentActionIndex / totalActionsPerLine) == (nextActionIndex / totalActionsPerLine))
            {
                _selectedAction = (Actions)nextActionIndex;
            }
            else
            {
                _selectedAction = (Actions)(currentActionIndex - (currentActionIndex % totalActionsPerLine));
            }

            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void switchActionLeft()
        {
            int totalActionsPerLine = 2;
            int totalActions = (int)Actions.Total;

            int currentActionIndex = (int)_selectedAction;
            int previousActionIndex = (currentActionIndex - 1 + totalActions) % totalActions;

            if ((currentActionIndex / totalActionsPerLine) == (previousActionIndex / totalActionsPerLine))
            {
                _selectedAction = (Actions)previousActionIndex;
            }
            else
            {
                _selectedAction = (Actions)(currentActionIndex - (currentActionIndex % totalActionsPerLine) + (totalActionsPerLine - 1));
            }

            Console.Clear();
            needsToUpdate?.Invoke();
        }



        public void switchAttackUp()
        {
            _selectedAttack = Utils.MathHelper.Modulo((_selectedAttack - 1), _characters[_indexSpeedList]._mAttackMoves.Count);
            Console.Clear();
            needsToUpdate?.Invoke();
        }
        public void switchAttackDown()
        {
            _selectedAttack = Utils.MathHelper.Modulo((_selectedAttack + 1), _characters[_indexSpeedList]._mAttackMoves.Count);
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void switchMagicUp()
        {
            _selectedMagic = Utils.MathHelper.Modulo((_selectedMagic - 1), _characters[_indexSpeedList]._mMagicMoves.Count);
            Console.Clear();
            needsToUpdate?.Invoke();
        }
        public void switchMagicDown()
        {
            _selectedMagic = Utils.MathHelper.Modulo((_selectedMagic + 1), _characters[_indexSpeedList]._mMagicMoves.Count);
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
                _selectedTarget = Utils.MathHelper.Modulo((_selectedTarget - 1) , (_enemies.Count));
            }
            else
            {
                _selectedTarget = Utils.MathHelper.Modulo((_selectedTarget - 1), (_allies.Count));
            }
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void Start()
        {
            needsToUpdate += Display;
            needsToUpdate += Update;
            checkTurn();
            addSpeed();
            needsToUpdate?.Invoke();
        }

        public void Display()
        {
            for (int i = 0; i < _allies.Count; i++)
            {
                Console.SetCursorPosition(30, 3 + 10 * i);
                Console.Write(_allies[i]._mName);
                Console.SetCursorPosition(30, 3 + 10 * i + 1);
                Console.Write(_allies[i]._mHp + "/" + _allies[i]._mHpMax);
                Console.SetCursorPosition(30, 3 + 10 * i + 2);
                Console.Write(_allies[i]._mMp + "/" + _allies[i]._mMpMax);
                Console.SetCursorPosition(30, 3 + 10 * i + 3);


                string spriteText = File.ReadAllText(_allies[i]._mSprite);
                string[] lines = spriteText.Split('\n');
                foreach (string line in lines)
                {
                    Console.Write(line);
                    Console.SetCursorPosition(30, Console.CursorTop + 1);
                }
                /*Console.Write(File.ReadAllText(_allies[i]._mSprite));*/
            }
            for (int i = 0; i < _enemies.Count; i++)
            {
                Console.SetCursorPosition(170, 3 + 10 * i);
                Console.Write(_enemies[i]._mName);
                Console.SetCursorPosition(170, 3 + 10 * i + 1);
                Console.Write(_enemies[i]._mHp + "/" + _enemies[i]._mHpMax);
                Console.SetCursorPosition(170, 3 + 10 * i + 2);
                Console.Write(_enemies[i]._mMp + "/" + _enemies[i]._mMpMax);
                Console.SetCursorPosition(170, 3 + 10 * i + 3);
                string spriteText = File.ReadAllText(_enemies[i]._mSprite);
                string[] lines = spriteText.Split('\n');
                foreach (string line in lines)
                {
                    Console.Write(line);
                    Console.SetCursorPosition(170, Console.CursorTop + 1);
                }
                //Console.Write(File.ReadAllText(_enemies[i]._mSprite));
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
                    EventManager._downArrow -= switchActionDown;
                    EventManager._downArrow += switchAttackDown;
                    EventManager._upArrow -= switchActionUp;
                    EventManager._upArrow += switchAttackUp;
                    EventManager._rightArrow -= switchActionRight;
                    EventManager._leftArrow -= switchActionLeft;
                    EventManager._enter -= SelectMove;
                    EventManager._enter += SelectTarget;
                    EventManager._backspace += Cancel1;
                    needsToUpdate += ShowAttack;
                    Console.Clear();
                    needsToUpdate?.Invoke();
                    break;
                case (int)Actions.Magic:
                    Console.WriteLine("magic!");
                    EventManager._downArrow -= switchActionDown;
                    EventManager._downArrow += switchMagicDown;
                    EventManager._upArrow -= switchActionUp;
                    EventManager._upArrow += switchMagicUp;
                    EventManager._rightArrow -= switchActionRight;
                    EventManager._leftArrow -= switchActionLeft;
                    EventManager._enter -= SelectMove;
                    EventManager._enter += SelectTarget;
                    EventManager._backspace += Cancel1;
                    needsToUpdate += ShowMagic;
                    Console.Clear();
                    needsToUpdate?.Invoke();
                    break;
                case (int)Actions.Item:
                    Console.WriteLine("item!");
                    break;
                case (int)Actions.Flee:
                    Console.WriteLine("flee!");
                    Flee = true;
                    needsToUpdate?.Invoke();
                    break;
            }
/*            EventManager._downArrow -= switchActionDown;
            EventManager._downArrow += switchTargetDown;
            EventManager._upArrow -= switchActionUp;
            EventManager._upArrow += switchTargetUp;
            EventManager._enter -= SelectMove;
            EventManager._enter += ExecuteAction;
            EventManager._backspace += Cancel;
            Console.Clear();
            needsToUpdate?.Invoke();*/
        }
        public void SelectTarget()
        {
            if (Enemy)
            {
                switch ((int)_selectedAction)
                {
                    case (int)Actions.Attack:
                        EventManager._downArrow -= switchAttackDown;
                        EventManager._downArrow += switchTargetDown;
                        EventManager._upArrow -= switchAttackUp;
                        EventManager._upArrow += switchTargetUp;
                        EventManager._enter -= SelectTarget;
                        EventManager._enter += ExecuteAction;
                        EventManager._backspace += Cancel2;
                        EventManager._backspace -= Cancel1;
                        Console.Clear();
                        needsToUpdate?.Invoke(); 
                        break;
                    case (int)Actions.Magic:
                        if (_allies[_indexSpeedList]._mMp < _allies[_indexSpeedList]._mMagicMoves[_selectedMagic]._mMpCost)
                            return;
                        EventManager._downArrow -= switchMagicDown;
                        EventManager._downArrow += switchTargetDown;
                        EventManager._upArrow -= switchMagicUp;
                        EventManager._upArrow += switchTargetUp;
                        EventManager._enter -= SelectTarget;
                        EventManager._enter += ExecuteAction;
                        EventManager._backspace += Cancel2;
                        EventManager._backspace -= Cancel1;
                        Console.Clear();
                        needsToUpdate?.Invoke();
                        break;
                    case (int)Actions.Item:
                        break;
                    case (int)Actions.Flee:
                        break;
                }
            }
            else
            {
                Console.WriteLine(_allies[_selectedTarget]._mName);
            }
            /*            EventManager._downArrow += switchActionDown;
                        EventManager._downArrow -= switchTargetDown;
                        EventManager._upArrow += switchActionUp;
                        EventManager._upArrow -= switchTargetUp;
                        EventManager._enter += SelectMove;
                        EventManager._enter -= ExecuteAction;
                        EventManager._backspace -= Cancel;*/
            /*            checkTurn();
                        addSpeed();*/
            needsToUpdate += ShowTarget;
            Console.Clear();
            needsToUpdate?.Invoke();
        }

        public void ShowAttack()
        {
            Console.SetCursorPosition(90, 19);
            Console.Write("╔" + new string('═', 40) + "╗");
            for (int i = 0; i < 10; i++)
            {
                    Console.SetCursorPosition(90, 20 + i);
                    Console.Write("║" + new string(' ', 40) + "║");
            }
            Console.SetCursorPosition(90, 30);
            Console.Write("╚" + new string('═', 40) + "╝");
            Console.SetCursorPosition(100, 20);
            for (int i = 0; i < _characters[_indexSpeedList]._mAttackMoves.Count; i++)
            { 
                if(i == _selectedAttack)
                {
                    Console.SetCursorPosition(100, 21 + i);
                    Console.Write(">" + _characters[_indexSpeedList]._mAttackMoves[i]._mName);
                }
                else
                {
                    Console.SetCursorPosition(100, 21 + i);
                    Console.Write(_characters[_indexSpeedList]._mAttackMoves[i]._mName);
                }
            }
        }

        public void ShowMagic()
        {
            Console.SetCursorPosition(90, 19);
            Console.Write("╔" + new string('═', 40) + "╗");
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(90, 20 + i);
                Console.Write("║" + new string(' ', 40) + "║");
            }
            Console.SetCursorPosition(90, 30);
            Console.Write("╚" + new string('═', 40) + "╝");
            Console.SetCursorPosition(100, 20);
            for (int i = 0; i < _characters[_indexSpeedList]._mMagicMoves.Count; i++)
            {
                if (i == _selectedMagic)
                {
                    Console.SetCursorPosition(100, 21 + i);
                    Console.Write(">" + _characters[_indexSpeedList]._mMagicMoves[i]._mName);
                }
                else
                {
                    Console.SetCursorPosition(100, 21 + i);
                    Console.Write(_characters[_indexSpeedList]._mMagicMoves[i]._mName);
                }
            }
        }

        public void ShowTarget()
        {
            switch (_selectedAction)
            {
                case Actions.Attack:
                    if (_characters[_indexSpeedList]._mAttackMoves[_selectedAttack]._mIsAoe)
                    {
                        for (int i = 0; i < _enemies.Count; i++)
                        {
                            Console.SetCursorPosition(169, 3 + 10 * i);
                            Console.Write(">");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(169, 3 + 10 * _selectedTarget);
                        Console.Write(">");
                    }
                        break;

                case Actions.Magic:
                    if (_characters[_indexSpeedList]._mMagicMoves[_selectedMagic]._mIsAoe)
                    {
                        for (int i = 0; i < _enemies.Count; i++)
                        {
                            Console.SetCursorPosition(169, 3 + 10 * i);
                            Console.Write(">");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(169, 3 + 10 * _selectedTarget);
                        Console.Write(">");
                    }
                    break;
            }
        }

        public void ExecuteAction()
        {
            if (Enemy)
            {
                switch ((int)_selectedAction)
                {
                    case (int)Actions.Attack:

                        if (_enemies[_selectedTarget]._mHp <= 0)
                        {
                            return;
                        }
                        if (_characters[_indexSpeedList]._mAttackMoves[_selectedAttack]._mIsAoe)
                        {
                            for (int i = 0; i < _enemies.Count; i++)
                            {
                                _enemies[i].TakeDamage(_allies[_indexSpeedList].Attack(_allies[_indexSpeedList]._mAttackMoves[_selectedAttack], _enemies[i]));
                            }
                        }
                        else
                        {
                            _enemies[_selectedTarget].TakeDamage(_allies[_indexSpeedList].Attack(_allies[_indexSpeedList]._mAttackMoves[_selectedAttack], _enemies[_selectedTarget]));
                        }
                        break;
                    case (int)Actions.Magic:
                        if (_enemies[_selectedTarget]._mHp <= 0)
                        {
                            return;
                        }
                        if (_characters[_indexSpeedList]._mMagicMoves[_selectedMagic]._mIsAoe)
                        {
                            for (int i = 0; i < _enemies.Count; i++)
                            {
                                _enemies[i].TakeDamage(_allies[_indexSpeedList].Attack(_allies[_indexSpeedList]._mMagicMoves[_selectedMagic], _enemies[i]));
                            }
                        }
                        else
                        {
                            _enemies[_selectedTarget].TakeDamage(_allies[_indexSpeedList].Attack(_allies[_indexSpeedList]._mMagicMoves[_selectedAttack], _enemies[_selectedTarget]));
                        }
                        break;
                    case (int)Actions.Item:
                        break;
                    case (int)Actions.Flee:
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
            EventManager._rightArrow += switchActionRight;
            EventManager._leftArrow += switchActionLeft;
            EventManager._enter += SelectMove;
            EventManager._enter -= ExecuteAction;
            EventManager._backspace -= Cancel2;
            needsToUpdate -= ShowAttack;
            needsToUpdate -= ShowMagic;
            needsToUpdate -= ShowTarget;
            checkTurn();
            addSpeed();
            Console.Clear();
            needsToUpdate?.Invoke();
        }
        public void Cancel1()
        {
            EventManager._backspace -= Cancel1;
            EventManager._downArrow += switchActionDown;
            EventManager._downArrow -= switchAttackDown;
            EventManager._downArrow -= switchMagicDown;
            //EventManager._downArrow -= switchItemDown;
            EventManager._upArrow += switchActionUp;
            EventManager._upArrow -= switchAttackUp;
            EventManager._upArrow -= switchMagicUp;
            EventManager._rightArrow += switchActionRight;
            EventManager._leftArrow += switchActionLeft;
            //EventManager._upArrow -= switchItemUp;
            needsToUpdate -= ShowAttack;
            needsToUpdate -= ShowMagic;
            EventManager._enter += SelectMove;
            EventManager._enter -= SelectTarget;
            Console.Clear();
            needsToUpdate?.Invoke();
        }
        public void Cancel2()
        { 
            EventManager._backspace -= Cancel2;
            EventManager._downArrow -= switchAttackDown;
            EventManager._downArrow -= switchMagicDown;
            //EventManager._downArrow -= switchItemDown;
            EventManager._downArrow -= switchTargetDown;
            /*EventManager._downArrow += switchActionDown;*/

            EventManager._upArrow -= switchAttackUp;
            EventManager._upArrow -= switchMagicUp;
            //EventManager._upArrow -= switchItemup;
            EventManager._upArrow -= switchTargetUp;
            /*EventManager._upArrow += switchActionUp;*/


            /*EventManager._rightArrow += switchActionRight;
            EventManager._leftArrow += switchActionLeft;*/

            EventManager._enter += SelectMove;
            EventManager._enter -= ExecuteAction;
            needsToUpdate -= ShowTarget;
            Cancel1();
            Console.Clear();
            needsToUpdate?.Invoke();

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
                EventManager._rightArrow -= switchActionRight;
                EventManager._leftArrow -= switchActionLeft;
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
                EventManager._rightArrow -= switchActionRight;
                EventManager._leftArrow -= switchActionLeft;
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
                float exp = 0;
                for (int i = 0; i < _enemies.Count; i++)
                {
                    exp += _enemies[i]._mExp;
                }
                for (int i = 0; i < _allies.Count;i++)
                {
                    _allies[i].AddExp((int)exp);
                    _allies[i].LevelUp();
                }

                EventManager._downArrow -= switchActionDown;
                EventManager._upArrow -= switchActionUp;
                EventManager._rightArrow -= switchActionRight;
                EventManager._leftArrow -= switchActionLeft;
                EventManager._enter -= SelectMove;
                Console.WriteLine("Victoire!");
                End();
                return;
            }
            Console.SetCursorPosition(70, 40);
            Console.Write("╔" + new string('═', 100) + "╗");
            for(int i = 0; i < 10;i++)
            {
                if (i == 2)
                {
                    Console.SetCursorPosition(70, 41 + i);
                    Console.Write("║" + new string(' ', 20) + "Attack"/*6*/ + new string(' ', 49) + "Magic"/*5*/ + new string(' ', 20) + "║");
                }else if(i == 7)
                {
                    Console.SetCursorPosition(70, 41 + i);
                    Console.Write("║" + new string(' ', 20) + "Item"/*4*/ + new string(' ', 51) + "Flee"/*4*/ + new string(' ', 21) + "║");
                }
                else
                {
                    Console.SetCursorPosition(70, 41 + i);
                    Console.Write("║" + new string(' ', 100) + "║");
                }
            }
            Console.SetCursorPosition(70, 51);
            Console.Write("╚" + new string('═', 100) + "╝");

            Console.SetCursorPosition(_hudList[(int)_selectedAction].Item1, _hudList[(int)_selectedAction].Item2);
            Console.Write(">");
            /*            Console.WriteLine("Index de l'attaquant: " + _indexSpeedList);
                        Console.WriteLine("Action choisie: " + _selectedAction);
                        Console.WriteLine("Ennemi ciblé: " + _selectedTarget);*/
            if (_characters[_indexSpeedList]._mIsDead)
            {
                checkTurn();
                addSpeed();
                return;
            }
            if(_indexSpeedList >= _allies.Count + _summons.Count)
            {
                Random random = new Random();
                while (true)
                {
                    int target = random.Next(_allies.Count);
                    if (_allies[target]._mIsDead == false)
                    {
                        _allies[target].TakeDamage(_characters[_indexSpeedList].Attack(_characters[_indexSpeedList]._mAttackMoves[_selectedAttack], _allies[target]));
                        checkTurn();
                        addSpeed();
                        Console.Clear();
                        needsToUpdate?.Invoke();
                        break;
                    }
                }
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