using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sniper : Gun
{
    //[SerializeField] GameObject prefabShotgunBlast;
    public override bool AttemptFire()
    {
        if (!base.AttemptFire())
            return false;

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(31, 10, 2, 2, null); // version without special effect

        //Instantiate(prefabShotgunBlast, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

        
        
        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        FindAnyObjectByType<FPSController>().RemoveGun(this);

        return true;
    }
}
