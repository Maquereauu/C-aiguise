﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_aiguisé
{
    class PlayerStatsScene : Scene
    {
        Player _player;
        public PlayerStatsScene(Player player) : base(player._mName + "StatsScene")
        {
            _player = player;
        }
        public override void Init()
        {
        }
        public override void PreUpdate()
        {
            base.PreUpdate();
        }
        public override void Update()
        {
            Display();
        }

        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            EventManager._menu += Exit;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            EventManager._menu -= Exit;
        }

        public void Exit()
        {
            SceneManager.SwitchScene(SceneManager._mPreviousScene.GetName());
        }

        public void Display()
        {
            Console.SetCursorPosition(0, 0);

            string sprite = File.ReadAllText(_player._mSprite);
            foreach (string line in sprite.Split("\n"))
            {
                Console.SetCursorPosition(5, Console.CursorTop + 1);
                Console.Write(line);
            }

            Console.SetCursorPosition(0, Console.CursorTop + 5);
            Console.Write("Nom : " + _player._mName + "\n");
            Console.Write("Level : " + _player._mLevel + "\n");
            Console.Write("Exp : " + _player._mExp + "\n");
            Console.Write("Exp avant level up : " + _player._mExpToLevelUp + "\n");
            Console.Write("Hp : " + _player._mHp + "\n");
            Console.Write("MaxHp : " + _player._mHpMax + "\n");
            Console.Write("Mp : " + _player._mMp + "\n");
            Console.Write("MaxMp : " + _player._mMpMax + "\n");
            Console.Write("Chance de critique : " + _player._mCritChance + "\n");
            Console.Write("Dégât critique : " + _player._mCritDamage + "\n");
            Console.Write("Chance d'esquive : " + _player._mDodgeChance + "\n");
            Console.Write("Vitesse : " + _player._mSpeed + "\n");
            Console.Write("Type : " + _player._mType + "\n");
            Console.Write("Vivant : " + !_player._mIsDead + "\n");
            for (int i = 0; i < _player._mAttackMoves.Count; i++)
            {
                Console.Write("Attaque : \n");
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 20, Console.GetCursorPosition().Top);
                Console.Write("Nom : " + _player._mAttackMoves[i]._mName + "\n");
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 20, Console.GetCursorPosition().Top);
                Console.Write("Dégâts : " + _player._mAttackMoves[i]._mDamage + "\n");
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 20, Console.GetCursorPosition().Top);
                Console.Write("Dégat de zone : " + _player._mAttackMoves[i]._mIsAoe + "\n");
                Console.Write("\n");
            }

            for (int i = 0; i < _player._mMagicMoves.Count; i++)
            {
                Console.Write("Attaque magique : \n");
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 20, Console.GetCursorPosition().Top);
                Console.Write("Nom : " + _player._mMagicMoves[i]._mName + "\n");
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 20, Console.GetCursorPosition().Top);
                Console.Write("Dégâts : " + _player._mMagicMoves[i]._mDamage + "\n");
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 20, Console.GetCursorPosition().Top);
                Console.Write("Dégat de zone : " + _player._mMagicMoves[i]._mIsAoe + "\n");
                Console.SetCursorPosition(Console.GetCursorPosition().Left + 20, Console.GetCursorPosition().Top);
                Console.Write("Coût en mp : " + _player._mMagicMoves[i]._mMpCost + "\n");
                Console.Write("\n");
            }
        }
    }

}
