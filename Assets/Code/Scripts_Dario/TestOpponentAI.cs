using UnityEngine;

public class TestOpponentAI : MonoBehaviour
{
    public Attack attack;
    public float attackInterval = 2f;

    void Start()

    {
        attack = GetComponent<Attack>();
        InvokeRepeating(nameof(PerformAIattack), attackInterval, attackInterval);
    }

    private void PerformAIattack()
    {
        attack.PerformAttack();
    }
}
