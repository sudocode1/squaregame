using System;
using Raylib_cs;
using Menus;

namespace SquareGame
{
    class Program
    {
        public static bool running = true;
        public static string currentMenu = "MainMenu";
        public static void Main()
        {
            Raylib.InitWindow(800, 400, "test");

            
            while (running && !Raylib.WindowShouldClose()) 
            {
                // Raylib.BeginDrawing();
                // Raylib.ClearBackground(Color.White);
                // Raylib.DrawText("test", 14, 14, 20, Color.Black);
                // Raylib.DrawText("test27", 35, 14, 20, Color.Black);
                // Raylib.EndDrawing();

                switch (currentMenu) {
                    case "MainMenu":
                        Menus.MainMenu.InputHandler(Raylib.GetKeyPressed());
                        Menus.MainMenu.Render();
                        break;
                    
                    default:
                        Raylib.DrawText("fallback", 120, 55, 40, Raylib_cs.Color.Red);
                        break;
                }
            }
            
            Raylib.CloseWindow();
        }
    }
}