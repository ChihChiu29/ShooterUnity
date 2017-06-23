using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
  public float lifetime = 3;
  private float startTime;

  // Use this for initialization
  void Start ()
  {
    startTime = Time.time;
  }
	
  // Update is called once per frame
  void Update ()
  {
    if (Time.time > startTime + lifetime) {
      Object.Destroy (gameObject);
    }
  }
}
