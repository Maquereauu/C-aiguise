namespace C_aiguisé
{
    public class WhiteWizard : Role
    {

       public WhiteWizard() : base("../../../Content/Role/WhiteWizard.txt")
        {
            _id = 3; 
        }
        public void setAttack()
        {
            _player.AddAttack(new AttackMove(0, 500, false, true, "Purple"));
            _player.AddMagic(new MagicMove(0, 250, 50, true, true, "Red"));
            _player.AddMagic(new MagicMove(0, 200, 100, false, true, "Blue"));
            _player._mDodgeChance = 100;
        }

        public override void Update()
        {
            base.Update();
            _player.Heal();

        }
    }
}