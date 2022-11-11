using Unit5.Game.Casting;
using Unit5.Game.Services;


namespace Unit5.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(0, - Constants.CELL_SIZE);
        private Point _direction1 = new Point(0, - Constants.CELL_SIZE);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (_keyboardService.IsKeyDown("a"))
            {
                _direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("d"))
            {
                _direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("w"))
            {
                _direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("s"))
            {
                _direction = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake = (Snake)cast.GetFirstActor("snake");
            snake.TurnHead(_direction);

            // left
            if (_keyboardService.IsKeyDown("j"))
            {
                _direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("l"))
            {
                _direction1 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("i"))
            {
                _direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("k"))
            {
                _direction1 = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            snake1.TurnHead(_direction1);
        }
    }
}