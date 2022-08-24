using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
  public Text score, size;
  public Slider boost;

  public void Setup(float finalScore)
  {
    gameObject.SetActive(true);

    score.text = finalScore.ToString("F2") + " m";
    size.gameObject.SetActive(false);
    boost.gameObject.SetActive(false);
  }
  public void Start()
  {
    gameObject.SetActive(false);
  }

}
