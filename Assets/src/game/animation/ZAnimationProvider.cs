using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game;
using script;

namespace animation
{
  public class ZAnimationProvider
  {
    public static void RegisterAnimation (ZAnimation animation)
    {
      GameObject animationManager = GetOrCreateAnimationManager ();
      ZAnimator animator = 
        ScriptProvider.AddScript<ZAnimator> (animationManager);
      animator.zanimation = animation;
    }

    public static ZAnimation CreateAppearenceAnimation (
      // The target object to animate.
      GameObject target,
      // The start location of the object.
      Vector2 start, 
      // The end location of the object.
      Vector2 end, 
      // The duration of the animation.
      float duration)
    {
      return new AppearenceAnimation (target, start, end, duration);
    }

    private static GameObject GetOrCreateAnimationManager ()
    {
      if (Global.animationManager == null) {
        Global.animationManager = ObjectFactory.CreateAnimationManager ();
      }
      return Global.animationManager;
    }
  }
}
