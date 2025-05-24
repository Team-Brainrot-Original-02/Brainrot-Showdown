using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Attack _attack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hittable")) {
            _attack.PerformAttack();
            
        }
        Destroy(this.gameObject);
    }
}
