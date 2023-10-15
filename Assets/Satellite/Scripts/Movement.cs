using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public Slider mySlider;

    [SerializeField] float movementSpeed = 30f;
    [SerializeField] float turnSpeed = 30f;

    Transform myT;

    float sliderValue;

    void Awake()
    {
        myT = transform;
    }

    void Update()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Yaw");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myT.Rotate(-pitch, yaw, -roll);
    }

    void Thrust()
    {
        myT.position += myT.forward * Time.deltaTime * (movementSpeed * sliderValue);

        mySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

    }
    public void ValueChangeCheck()
    {
        Debug.Log(mySlider.value);

        sliderValue = mySlider.value;
    }
}
