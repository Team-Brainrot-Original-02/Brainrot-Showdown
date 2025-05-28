using System;
using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool isShieldUp;
    public bool isShieldAvaible;
    public float shieldCooldown;
    public float shieldDuration;
    public Action onShieldUp;
    public Action onShieldDown;

    private void Update()
    {
        // input for shield activation
        if (Input.GetKeyDown(KeyCode.Space) && isShieldAvaible == true)
        {
            isShieldUp = true;
            isShieldAvaible = false;
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
        isShieldAvaible = true;
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
        isShieldAvaible = true;
    }
}
