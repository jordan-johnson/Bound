using System;
using System.Collections.Generic;

namespace Bound.Utilities.Configuration
{
    public class UserConfiguration : IConfiguration
    {
        private bool _debug;
        private Dictionary<int, int> _resolutions;
        
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public UserConfiguration(bool debugging)
        {
            _debug = debugging;
            
            _resolutions = new Dictionary<int, int>
            {
                {3840, 2160},
                {2560, 1440},
                {1920, 1080},
                {1600, 900},
                {1366, 768},
                {1280, 720},
                {1024, 576}
            };
        }

        public void Load()
        {
            Defaults();
        }

        private void Defaults()
        {
            WindowWidth = 1920;
            WindowHeight = 1080;
        }
    }
}