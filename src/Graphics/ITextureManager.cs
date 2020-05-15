using System;
using System.Collections.Generic;

namespace Bound.Graphics
{
    public interface ITextureManager
    {
        void CreateTextureFromFile(string referenceId, string fileLocation);
        void DeleteTexture(IntPtr texture);
        void DeleteTexture(string referenceId);
        void DeleteAllTextures();
    }
}