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

        public static void ProcessGameplay() {

        }

        private static void Render() {
            foreach (Square square in currentSquares)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
                // Raylib.DrawRectangleLines();
                Raylib.EndDrawing();
            }
        }
    }
}