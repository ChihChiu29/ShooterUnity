using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace objectprovider
{
  public class ObjectProvider
  {
    private static string PREFAB_FOLDER = "Assets/prefabs/";

    public static GameObject CreateRigidObject (Sprite sprite)
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          AssetDatabase.LoadAssetAtPath<GameObject> (
            GetPrefabPathByName ("BasicRigidBody.prefab")));
      SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
      renderer.sprite = sprite;

      return obj;
    }

    private static string GetPrefabPathByName (string name)
    {
      return Path.Combine (PREFAB_FOLDER, name);
    }
  }
}
