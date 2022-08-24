using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : EnemyBase
{
  private void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
    // SlowEnemy();
    InvokeRepeating("MoveFast", 2f, 2f); //fast movement
    InvokeRepeating("MoveSlow", 3f, 2f); //slow movement
    InvokeRepeating("RotateEnemy", 3.1f, 6f);
  }
  
  private void FixedUpdate() {
    if(rb2D.transform.position.y > 0){
      rb2D.gravityScale = gravity;
      
    }else{
      rb2D.gravityScale = 0;
    }
  }

  private void MoveFast()
  {
    if(gameState.isStart)
      rb2D.velocity = transform.up*2f;
  }
  private void MoveSlow()
  {
    if(gameState.isStart)
      rb2D.velocity = transform.up*0.7f;
  }

  private void RotateEnemy(){
    if(gameState.isStart)
      StartCoroutine(RotateRoutine());
  }

  private IEnumerator RotateRoutine()
  {
    // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward), 6 * Time.deltaTime);
    float startTime = Time.time;
    float overTime = 100f;
    Quaternion angle = Quaternion.AngleAxis(Random.Range(-130, 130), Vector3.forward);
    while(Time.time < startTime + overTime)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, (Time.time - startTime)/overTime);
        yield return null;
    }
    transform.rotation = angle;
  }
}
