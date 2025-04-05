using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SniperRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] GameObject PickupReturnObj;

    protected float elapsed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
