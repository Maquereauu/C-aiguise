namespace C_aiguisé
{
    public class Tank : Role
    {
        public Tank() : base("../../../Content/Role/Player.txt")
        { 
            _id = 2; 
        }

        public override void Update()
        {
            _player.Heal(5);
        }
    }
}