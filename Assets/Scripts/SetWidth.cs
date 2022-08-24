using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWidth : MonoBehaviour
{
  // Start is called before the first frame update
  private float buffer = 10;
  public GameDimensions dims;
  private float width;
  void Start()
  {
    width = dims.gameWidth;
    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(width + buffer, 1, 1));
  }

  private void updateWidth()
  {
    Vector3 temp = transform.localScale;
    temp.x = temp.x + 5;
    transform.localScale = temp;
  }
}
