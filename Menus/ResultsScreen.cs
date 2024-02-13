using Raylib_cs;
using SquareGame;
using System;

namespace Menus {
    public static class ResultsScreen
    {
        private static int hits = 0;
        private static int misses = 0;
        private static string[] menuOptions = ["restart", "quit"];
        private static int menuNavigationPoint = 0;
        
        public static void Setup(int rHits, int rMisses)
        {
            hits = rHits;
            misses = rMisses;
        }

        public static void InputHandler(int keyPressed)
        {
            switch ((Raylib_cs.KeyboardKey)keyPressed)
            {
                case Raylib_cs.KeyboardKey.Up:
                    if ((menuNavigationPoint - 1) != -1)
                    {
                        menuNavigationPoint--;
                    }
                    break;

                case Raylib_cs.KeyboardKey.Down:
                    if ((menuNavigationPoint + 1) != (menuOptions.Length))
                    {
                        menuNavigationPoint++;
                    }
                    break;

                case Raylib_cs.KeyboardKey.Enter:
                    HandleSelection();
                    break;
            }
        }

        private static void HandleSelection()
        {
            switch (menuOptions[menuNavigationPoint])
            {
                case "restart":
                    Gameplay.Gameplay.RestartGameplay();
                    break;

                case "quit":
                    Program.currentMenu = "DifficultyMenu";
                    break;
            }
        }

        public static void Render()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.RayWhite);

            Raylib.DrawText($"{hits} hits", 20, 20, 40, Raylib_cs.Color.DarkGreen);
            Raylib.DrawText($"{misses} misses", 20, 60, 40, Raylib_cs.Color.Red);

            if (misses == 0)
            {
                Raylib.DrawText("perfect", 20, 100, 40, Raylib_cs.Color.Orange);
            }

            int resultsMenuCounter = 0;
            foreach (string option in menuOptions)
            {
                if (resultsMenuCounter == menuNavigationPoint)
                {
                    Raylib.DrawText(option, 20, 200 + (40 * resultsMenuCounter), 40, Raylib_cs.Color.Red);
                }
                else
                {
                    Raylib.DrawText(option, 20, 200 + (40 * resultsMenuCounter), 40, Raylib_cs.Color.Black);
                }
                    
                resultsMenuCounter++;
            }

            Raylib.EndDrawing();
        }
    }
}