using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 1, 0); 

    // Update is called once per frame
    void Update()
    {
        //prevent the bar from rotating, now it stays facing the camera
       // transform.rotation = camera.transform.rotation;

        //keeps the bar above the enemy
        //transform.position = target.position + offset;
    }

    //bar will update according to the values
    public void updateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
