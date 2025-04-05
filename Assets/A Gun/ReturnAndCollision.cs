using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAndCollision : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject PickupReturn;

    [SerializeField] GameObject BulletSniper;

    [SerializeField] float speed;

    protected float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        var rotationLocal = transform.rotation;
        rotationLocal.eulerAngles = new Vector3(0, 0, 0);
        transform.rotation = rotationLocal;

        elapsed = 0;

        player = FindObjectOfType<FPSController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        PickupReturn.transform.position = Vector3.MoveTowards(PickupReturn.transform.position, player.transform.position, speed * Time.deltaTime);

        Debug.Log(player.transform.position);
    }
    //public void SpawnGun()
    //{
    //    Instantiate(PickupReturn, BulletSniper.transform.position, gameObject.transform.rotation);
        
    //}


}
