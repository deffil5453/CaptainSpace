using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShootScript : SupportControl
{
    public override void PickUp(ShipControl ship)
    {
        ship.BulletCount = 2;
        StartCoroutine(MultiShootDuration(ship, 3f));
    }
    private IEnumerator MultiShootDuration(ShipControl ship, float timeDuration)
    {
        yield return new WaitForSeconds(timeDuration);
        //_isMultiShotActive = false;
        ship.BulletCount = 1;
    }
}