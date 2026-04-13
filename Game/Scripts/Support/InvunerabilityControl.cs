using System.Collections;
using UnityEngine;

public class InvunerabilityControl : SupportControl
{
    //[SerializeField] private float _invunerabilityDuration;
    //public float GetInvunerabilityDuration()
    //{
    //    return _invunerabilityDuration;
    //}
    [SerializeField] private GameObject _invulVisualObject;
    public override void PickUp(ShipControl ship)
    {
        ship.StartCoroutine(InvulnerabilityDuration(Duration, ship));
        PickupEvent();
    }
    private IEnumerator InvulnerabilityDuration(float timeDuration, ShipControl ship/* AnimatorController invulAnimator*/)
    {
        //InvulnerableAnimator.SetActive(true);
        //invulAnimator.startAn
        ship.IsInvul = true;
        yield return new WaitForSeconds(timeDuration);
        ship.IsInvul = false;
        //InvulnerableAnimator.SetActive(false);
    }
}
