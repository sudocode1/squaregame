using System;
using Raylib_cs;

namespace Gameplay 
{
    public static class OptionsOverlay 
    {
        private static string[] options = ["resume", "quit"];
        private static int navigationPoint = 0;
        
        public static void Setup() {
            navigationPoint = 0;
        }
        
        public static void InputHandler(int keyPressed) 
        {
            switch ((Raylib_cs.KeyboardKey)keyPressed)
            {
                case Raylib_cs.KeyboardKey.Up:
                    if((navigationPoint - 1) != -1) 
                    {
                        navigationPoint--;
                    }
                    break;

                case Raylib_cs.KeyboardKey.Down:
                    if((navigationPoint + 1) != (options.Length))
                    {
                        navigationPoint++;
                    }
                    break;

                case Raylib_cs.KeyboardKey.Enter:
                    HandleSelection();
                    break;
            }
        }
        
        public static void Render() 
        {
            Raylib_cs.Color bgColor = new Raylib_cs.Color(0, 0, 0, 50);
            Raylib.DrawRectangle(0, 0, Raylib.GetRenderWidth(), Raylib.GetRenderHeight(), bgColor);
            int optionsCounter = 0;
            foreach (var option in options)
            {
                if (options[navigationPoint] == option)
                {
                    Raylib.DrawText(option, 20, 20+(40*optionsCounter), 40, Raylib_cs.Color.Red);    
                }

                else
                {
                    Raylib.DrawText(option, 20, 20+(40*optionsCounter), 40, Raylib_cs.Color.Black);       
                }

                optionsCounter++;
            }
        }

        private static void HandleSelection() {
            switch(options[navigationPoint]) {
                case "resume":
                    Gameplay.gameplayPaused = false;
                    break;
                
                case "quit":
                    Gameplay.gameplayOngoing = false;
                    break;
            }
        }
    }
}