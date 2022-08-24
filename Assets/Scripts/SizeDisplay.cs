using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeDisplay : MonoBehaviour
{
  // Start is called before the first frame update

  private Text textBox;
  public GameObject player;
  public GameState playerState;

  void Start()
  {
    textBox = GetComponent<Text>();
    textBox.text = player.transform.localScale.x.ToString("F2") + " m";
  }

  // Update is called once per frame
  void Update()
  {
    if (playerState.isAlive)
      textBox.text = player.transform.localScale.x.ToString("F2") + " m";
  }
}
