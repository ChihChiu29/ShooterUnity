using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

// Remember to keep prefabs under Assets/Resources/Prefabs/ folder.

namespace objectprovider
{
  public class ObjectProvider
  {
    private static string PREFAB_FOLDER = "Prefabs/";

    public static GameObject CreateRigidObject (
      /* Name of the object. */
      string name,
      /* Sprite for the object. */
      Sprite sprite,
      /* The location of the object. */
      Vector2 location = default(Vector2),
      /* The transform on the object. */
      Quaternion transform = default(Quaternion))
    {
      GameObject obj = 
        MonoBehaviour.Instantiate (
          Resources.Load<GameObject> (GetFullPath ("BasicRigidBody")), 
          location, 
          transform);
      obj.name = name;
      SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
      renderer.sprite = sprite;

      return obj;
    }

    private static string GetFullPath (string name)
    {
      return Path.Combine (PREFAB_FOLDER, name);
    }
  }
}
