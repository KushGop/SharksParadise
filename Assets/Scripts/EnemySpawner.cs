using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public GameObject enemy;
  public GameObject player;
  public int numEnemies = 20;
  public float sizeIncrease = 0;
  private float floor;
  private float width;
  private List<GameObject> enemies = new List<GameObject>();
  UnityEngine.Camera cam;
  protected bool isAlive = true;
  public GameDimensions dims;

  // Start is called before the first frame update
  void Start()
  {
    floor = dims.groundPos;
    width = dims.gameWidth;
    cam = UnityEngine.Camera.main;
    for (int i = 0; i < numEnemies; i++)
      loadChildObjects(enemy);
  }

  private void Update()
  {
    enemies.RemoveAll(item => item == null);
    if (enemies.Count < numEnemies){
      loadChildObjects(enemy);
    }
      
  }

  void loadChildObjects(GameObject obj)
  {
    float x = player.transform.position.x;
    float z = player.transform.position.z;

    float xRange, yRange;
    Vector3 pos, viewPos;
    do
    {
      xRange = Random.Range(x - width/2, x + width/2);
      yRange = Random.Range(floor + 2, -2);
      pos = new Vector3(xRange, yRange, z);
      viewPos = cam.WorldToViewportPoint(pos);
    } while (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0);

    var newFish = Instantiate(obj, pos, Quaternion.identity);
    newFish.transform.localScale = transform.localScale * Random.Range(0.2f, 2.0f + sizeIncrease);
    newFish.transform.parent = GameObject.Find("Enemies").transform;
    newFish.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
    enemies.Add(newFish);
  }
}
