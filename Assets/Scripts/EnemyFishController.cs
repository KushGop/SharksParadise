using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFishController : EnemyBase
{
  private void Start()
  {
    player = GameObject.Find("Player");
    rb2D = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate() {
    if(rb2D.transform.position.y > 0){
      rb2D.gravityScale = gravity;
      
    }else{
      rb2D.gravityScale = 0;
      MoveEnemy();
    }
  }

  private void MoveEnemy()
  {
    if (gameState.isStart)
    {
      if (isAlive)
      {
        float distX = Mathf.Abs(transform.position.x - player.transform.position.x);
        float distY = Mathf.Abs(transform.position.y - player.transform.position.y);
        if (distX < 8f && distY < 8f)
        {//check if enemy is near player
          rb2D.velocity = transform.right * movementSpeed;
          Vector3 relativePos = gameObject.tag == "EnemyBig" ? player.transform.position - transform.position : transform.position - player.transform.position;
          float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
          RotateEnemy(angle);
        }
        else
        {
          Idle();
        }
      }
      else
      {
        Idle();
      }
    }
  }

  private void Idle()
  {
    rb2D.velocity = transform.right * idleSpeed;
    float curr = transform.localRotation.z;
    int angle = .5f > curr && curr > -.5f ? 0 : 180;
    RotateEnemy(angle);
  }

  private void RotateEnemy(float angle)
  {
    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);
  }
}
