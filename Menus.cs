using Raylib_cs;

namespace Menus {
    public static class MainMenu {
        private static readonly string[] menuOptions = ["play", "settings", "quit"];
        private static int menuNavigationPoint = 0;
        private static void HandleSelection() {

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
            // Raylib.DrawText("test", 15, 17, 44, Raylib_cs.Color.Black);

            int menuCounter = 0;
            foreach (var item in menuOptions)
            {
                Raylib_cs.Color menuTextColor = menuCounter == menuNavigationPoint ? Raylib_cs.Color.Red : Raylib_cs.Color.Black;
                Raylib.DrawText(item, 15, 17+(35*menuCounter), 44, menuTextColor);
                menuCounter++;    
            }

            //Raylib.DrawText(menuNavigationPoint.ToString(), 80, 80, 40, Raylib_cs.Color.Black);
            Raylib.EndDrawing();
        }
    }
}