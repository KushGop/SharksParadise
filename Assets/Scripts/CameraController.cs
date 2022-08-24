using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

  public GameObject fish;
  // public float offset;
  public float offsetSmoothing;
  private Vector3 fishPosition;

  public GameObject[] levels;
  private Camera mainCamera;
  private Vector2 screenBounds;
  public float choke;
  public float scrollSpeed;
  // public float helper = 20;
  private float gameWidth;
  private float cameraSize = 9f;
  public float resizeSpeed;

  public GameState playerState;
  public GameDimensions dim;

  void Start()
  {
    gameWidth = dim.gameWidth;
    mainCamera = Camera.main;
    foreach (GameObject obj in levels)
    {
      loadChildObjects(obj);
    }
  }
  void loadChildObjects(GameObject obj)
  {
    float objectWidth;
    int childsNeeded;
    if (obj.tag != "Particle")
    {
      objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
      childsNeeded = (int)Mathf.Ceil(gameWidth / objectWidth) + 2;
    }
    else
    {
      objectWidth = 40;
      childsNeeded = 4;
    }

    GameObject clone = Instantiate(obj) as GameObject;
    for (int i = 0; i <= childsNeeded; i++)
    {
      GameObject c = Instantiate(clone) as GameObject;
      c.transform.SetParent(obj.transform);
      c.transform.position = new Vector3((objectWidth * i) - (gameWidth / 2), obj.transform.position.y, obj.transform.position.z);
      c.name = obj.name + i;
    }
    Destroy(clone);
    if (obj.tag != "Particle")
    {
      Destroy(obj.GetComponent<SpriteRenderer>());
    }
    else
    {
      Destroy(obj.GetComponent<ParticleSystem>());
    }

  }
  void repositionChildObjects(GameObject obj)
  {
    Transform[] children = obj.GetComponentsInChildren<Transform>();
    if (children.Length > 1)
    {
      GameObject firstChild = children[1].gameObject;
      GameObject lastChild = children[children.Length - 1].gameObject;
      float halfObjectWidth;
      if (obj.tag != "Particle")
      {
        halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
      }
      else
      {
        halfObjectWidth = 20;
      }

      if (transform.position.x + gameWidth / 2 > lastChild.transform.position.x)
      {
        firstChild.transform.SetAsLastSibling();
        firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
      }
      else if (transform.position.x - gameWidth / 2 < firstChild.transform.position.x)
      {
        lastChild.transform.SetAsFirstSibling();
        lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
      }
    }
  }
  void Update()
  {
    Vector3 velocity = Vector3.zero;
    Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
    Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
    transform.position = smoothPosition;

  }

  public void FixCamera()
  {
    
    if (playerState.isBoosting)
    {
      StartCoroutine(resizeRoutine(cameraSize, cameraSize + 1f, resizeSpeed));
    }
    else
    {
      StartCoroutine(resizeRoutine(cameraSize + 1f, cameraSize, resizeSpeed));
    }
  }
  private IEnumerator resizeRoutine(float oldSize, float newSize, float time)
  {
    float elapsed = 0;
     while (elapsed <= time)
     {
         elapsed += Time.deltaTime;
         float t = Mathf.Clamp01(elapsed / time);
 
         mainCamera.orthographicSize = Mathf.Lerp(oldSize, newSize, t);
         yield return null;
     }
  }

  void LateUpdate()
  {
    foreach (GameObject obj in levels)
    {
      repositionChildObjects(obj);
    }
  }

  void FixedUpdate()
  {
    if (playerState.isAlive)
    {
      fishPosition = new Vector3(fish.transform.position.x, fish.transform.position.y, transform.position.z);
      transform.position = Vector3.Lerp(transform.position, fishPosition, offsetSmoothing * Time.deltaTime);
    }
  }
}
