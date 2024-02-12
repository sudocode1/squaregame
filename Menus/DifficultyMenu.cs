using Raylib_cs;
using SquareGame;
using System;

namespace Menus 
{
    public static class DifficultyMenu 
    {
        private static readonly string[] menuOptions = ["easy", "medium", "hard", "extreme", "back"];
        private static int menuNavigationPoint = 0;
        private static void HandleSelection()
        {
            switch(menuOptions[menuNavigationPoint])
            {
                case "easy":

                    break;

                case "medium":

                    break;

                case "hard":

                    break;
                
                case "extreme":

                    break;
                
                case "back":
                    Program.currentMenu = "MainMenu";
                    break;
            }
        }

        public static void InputHandler(int keyPressed)
        {
            switch ((Raylib_cs.KeyboardKey)keyPressed) {
                case Raylib_cs.KeyboardKey.Up:
                    if((menuNavigationPoint - 1) != -1) {
                        menuNavigationPoint--;
                    }
                    break;
                
                case Raylib_cs.KeyboardKey.Down:
                    if((menuNavigationPoint + 1) != (menuOptions.Length)) {
                        menuNavigationPoint++;
                    }
                    break;
                
                case Raylib_cs.KeyboardKey.Enter:
                    HandleSelection();
                    break;
            }
        }

        public static void Render() 
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
            int menuCounter = 0;
            foreach (var item in menuOptions)
            {
                Raylib_cs.Color menuTextColor = menuCounter == menuNavigationPoint ? Raylib_cs.Color.Red : Raylib_cs.Color.Black;
                Raylib.DrawText(item, 15, 17+(35*menuCounter), 44, menuTextColor);
                menuCounter++;    
            }
            Raylib.EndDrawing();
        }
    }
}