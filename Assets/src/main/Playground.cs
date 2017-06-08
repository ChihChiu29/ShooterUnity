using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameobject;
using sprite;

public class Playground : MonoBehaviour
{
  public float bulletVelocity = 10.0f;

  // Use this for initialization
  void Start ()
  {

    GameObject player = ObjectFactory.CreatePlayer ();

    GameObject enemy = ObjectFactory.CreateEnemy ();
    enemy.transform.position = new Vector2 (0, 4);

    ObjectFactory.CreateBullet (new Vector2 (0, 0), facing: 45);
    ObjectFactory.CreateBullet (new Vector2 (0.5f, -2), facing: 90);
    ObjectFactory.CreateBullet (new Vector2 (0.6f, -3), facing: 90);
    ObjectFactory.CreateBullet (new Vector2 (0.8f, -4), facing: 90);

    ObjectFactory.CreateExplosion (
      new Vector2 (-2, 2),
      initialScale: 0.1f,
      finalScale: 0.6f,
      expansionSpeed: 1.5f);
  }
	
  // Update is called once per frame
  void Update ()
  {
		
  }
}
