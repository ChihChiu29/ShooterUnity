using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

namespace sprite
{
  public class SpriteProvider
  {

    private static string SPRITE_FOLDER = "Assets/sprites/";

    public static Sprite GetPlayerSprite ()
    {
      return AssetDatabase.LoadAssetAtPath<Sprite> (
        GetSpritePathByName ("airship2.png"));
    }

    private static string GetSpritePathByName (string name)
    {
      return Path.Combine (SPRITE_FOLDER, name);
    }
  }
}