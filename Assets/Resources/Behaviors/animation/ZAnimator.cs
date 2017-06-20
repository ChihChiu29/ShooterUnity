using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using animation;

// It's recommended that you create a AnimationManager object and attach
// all instances of this script to it.
public class ZAnimator : MonoBehaviour
{
  public ZAnimation zanimation;
  private float totalTimeSinceStart = 0;

  // Use this for initialization
  void Start ()
  {
    PlayNextFrame (0);	
  }
	
  // Update is called once per frame
  void Update ()
  {
    PlayNextFrame (Time.deltaTime);
  }

  private void PlayNextFrame (float deltaTime)
  {
    totalTimeSinceStart += deltaTime;
    if (!zanimation.NextFrame (totalTimeSinceStart, deltaTime)) {
      Destroy (this);
    }
  }
}
