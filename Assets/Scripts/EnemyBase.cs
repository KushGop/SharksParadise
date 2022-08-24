using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
  public float gravity = 9.8f;
  public float idleSpeed = 3;
  public float movementSpeed = 6;
  public float rotationSpeed = 6;
  public GameObject player;
  protected Rigidbody2D rb2D;
  public GameState gameState;
  public GameDimensions gameDims;
  protected bool isAlive;
  public bool tagCheck=true;

  protected virtual void Update()
  {
    isAlive = gameState.isAlive;
    if (isAlive&&tagCheck)
    {//update tag names
      gameObject.tag = player.gameObject.transform.localScale.x > transform.localScale.x ? "EnemySmall" : "EnemyBig";
    }
    
  }

//destroy fish on out of bounds
  private void LateUpdate()
  {
    if (isAlive)
    {
      if (Mathf.Abs(transform.position.x - player.transform.position.x) > gameDims.gameWidth/2)
      {
        Destroy(gameObject);
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      if (transform.tag == "EnemySmall")
      {
        Destroy(gameObject);
        other.transform.localScale += (transform.localScale * 0.05f); //increase player size
        transform.parent.GetComponent<EnemySpawner>().sizeIncrease += (transform.localScale.x * 0.1f); //increase spawn size
      }
      else
      {
        //end game
        Destroy(other.gameObject);
        gameState.isAlive = false;
        Debug.Log("DEATH");
      }
    }
  }

}
