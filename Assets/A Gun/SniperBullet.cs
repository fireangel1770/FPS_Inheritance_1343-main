using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SniperBullet : Projectile
{
    float damageAmount;
    float knockback;
    UnityAction<HitData> OnHit;

    [SerializeField] GameObject ReturnGunPickUp;

    protected float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1.9)
        {
            SpawnGun();
            elapsed = 0;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.gameObject.GetComponent<Damageable>();
        if (target != null)
        {
            var direction = GetComponent<Rigidbody>().velocity;
            direction.Normalize();

            Debug.Log("hit enemy trigger");
            target.Hit(direction * knockback, damageAmount);

            HitData hd = new HitData();
            hd.target = target;
            hd.direction = direction;
            hd.location = transform.position;

            OnHit?.Invoke(hd);
        }
        SpawnGun();
        Destroy(gameObject);
    }
    public void SpawnGun()
    {
        Instantiate(ReturnGunPickUp, gameObject.transform.position, ReturnGunPickUp.transform.rotation);

    }
}