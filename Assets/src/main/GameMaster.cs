using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using animation;

public class GameMaster : MonoBehaviour
{

  public int playerLevel = 1;
  public int difficulty = 10;
  public Rect gameArea = new Rect (-8, -6, 16, 12);
  public int maxNumberOfEnemyOnScreen = 1;

  private int totalNumberOfEnemies;
  private int numberOfSpawnEnemies = 0;
  private GameObject[] enemiesOnScreen;

  void Start ()
  {
    Camera.main.orthographicSize = 
      Mathf.Max (gameArea.width, gameArea.height) / 2;

    // Create and register global objects.
    ObjectFactory.CreateAnimationManager ();
    ObjectFactory.CreateAudioManager ();

    // Create initial set of level objects.
    ObjectFactory.CreateBoundary (gameArea);

    GameObject player = ObjectFactory.CreatePlayer (playerLevel);
    player.transform.position = 
      new Vector2 (gameArea.center.x, gameArea.yMin + 2);

    totalNumberOfEnemies = difficulty * 10;

    enemiesOnScreen = new GameObject[maxNumberOfEnemyOnScreen];
  }

  void Update ()
  {
    if (numberOfSpawnEnemies >= totalNumberOfEnemies) {
      return;
    }
    for (var i = 0; i < maxNumberOfEnemyOnScreen; i++) {
      if (enemiesOnScreen [i] == null) {
        enemiesOnScreen [i] = CreateEnemyWithAnimation ();
        numberOfSpawnEnemies++;
      }
    }
  }

  private GameObject CreateEnemyWithAnimation ()
  {
    GameObject enemy = 
      ObjectFactory.CreateEnemy (
        ObjectFactory.GetRandomEnemyType (), difficulty);

    Vector2 destination =
      new Vector2 (
        Random.Range (gameArea.xMin + 2, gameArea.xMax - 2), 
        Random.Range (gameArea.center.y, gameArea.yMax - 2));
    Vector2 fromLocation = 
      new Vector2 (destination.x, gameArea.yMax);

    ZAnimationProvider.RegisterAnimation (
      ZAnimationProvider.CreateAppearenceAnimation (
        enemy, fromLocation, destination, 0.3f));

    return enemy;
  }
}
