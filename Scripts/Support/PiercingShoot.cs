using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingShoot : SupportControl
{
    public override void PickUp(ShipControl ship)
    {
        ship.StartCoroutine(PiercingShootDuration(ship, Duration));
    }
    private IEnumerator PiercingShootDuration(ShipControl ship, float timeDuration)
    {
        ship.ShipAttack.IsPiercing = true;
        yield return new WaitForSeconds(timeDuration);
        ship.ShipAttack.IsPiercing = false;
    }
}
