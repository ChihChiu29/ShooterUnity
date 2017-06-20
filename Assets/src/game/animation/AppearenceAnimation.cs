using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace animation
{
  public class AppearenceAnimation : ZAnimation
  {
    private GameObject target;
    private Vector2 start;
    private Vector2 end;
    private float duration;

    private int targetOriginalLayer;
    private Vector2 targetOriginalScale;

    public AppearenceAnimation (
      // The target object to animate.
      GameObject target,
      // The start location of the object.
      Vector2 start, 
      // The end location of the object.
      Vector2 end, 
      // The duration of the animation.
      float duration)
    {
      this.target = target;
      this.start = start;
      this.end = end;
      this.duration = duration;

      targetOriginalScale = target.transform.localScale;
      targetOriginalLayer = target.layer;
      Layer.SetGameObjectToLayer (target, Layer.Animation);
    }

    public bool NextFrame (
      float totalTimeSinceAnimationStart = 0, 
      float deltaTime = 0)
    {
      float progress = Mathf.Sqrt (totalTimeSinceAnimationStart / duration);
      target.transform.position = start + progress * (end - start);
      target.transform.localScale = targetOriginalScale * progress;
      if (progress >= 1) {
        Layer.SetGameObjectToLayer (target, targetOriginalLayer);
        return false;
      } else {
        return true;
      }
    }
  }
}