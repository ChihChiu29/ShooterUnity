using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game;

public class GameMaster : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
    LevelManager.GenerateLevel (
      4,
      2,
      new Rect (-8, -6, 16, 12));
  }
}
