using System;
using Raylib_cs;
using SquareGame;

namespace Gameplay {
    class Square {
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
        private static bool gameplayOngoing = false;
        private static List<Square> currentSquares = new List<Square> {}; 
        public static bool GameplayOngoing { get {return gameplayOngoing;} private set {gameplayOngoing = value;} }

        public static void StartGameplay(string diff)
        {
            difficulty = diff;
            currentSquares = new List<Square> {};
            switch (diff) 
            {
                case "easy":
                    for (int i = 0; i < 5; i++) {
                        currentSquares.Add(new Square(false, 0, 0));
                    }
                    break;
            }

            GameplayOngoing = true;
        }

        public static void ProcessGameplay()
        {
            Render();
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
            Raylib.EndDrawing();
        }
    }
}