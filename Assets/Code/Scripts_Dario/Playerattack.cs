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
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
            attack.PerformAttack();
        }
    }
}
