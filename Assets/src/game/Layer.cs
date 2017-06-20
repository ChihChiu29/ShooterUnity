using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Store layer names. Note that all customized layers must be manually registed
// using Unity Editor UI.

public class Layer
{
  public static string Animation = "animation";

  public static void SetGameObjectToLayer (GameObject target, string layerName)
  {
    target.layer = LayerMask.NameToLayer (layerName);
  }

  public static void SetGameObjectToLayer (GameObject target, int layer)
  {
    target.layer = layer;
  }
}
