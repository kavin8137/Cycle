using System;
using System.Collections.Generic;
using System.Data;
using Unit5.Game.Casting;
using Unit5.Game.Services;


namespace Unit5.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleFoodCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Food food = (Food)cast.GetFirstActor("food");
            
            if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
            {
                int points = food.GetPoints();
                snake.GrowTail(points);
                food.Reset();
            }
            else if (snake1.GetHead().GetPosition().Equals(food.GetPosition()))
            {
                int points = food.GetPoints();
                snake1.GrowTail(points);
                food.Reset();
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()) || segment.GetPosition().Equals(head1.GetPosition()))
                {
                    _isGameOver = true;
                }
            }

            foreach (Actor segment1 in body1)
            {
                if (segment1.GetPosition().Equals(head.GetPosition()) || segment1.GetPosition().Equals(head.GetPosition()))
                {
                    _isGameOver = true;
                }
            }
            if (head.GetPosition().Equals(head1.GetPosition()))
            {
                _isGameOver = true;
            }
        }

        public Boolean GetisGameOver()
        {
            return _isGameOver;
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");
                List<Actor> segments1 = snake1.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");
                Banner banner1 = (Banner)cast.GetFirstActor("banner1");
                Banner banner2 = (Banner)cast.GetFirstActor("banner2");

                // create a "game over" message
                int x = Constants.MAX_X / 2 - 30;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment1 in segments1)
                {
                    segment1.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
                banner1.SetColor(Constants.WHITE);
                banner2.SetColor(Constants.WHITE);
                snake.ChangeColor(Constants.WHITE);
                snake1.ChangeColor(Constants.WHITE);
            }
        }

    }
}