using System;


namespace Unit5.Game.Casting
{
    /// <summary>
    /// <para>A banner display the snake status.</para>
    /// <para>
    /// The responsibility of Banner is to display the status of the snake.
    /// </para>
    /// </summary>
    public class Banner : Actor
    {
        /// <summary>
        /// Constructs a new instance of a Banner.
        /// </summary>
        public Banner(int xPos, string message, Color color)
        {  
            SetText(message);
            SetColor(color);
            SetPosition(new Point((xPos * Constants.MAX_X) / 4, 0));
        }
        
    }
}