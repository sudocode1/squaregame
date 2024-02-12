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
        public static bool gameplayOngoing = false;
        private static List<Square> currentSquares = new List<Square> {}; 
        public static bool gameplayPaused = false;
        //public static bool GameplayOngoing { get {return gameplayOngoing;} set {gameplayOngoing = value;} }
        

        public static void StartGameplay(string diff)
        {
            difficulty = diff;
            currentSquares = new List<Square> {};
            switch (diff)
            {
                case "easy":
                    for (int i = 0; i < 4; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }
                    break;
                
                case "medium":
                    for (int i = 0; i < 6; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }
                    break;

                case "hard":
                    for (int i = 0; i < 8; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }
                    break;

                case "extreme":
                    for (int i = 0; i < 10; i++)
                    {
                        currentSquares.Add(new Square(false, 0, 0));
                    }
                    break;
            }   

            gameplayPaused = false;
            gameplayOngoing = true;
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
            if (keyPressed == 48) //zero
            {
                currentSquares[9].active = false;
            }
            else if (currentSquares[keyPressed - 49] != null && currentSquares[keyPressed - 49].active)
            {
                currentSquares[keyPressed - 49].active = false;
            }
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

            if (gameplayPaused) {
                OptionsOverlay.Render();
            }

            Raylib.EndDrawing();
        }
    }
}