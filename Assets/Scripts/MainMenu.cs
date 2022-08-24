using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

  public GameState gameState;
  public Text size;
  public Slider boost;
  public void startGame()
  {
    Debug.Log("start");
    gameState.isStart = true;
    gameObject.SetActive(false);
    size.gameObject.SetActive(true);
    boost.gameObject.SetActive(true); 
  }
  private void Start()
  {
    if (!gameState.isRestart)
    {
      gameState.isStart = false;
      gameState.isRestart = false;
      size.gameObject.SetActive(false);
      boost.gameObject.SetActive(false);
    }
    else
    {
      gameObject.SetActive(false); 
    }
  }
}
