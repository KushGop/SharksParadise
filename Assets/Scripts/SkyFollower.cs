using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFollower : MonoBehaviour
{

  public GameObject player;

  public AudioSource splash;
  public GameState playerState;

  // private CircleCollider2D circle;

  void Update()
  {
    if (playerState.isAlive)
      transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
      splash.Play();
  }
  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
      splash.Play();
  }
}
