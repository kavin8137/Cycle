using System.Collections.Generic;
using Unit5.Game.Casting;
using Unit5.Game.Services;


namespace Unit5.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments = snake.GetSegments();
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            List<Actor> segments1 = snake1.GetSegments();
            Actor banner1 = cast.GetFirstActor("banner1");
            Actor banner2 = cast.GetFirstActor("banner2");
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");

            _videoService.ClearBuffer();
            _videoService.DrawActors(segments);
            _videoService.DrawActors(segments1);
            _videoService.DrawActor(food);
            _videoService.DrawActor(banner1);
            _videoService.DrawActor(banner2);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}