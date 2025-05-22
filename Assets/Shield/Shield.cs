using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool isShieldUp;
    public bool isShielAvaible;
    public float shieldCooldown;
    public float shieldDuration;

    private void Update()
    {
        // input for shield activation
        if (Input.GetKeyDown(KeyCode.Space) && isShielAvaible == true)
        {
            isShieldUp = true;
            isShielAvaible = false;
            StartCoroutine(ShieldCooldown());
            StartCoroutine(ShieldDuration());
        }
        // check if shield is up or down
        if (isShieldUp == true)
        {
            Debug.Log("Shield is up");
            // add shield effect here
        }
        else
        {
            Debug.Log("Shield is down");
            // remove shield effect here
        }

    }
    // cooldown and duration coroutines
    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSeconds(shieldCooldown);
        isShielAvaible = true;
        Debug.Log("Shield is available");

    }
    IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(shieldDuration);
        isShieldUp = false;
        Debug.Log("Shield is down");
    }

    private void Start()
    {
        isShieldUp = false;
        isShielAvaible = true;
    }
}
