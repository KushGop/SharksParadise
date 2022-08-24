using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParticle : MonoBehaviour
{

  private MaterialPropertyBlock bgParticles;
  public Mesh mesh;
  public Material material;
  // Start is called before the first frame update
  void Start()
  {
    bgParticles = new MaterialPropertyBlock();
  }

  private void Update()
  {
    bgParticles.SetColor("_Color", Color.grey);
    Graphics.DrawMesh(mesh, new Vector3(0, 0, 0), Quaternion.identity, material, 0, null, 0, bgParticles);
  }
}
