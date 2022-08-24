using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

  public GameState gameState;
  public void ResetTheGame()
  {
    gameState.isRestart = true;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Debug.Log("Restart");
  }
  public void MainMenu()
  {
    gameState.isRestart = false;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Debug.Log("MainMenu");
  }
}
