using System;


namespace Unit5.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Banner : Actor
    {
        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Banner(int xPos, string message, Color color)
        {  
            SetText(message);
            SetColor(color);
            SetPosition(new Point((xPos * Constants.MAX_X) / 4, 0));
        }
        
    }
}