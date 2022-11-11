using Unit5.Game.Casting;
using Unit5.Game.Directing;
using Unit5.Game.Scripting;
using Unit5.Game.Services;
using Unit5.Game;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            Constants constants = new Constants();
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("food", new Food());
            cast.AddActor("snake", new Snake(1, Constants.YELLOW, Constants.GREEN));
            cast.AddActor("snake1", new Snake(3, Constants.BLUE, Constants.YELLOW));
            cast.AddActor("banner1", new Banner(0, "Player 1:", Constants.GREEN));
            cast.AddActor("banner2", new Banner(2, "Player 2:", Constants.YELLOW));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}