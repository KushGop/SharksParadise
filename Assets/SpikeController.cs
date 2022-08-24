using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : EnemyBase
{
  // Start is called before the first frame update

  Animator anim;
  public AudioSource spikeOn;
  public AudioSource spikeOff;

  public CircleCollider2D coll;

  private float distance;
  public float soundDistance = 20f;

  void Start()
  {
    tagCheck = false;
    anim = GetComponent<Animator>();
    InvokeRepeating("ToggleSpike", 3f, 3f);
  }

  // Update is called once per frame
  protected override void Update()
  {
    transform.Rotate(0, 0, 50 * Time.deltaTime);
    
    isAlive = gameState.isAlive;
    if (isAlive)
    
    {
      distance = Vector3.Distance(player.transform.position, transform.position);
      if (distance < soundDistance)
      {
        spikeOn.volume = 0.5f - (distance / soundDistance) / 2f;
        spikeOff.volume = 1 - distance / soundDistance;
      }
      else
      {
        spikeOn.volume = 0;
        spikeOff.volume = 0;
      }
    }

  }

  void ToggleSpike()
  {
    if (anim.GetBool("isSpike"))
    {
      anim.SetBool("isSpike", false);
      coll.radius = 0.45f;
      gameObject.tag = "EnemySmall";
      spikeOff.Play();
    }
    else
    {
      anim.SetBool("isSpike", true);
      coll.radius = 0.75f;
      gameObject.tag = "EnemyBig";
      spikeOn.Play();
    }
  }
}
