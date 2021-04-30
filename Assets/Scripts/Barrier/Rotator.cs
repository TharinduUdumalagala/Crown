using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

}
