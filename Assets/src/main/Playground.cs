﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sprite;

public class Playground : MonoBehaviour
{
  // Use this for initialization
  void Start ()
  {
    GameObject player = ObjectFactory.CreatePlayer (2);
    player.transform.position = new Vector2 (0, -4);

    for (int x = -7; x <= 7; x += 2) {
      GameObject enemy = 
        ObjectFactory.CreateEnemy (Random.Range (1, 4), Random.Range (1, 3));
      enemy.transform.position = new Vector2 (x, 4);
    }
  }
}
