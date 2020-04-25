using System;
using SDL2;
using Bound.Graphics;
using Bound.Graphics.Scene;
using Bound.Utilities.Configuration;

namespace Bound.Startup
{
    public class BoundStartup : IStartup
    {
        private IWindow _window;
        private IRenderer _renderer;
        private ISceneHandler _sceneHandler;
        private IConfiguration _config;

        public void Initialize()
        {
            _config = new UserConfiguration();
            _config.Load();

            InitializeWindowAndRenderer();
            InitializeSceneHandler();
        }

        public void Run()
        {
            while(_window.IsOpen)
            {
                _window.PollEvents();
                _renderer.Draw();
            }

            Quit();
        }

        public void Quit()
        {
            _window.CloseWindow();

            SDL.SDL_Quit();
        }

        private void InitializeWindowAndRenderer()
        {
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            _window = new Window("Bound", _config.WindowWidth, _config.WindowHeight);
            _window.Create();

            // TODO: log error
            if(_window.WindowHandler == IntPtr.Zero)
                return;

            _renderer = new Renderer(_window);
            _renderer.Create();

            // TODO: log error
            if(_renderer == null || _renderer.RendererHandler == IntPtr.Zero)
                Quit();
        }

        private void InitializeSceneHandler()
        {
            if(_renderer?.RendererHandler == IntPtr.Zero)
                return;

            _sceneHandler = new SceneHandler(_renderer.Drawables);
        }
    }
}