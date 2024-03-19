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
        private List<Actions> _actions = new List<Actions> { Actions.Attack , Actions.Magic,Actions.Item,Actions.Flee };
        private Actions _selectedAction = Actions.Attack;
        private int _indexSpeedList;
        private float _maxSpeed;
        public Battle(List<Player> allies, List<Summon> summons, List<Enemy> enemies) {
            _allies = allies;
            _summons = summons;
            _enemies = enemies;
            _speeds = new List<float>();
            _baseSpeeds = new List<float>();
            for (int i = 0; i < allies.Count; i++)
            {
                _speeds.Add(_allies[i]._mSpeed);
                _baseSpeeds.Add(_allies[i]._mSpeed);
            }
            for (int i = 0; i < summons.Count; i++)
            {
                _speeds.Add(summons[i]._mSpeed);
                _baseSpeeds.Add(summons[i]._mSpeed);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                _speeds.Add(enemies[i]._mSpeed);
                _baseSpeeds.Add(enemies[i]._mSpeed);
            }
            _indexSpeedList = 0;
            _maxSpeed = 0;
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
        }

        public void Start()
        {
            EventManager._leftArrow += switchAction;
        }


        public void Update()
        {
            Console.WriteLine("Index de l'attaquant: " + _indexSpeedList);
            Console.WriteLine("Action choisie: " + _selectedAction);
            checkTurn();
            addSpeed();
        }

        public void End()
        {
            EventManager._leftArrow -= switchAction;
        }
    }
}