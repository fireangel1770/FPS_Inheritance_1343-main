using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : Gun
{
    [SerializeField] GameObject prefabShotgunBlast;
    public override bool AttemptFire()
    {
        if (!base.AttemptFire())
            return false;

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(31, 100, 2, 2, null); // version without special effect
                                                                     //b.GetComponent<Projectile>().Initialize(1, 100, 2, 5, DoThing); // version with special effect
        Instantiate(prefabShotgunBlast, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        return true;
    }


}
