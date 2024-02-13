using System;
using Raylib_cs;
using SquareGame;

namespace Gameplay
{
    class Square 
    {
        public bool active;
        public long startTime;
        public long endTime;
    
        public Square(bool sActive, long sStartTime, long sEndTime) {
            active = sActive;
            startTime = sStartTime;
            endTime = sEndTime;
        }
    }
    public static class Gameplay {
        private static string? difficulty = null;
        private static int hits = 0;
        private static int misses = 0;
        public static bool gameplayOngoing = false;
        private static List<Square> currentSquares = new List<Square> {}; 
        public static bool gameplayPaused = false;
        private static long startTime;
        private static long pausedAt;
        private static long endTime;
        //public static bool GameplayOngoing { get {return gameplayOngoing;} set {gameplayOngoing = value;} }


        public static void StartGameplay(string? diff)
        {
            if (diff == null) return;
            difficulty = diff;
            currentSquares = new List<Square> {};
            hits = 0;
            misses = 0;
            switch (diff)
            {
                case "easy":
                    for (int i = 0; i < 4; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }

                    startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    endTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 120000; // 2 minutes
                    break;
                
                case "medium":
                    for (int i = 0; i < 6; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }

                    startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    endTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 120000; // 2 minutes
                    break;

                case "hard":
                    for (int i = 0; i < 8; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }

                    startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    endTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 120000; // 2 minutes
                    break;

                case "extreme":
                    for (int i = 0; i < 10; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }

                    startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    endTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 120000; // 2 minutes
                    break;
            }   

            gameplayPaused = false;
            gameplayOngoing = true;
        }

        public static void RestartGameplay()
        {
            if (difficulty != null)
            {
                StartGameplay(difficulty);
            }
        }

        public static void ProcessGameplay()
        {
            if (!gameplayPaused) {
                // process timings, etc
                foreach (Square square in currentSquares)
                {
                    if (!square.active && new Random().NextDouble() >= 0.98)
                    {
                        square.active = true;
                        square.startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        square.endTime = square.startTime + 1000;
                    }

                    if (square.active && square.endTime <= DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
                    {
                        square.active = false;
                        misses++;
                    }

                    if (endTime <= DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
                    {
                        gameplayOngoing = false;
                        Menus.ResultsScreen.Setup(hits, misses);
                        Program.currentMenu = "ResultsScreen";
                    }
                    
                }                
            }
            Render();
        }

        public static void InputHandler(int keyPressed) {
            if (gameplayPaused)
            {
                OptionsOverlay.InputHandler(keyPressed);
            }

            else
            {
                switch ((Raylib_cs.KeyboardKey)keyPressed) {
                    case Raylib_cs.KeyboardKey.Escape:
                        OptionsOverlay.Setup();
                        gameplayPaused = true;
                        pausedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        break;

                    case Raylib_cs.KeyboardKey.One:
                    case Raylib_cs.KeyboardKey.Two:
                    case Raylib_cs.KeyboardKey.Three:
                    case Raylib_cs.KeyboardKey.Four:
                    case Raylib_cs.KeyboardKey.Five:
                    case Raylib_cs.KeyboardKey.Six:
                    case Raylib_cs.KeyboardKey.Seven:
                    case Raylib_cs.KeyboardKey.Eight:
                    case Raylib_cs.KeyboardKey.Nine:
                    case Raylib_cs.KeyboardKey.Zero:
                        ActiveGameplayInputHandler(keyPressed);
                        break;
                }
            }       
        }

        private static void ActiveGameplayInputHandler(int keyPressed) {
            if (keyPressed == 48 && currentSquares.ElementAtOrDefault(9) != null) //zero
            {
                if (currentSquares[9].active) 
                {
                    currentSquares[9].active = false;
                    hits++;
                }
                else
                {
                    misses++;
                }
            }
            else if (currentSquares.ElementAtOrDefault(keyPressed - 49) != null)
            {
                if (currentSquares[keyPressed - 49].active)
                {
                    currentSquares[keyPressed - 49].active = false;
                    hits++;
                }
                else
                {
                    misses++;
                }
                
            }

        }

        public static void EndOptionsOverlay()
        {
            endTime += DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - pausedAt;
        }

        private static void Render() 
        {
            int squareCounter = 0;
            Raylib.BeginDrawing();
            foreach (Square square in currentSquares)
            {
                Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
                if (square.active == true) {
                    Raylib.DrawRectangle(40*(squareCounter+1), 40, 40, 40, Raylib_cs.Color.Green);
                }
                Raylib.DrawRectangleLines(40*(squareCounter+1), 40, 40, 40, Raylib_cs.Color.Black);
                squareCounter++;
            }

            Raylib.DrawText($"{hits} hits", 20, 100, 40, Raylib_cs.Color.DarkGreen);
            Raylib.DrawText($"{misses} misses", 20, 165, 40, Raylib_cs.Color.Red);
            
            if (gameplayPaused) 
            {
                Raylib.DrawText($"{(endTime - pausedAt)/1000}s left", 20, 230, 40, Raylib_cs.Color.Black);
            }
            else
            {
                Raylib.DrawText($"{(endTime - DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())/1000}s left", 20, 230, 40, Raylib_cs.Color.Black);
            }

            if (gameplayPaused) 
            {
                OptionsOverlay.Render();
            }

            Raylib.EndDrawing();
        }
    }
}