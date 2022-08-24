using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
  private float _horizontalInput = 0;
  private float _verticalInput = 0;
  private bool _boostInput = false;

  public static float boostAmount;
  public static float boostCap = 5;

  public int movementSpeed = 0;
  public int rotationSpeed = 4;
  public int gravity = 5;
  public int idleSpeed = 1;
  public AudioSource end;

  public GameState gameState;
  public CameraController camControl;
  private bool isAlive;

  public AudioSource munch;
  public AudioSource swim;

  Rigidbody2D rb2D;
  Animator anim;

  public GameOverScreen GameOverScreen;

  private void GameOver()
  {
    GameOverScreen.Setup(transform.localScale.x);
  }

  private void Start()
  {

    gameState.isAlive = true;

    isAlive = gameState.isAlive;
    rb2D = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    boostAmount = boostCap;
    swim.Play();
  }

  private void Update()
  {
    if (gameState.isStart)
    {
      if (isAlive)
        GetPlayerInput();
      else
        rb2D.velocity = new Vector2(0, 0);
    }

  }

  private void FixedUpdate()
  {
    if (isAlive && gameState.isStart)
    {
      RotatePlayer();
      if (rb2D.transform.position.y > 0)
      {
        rb2D.gravityScale = gravity;
        rotationSpeed = 2;//cut rotation speed in half
      }
      else
      {
        rotationSpeed = 4;//reset rotation speed back to 4
        rb2D.gravityScale = 0;
        MovePlayer();
        if (_boostInput)
        {
          BoostPlayer();
        }
        else
        {
          if (gameState.isBoosting)
          {
            gameState.isBoosting = false;
            camControl.FixCamera();
          }
          RestoreBoost();
        }
      }
    }
  }

  private void RestoreBoost()
  {
    if (boostAmount < boostCap)
    {
      boostAmount += Time.deltaTime;
    }
  }

  private void GetPlayerInput()
  {
    _horizontalInput = Input.GetAxisRaw("Horizontal");
    _verticalInput = Input.GetAxisRaw("Vertical");
    _boostInput = Input.GetKey("space");
  }

  private void MovePlayer()
  {
    if (Mathf.Clamp01(_verticalInput) == 1)
    {
      anim.speed = 2f;
      rb2D.velocity = transform.right * movementSpeed;
    }
    else
    {
      anim.speed = 1f;
      rb2D.velocity = transform.right * idleSpeed;
    }
  }

  private void RotatePlayer()
  {
    float rotation = -_horizontalInput * rotationSpeed;
    transform.Rotate(Vector3.forward * rotation);
  }

  private void BoostPlayer()
  {
    if (boostAmount > 0)
    {
      if (!gameState.isBoosting)
      {
        gameState.isBoosting = true;
        camControl.FixCamera();
      }
      anim.speed = 3f;
      rb2D.velocity = rb2D.velocity * 2;
      boostAmount -= Time.deltaTime;
    }
    else
    {
      if (gameState.isBoosting)
      {
        gameState.isBoosting = false;
        camControl.FixCamera();
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    string tag = other.gameObject.tag;
    if (tag == "EnemyBig")
    {
      gameState.isAlive = false;
      GetComponent<CircleCollider2D>().enabled = false;
      isAlive = false;
      GameOver();
    }
    else if (tag == "EnemySmall")
    {
      munch.Play();
    }
  }



}
