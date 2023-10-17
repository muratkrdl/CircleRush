using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBox : MonoBehaviour
{
    [SerializeField] float minRotateSpeed = 5f;
    [SerializeField] float maxRotateSpeed = 20f;

    float rotateSpeed;

    void Start()
    {
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);

        int index = Random.Range(0,2);
        if(index == 0)
            rotateSpeed *= -1;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
