namespace GameUI
{
    public class Program
    {
        public static void Main() 
        {
            StartApp();
        }
        public static void StartApp()
        {
            GameFormD game = new GameFormD();
            game.ShowDialog();
        }
    }
}