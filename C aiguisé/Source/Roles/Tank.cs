namespace C_aiguisé
{
    public class Tank : Role
    {
        public Tank() : base("../../../Content/Role/Player.txt")
        { 
            _id = 2;
        }

        public void setAttack()
        {
            _player.AddAttack(new AttackMove(0, 40, false, true, "yo"));
            _player.AddAttack(new AttackMove(0, 20, false, true, "D:"));
            _player.AddMagic(new MagicMove(0, 40, 20, false, true, "yo"));
            _player.AddMagic(new MagicMove(0, 20, 15, false, true, "D:"));
        }
        public override void Update()
        {
            _player.Heal(5);
        }
    }
}