using System;
using Serilog;
using SDL2;
using Bound.Utilities.Configuration;

namespace Bound.ApplicationBoot
{
    /// <summary>
    /// ApplicationContext handles window and SDL initialization.
    /// </summary>
    public class ApplicationContext : IApplicationContext
    {
        private IConfiguration _config;
        private IWindow _window;

        public bool IsRunning { get; private set; }
        public IntPtr ContextHandle => _window.WindowHandler;

        public ApplicationContext(IConfiguration configuration)
        {
            _config = configuration;
            _config.ThrowIfInvalidConfiguration();

            InitializeSDL();
        }

        public void CreateContext()
        {
            _window = new Window("Bound", _config.WindowWidth, _config.WindowHeight);
            _window.Create();

            IsRunning = ContextHandle != IntPtr.Zero;
        }

        public void Destroy()
        {
            _window.Destroy();

            IsRunning = false;

            SDL_image.IMG_Quit();
            SDL.SDL_Quit();
        }

        private void InitializeSDL()
        {
            if(SDL.SDL_Init(SDL.SDL_INIT_VIDEO) != 0)
            {
                throw new Exception($"SDL init failure. Returned: {SDL.SDL_GetError()}");
            }

            SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_JPG);
        }
    }
}