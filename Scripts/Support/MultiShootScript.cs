using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShootScript : SupportControl
{
    public override void PickUp(ShipControl ship)
    {
        ship.ShipAttack.BulletCount++;
        ship.StartCoroutine(MultiShootDuration(ship, Duration));
    }
    private IEnumerator MultiShootDuration(ShipControl ship, float timeDuration)
    {
        yield return new WaitForSeconds(timeDuration);
        //_isMultiShotActive = false;
        ship.ShipAttack.BulletCount--;
    }
}