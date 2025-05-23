using System;
using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool isShieldUp;
    public bool isShielAvaible;
    public float shieldCooldown;
    public float shieldDuration;
    public Action onShieldUp;
    public Action onShieldDown;

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
            onShieldUp?.Invoke();
        }
        else
        {
            Debug.Log("Shield is down");
            onShieldDown?.Invoke();
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
