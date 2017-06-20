using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace animation
{
  public interface ZAnimation
  {
    // Returns false if the animation has finished.
    bool NextFrame (
      float totalTimeSinceAnimationStart = 0, 
      float deltaTime = 0);
  }
}
