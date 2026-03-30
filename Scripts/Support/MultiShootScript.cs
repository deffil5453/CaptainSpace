using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiShootScript : SupportControl
{
    [SerializeField] private Image _image;
    public override void PickUp(ShipControl ship)
    {
        ship.ShipAttack.BulletCount++;
        ship.StartCoroutine(MultiShootDuration(ship, Duration));
        PickupEvent();

    }
    private IEnumerator MultiShootDuration(ShipControl ship, float timeDuration)
    {
        yield return new WaitForSeconds(timeDuration);
        //_isMultiShotActive = false;
        ship.ShipAttack.BulletCount--;
    }
}