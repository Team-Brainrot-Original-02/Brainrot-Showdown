using UnityEngine;

public class Playerattack : MonoBehaviour
{
    private Attack attack;
    void Start()
    {
        attack = GetComponent<Attack>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack.PerformAttack();
        }
    }
}
