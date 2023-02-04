using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ServerLightScript : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light;
    public float lightHighIntensity = 3f;
    public float lightLowIntensity = 0f;
    public float fadeSpeed = 10f;
    public float newIntensity;
    public bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        InvokeRepeating(nameof(switchLight),Random.Range(0f,2f),Random.Range(0f,2f));
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = Mathf.Lerp(light.intensity, newIntensity, Time.deltaTime * fadeSpeed);
    }

    void switchLight(){
        if( isOn )
        {
            newIntensity = lightLowIntensity;
        }
        else
        {
            newIntensity = lightHighIntensity;
        }
        isOn = !isOn;
    }
}
