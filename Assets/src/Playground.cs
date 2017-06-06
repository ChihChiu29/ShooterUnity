using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objectprovider;
using sprite;

public class Playground : MonoBehaviour
{
  // Use this for initialization
  void Start ()
  {
    ObjectProvider.CreateRigidObject ("test1", SpriteProvider.GetPlayerSprite ());
  }
	
  // Update is called once per frame
  void Update ()
  {
		
  }
}
