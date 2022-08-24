using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    // Start is called before the first frame update
    private float boostbar;
    private float boostCap;
    public Slider boostSlider;

    void Start()
    {  
      boostbar = FishMovement.boostAmount;
      boostCap = FishMovement.boostCap;   
    }

    // Update is called once per frame
    void Update()
    {
        boostbar = FishMovement.boostAmount;
        boostSlider.value = (boostbar/boostCap);
    }
}
