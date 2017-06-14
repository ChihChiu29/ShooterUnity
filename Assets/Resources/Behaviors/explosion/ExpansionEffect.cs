using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionEffect : MonoBehaviour
{
  public float currentScale = 1;
  public float finalScale = 10;
  public float expansionSpeed = 100;
	
  // Update is called once per frame
  void Update ()
  {
    if (currentScale < finalScale) {
      currentScale += expansionSpeed * Time.deltaTime;
      transform.localScale = new Vector3 (currentScale, currentScale, 1);
    } else {
      Object.Destroy (gameObject);
    }
  }
}
