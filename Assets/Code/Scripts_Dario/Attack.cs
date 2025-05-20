using UnityEngine;

//gestisce la logica di attacco di entrambi

public class Attack : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1f;
    public LayerMask opponentLayer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void PerformAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, opponentLayer);
        foreach (var hitCollider in hitColliders)
        {
            Health opponentHealth = hitCollider.GetComponent<Health>();
            if (opponentHealth != null)
            {
                opponentHealth.TakeDamage(damage);
                Debug.Log($"Attacked [{hitCollider.gameObject.name} dealing {damage} damage");
            }
        }
    }
}
