﻿using System;
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
            Raylib.SetTargetFPS(60);
            Raylib.SetExitKey(0);
            
            while (running && !Raylib.WindowShouldClose()) 
            {
                // Raylib.BeginDrawing();
                // Raylib.ClearBackground(Color.White);
                // Raylib.DrawText("test", 14, 14, 20, Color.Black);
                // Raylib.DrawText("test27", 35, 14, 20, Color.Black);
                // Raylib.EndDrawing();
                if (Gameplay.Gameplay.gameplayOngoing)
                {
                    Gameplay.Gameplay.InputHandler(Raylib.GetKeyPressed());
                    Gameplay.Gameplay.ProcessGameplay();
                }
                else
                {
                    switch (currentMenu) 
                    {
                        case "MainMenu":
                            Menus.MainMenu.InputHandler(Raylib.GetKeyPressed());
                            Menus.MainMenu.Render();
                            break;
                        
                        case "DifficultyMenu":
                            Menus.DifficultyMenu.InputHandler(Raylib.GetKeyPressed());
                            Menus.DifficultyMenu.Render();
                            break;

                        case "ResultsScreen":
                            Menus.ResultsScreen.InputHandler(Raylib.GetKeyPressed());
                            Menus.ResultsScreen.Render();
                            break;
                        
                        default:
                            Raylib.BeginDrawing();
                            Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
                            Raylib.DrawText("fallback", 120, 55, 40, Raylib_cs.Color.Red);
                            Raylib.EndDrawing();
                            break;
                    }
                }
            }
            
            Raylib.CloseWindow();
        }
    }
}