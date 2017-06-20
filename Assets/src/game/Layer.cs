using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Store layer names. Note that all customized layers must be manually registed
// using Unity Editor UI.

public class Layer
{
  public static int DefaultLayer = LayerMask.NameToLayer ("Default");
  public static int AnimationLayer = LayerMask.NameToLayer ("Animation");

  public static void SetGameObjectToLayer (GameObject target, int layer)
  {
    target.layer = layer;
  }
}
