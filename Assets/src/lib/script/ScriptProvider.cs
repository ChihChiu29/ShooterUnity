using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class exists only for documentation purpose.
// The convention is to put all behavior scripts under
// Assests/Resources/Scripts/, although the API works no matter where the
// script is put.
//
// If you want to change public fields in the behavior class, first add a
// script and save the returned instance, then change its fields. For example:
//   RigidbodyKeyboardController controller =
//       player.AddComponent<RigidbodyKeyboardController> ();
//   controller.velocityScale = 1.0f;

using UnityEditor.VersionControl;

namespace script
{
  public class ScriptProvider
  {
    /**
     * Adds a behavior script to a GameObject.
     * 
     * T: Class of the behavior script.
     */
    public static T AddScript<T> (GameObject obj) where T : Component
    {
      return obj.AddComponent<T> ();
    }
  }
}
