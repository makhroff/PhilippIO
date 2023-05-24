using SFML.Graphics;

namespace PhilippIO.Scripts
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new(1920, 1080, "Game", Color.White);
            game.Run();
        }
    }
}