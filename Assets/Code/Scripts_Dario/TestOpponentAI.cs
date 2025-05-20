using UnityEngine;

public class TestOpponentAI : MonoBehaviour
{
    public Attack attack;
    public float attackInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(PerformAIattack), attackInterval, attackInterval);
    }

    private void PerformAIattack()
    {
        attack.PerformAttack();
    }
}
