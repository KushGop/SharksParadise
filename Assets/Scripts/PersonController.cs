using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
}
