namespace Level
{
    public class Level_Lun : ILevel_System
    {
        public Level_Lun(int exp):base(exp)
        {
            Initial();
        }

        public override void Initial()
        {
            chrIdx = 0;
            expIntervals = new int[] { 0, 300, 800, 1800, 3800, 7500 };
            atkIntervals = new int[] { 10, 20, 35, 50, 75, 100 };
            hpIntervals = new int[] { 100, 150, 200, 250, 300, 350 };
            mpIntervals = new int[] { 20, 30, 40, 50, 60, 70 };
            //Set each value's Levels intervals
            base.Initial();
        }
    }
}