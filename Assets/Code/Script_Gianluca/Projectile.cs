using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Attack _attack;
    [SerializeField] private GameObject _VFX;

    private void OnTriggerEnter(Collider other)
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hittable"))
        {
            _attack.PerformAttack();
        }
        Instantiate(_VFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
