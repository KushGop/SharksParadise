using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

  public float speed;

  protected Rigidbody2D rb2D;
  // Start is called before the first frame update
  void Start()
  {
    rb2D = GetComponent<Rigidbody2D>();
    
  }
  private void Update() {
    if(transform.rotation.z<15 && transform.rotation.z>-15 && transform.position.y < 1)
    rb2D.velocity = transform.right * speed;
  }
}
