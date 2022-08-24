using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState")]
public class GameState : ScriptableObject
{
  public bool isAlive;
  public bool isStart;
  public bool isRestart;
  public bool isBoosting;
  public float size;
}
