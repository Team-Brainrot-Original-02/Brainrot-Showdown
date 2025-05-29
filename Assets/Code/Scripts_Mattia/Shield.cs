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

    [Header("--- Animator ---")]
    [SerializeField] Animator _AC;
    [SerializeField] GameObject _Shield;

    private void Update()
    {
        // input for shield activation
        if (Input.GetKey(KeyCode.Z) && isShieldAvaible == true)
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
            _Shield.SetActive(true);
            _AC.SetBool("isShieldUp", true);
            onShieldUp?.Invoke();
        }
        else
        {
            Debug.Log("Shield is down");
            
            _AC.SetBool("isShieldUp", false);
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
        _Shield.SetActive(false);
        isShieldUp = false;
        Debug.Log("Shield is down");
    }

    private void Start()
    {
        isShieldUp = false;
        isShieldAvaible = true;
    }
}
