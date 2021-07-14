using ImGuiNET;

namespace GameSharp
{
    public class Program : Game
    {
        static void Main(string[] args)
        {
            using (var program = new Program())
            {
                program.Run(new GameConfig() 
                {
                    WindowTitle = "Test",
                    WindowWidth = 800,
                    WindowHeight = 600
                });
            }
        }
    }
}