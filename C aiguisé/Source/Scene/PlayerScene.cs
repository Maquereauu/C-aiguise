namespace C_aiguisé
{
    class PlayerScene : Scene
    {
        private int _index;
        private List<(int, int)> _hudPosList;
        private List<Player> _hudPlayerList;
        private (int, int) _hudPos;

        public PlayerScene() : base("PlayerScene")
        {
            _index = 0;
            _hudPlayerList = new List<Player>();
            _hudPosList = new List<(int, int)>();
            for (int i = 0; i < EntityManager.players.Count; i++)
            {
                _hudPlayerList.Add(EntityManager.players[i]);
                _hudPosList.Add((0, i + 1));
            }
            _hudPos = (_hudPosList[0].Item1, _hudPosList[0].Item2);
        }
        public override void Init()
        {
        }
        public override void PreUpdate()
        {
            base.PreUpdate();
            Console.Clear();
        }
        public override void Update()
        {
            Console.SetCursorPosition(_hudPos.Item1, _hudPos.Item2);
            Console.Write(">");

            for (int i = 0;i < _hudPlayerList.Count; i++)
            {
                Console.SetCursorPosition(_hudPosList[i].Item1 + 10, _hudPosList[i].Item2);
                Console.Write(_hudPlayerList[i]._mName + "\n\n");
            }

        }

        public override void PostUpdate()
        {
            base.PostUpdate();
        }
        public override void LoadScene()
        {
            EventManager._menu += Exit;
            EventManager._upArrow += SwitchTop;
            EventManager._downArrow += SwitchBottom;
            EventManager._enter += Confirm;
        }
        public override void UnLoad()
        {
            base.UnLoad();
            _index = 0;
            EventManager._menu -= Exit;
            EventManager._upArrow -= SwitchTop;
            EventManager._downArrow -= SwitchBottom;
            EventManager._enter -= Confirm;
        }

        public void Exit()
        {
            SceneManager.SwitchScene("MainMenu");
        }

        public void Confirm()
        {
            SceneManager.SwitchScene(_hudPlayerList[_index]._mName + "StatsScene");
            _hudPos = (_hudPosList[0].Item1, _hudPosList[0].Item2);
        }
        public void SwitchTop()
        {
            _index = Utils.MathHelper.Modulo(_index - 1, _hudPosList.Count);
            _hudPos = _hudPosList[_index];
        }
        public void SwitchBottom()
        {
            _index = Utils.MathHelper.Modulo(_index + 1, _hudPosList.Count);
            _hudPos = _hudPosList[_index];

        }

    }
}
