using System;

namespace Bound.Graphics
{
    // public class TextureManager : ITextureManager
    // {
    //     public void CreateTextureFromFile(string referenceId, string fileLocation)
    //     {
    //         var texture = SDL_image.IMG_LoadTexture(RendererHandler, fileLocation);

    //         _textures.Add(referenceId, texture);
    //     }

    //     public void DeleteTexture(IntPtr texture)
    //     {
    //         SDL.SDL_DestroyTexture(texture);
    //     }

    //     public void DeleteTexture(string referenceId)
    //     {
    //         var texture = _textures[referenceId];

    //         DeleteTexture(texture);
    //     }

    //     public void DeleteAllTextures()
    //     {
    //         if(_textures == null)
    //             return;
            
    //         foreach(var texture in _textures)
    //         {
    //             SDL.SDL_DestroyTexture(texture.Value);
    //         }
    //     }
    // }
}