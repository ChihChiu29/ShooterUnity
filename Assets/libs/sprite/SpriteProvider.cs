using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

// Note that Resources.Load read assets from Assets/Resources/, so you need
// to put your sprites to be under that path. This class further assumes that
// you put them under Assets/Resources/Sprites/ folder.

namespace sprite
{
  public class SpriteProvider
  {
    private static string SPRITE_FOLDER = "Sprites/";

    private static Dictionary<string, Sprite> spriteCache = 
      new Dictionary<string, Sprite> ();

    private static Dictionary<string, Sprite[]> spritesheetCache = 
      new Dictionary<string, Sprite[]> ();

    public static Sprite GetPlayerSprite ()
    {
      Sprite[] sheet = GetSpriteSheetByRelativePath ("sprites");
      return sheet [3];
    }

    public static Sprite GetAirship ()
    {
      return GetSpriteByRelativePath ("airship2");
    }

    /**
     * Returns the Sprite with the given relative path.
     */
    private static Sprite GetSpriteByRelativePath (
      /* The path under SPRITE_FOLDER, no extension. */
      string relativePath)
    {
      Sprite unused;
      if (!spriteCache.TryGetValue (relativePath, out unused)) {
        spriteCache [relativePath] = 
          Resources.Load<Sprite> (GetFullPath (relativePath));
      }
      return spriteCache [relativePath];
    }

    /*
     * Returns the list of Sprites with the given relative path.
     */
    private static Sprite[] GetSpriteSheetByRelativePath (
      /* The path under SPRITE_FOLDER, no extension. */
      string relativePath)
    {
      Sprite[] unused;
      if (!spritesheetCache.TryGetValue (relativePath, out unused)) {
        spritesheetCache [relativePath] = 
          Resources.LoadAll<Sprite> (GetFullPath (relativePath));
      }
      return spritesheetCache [relativePath];
    }

    private static string GetFullPath (string name)
    {
      return Path.Combine (SPRITE_FOLDER, name);
    }
  }
}
