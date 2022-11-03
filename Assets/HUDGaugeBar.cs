using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDGaugeBar : MonoBehaviour
{

    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        //SetGauge(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGauge(float val)
    {
        slider.value = val;

        //TODO:
        // color change
    }
}
