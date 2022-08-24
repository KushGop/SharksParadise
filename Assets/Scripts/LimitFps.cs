using UnityEngine;

public class LimitFps : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Application.targetFrameRate = 90;
  }
}
