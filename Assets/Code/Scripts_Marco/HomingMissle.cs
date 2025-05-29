using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distanceToTarget = 0.5f;
    [SerializeField] private Projectile_Enemy _PE;
    public float damage = 1f;

    private void Update()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) > distanceToTarget)
        {
           // gameObject.GetComponent<Rigidbody>().linearVelocity += (target.transform.position - this.transform.position).normalized * speed * Time.deltaTime;
           // this.transform.position += (target.transform.position - this.transform.position).normalized * speed * Time.deltaTime;
            //this.transform.LookAt(target.transform);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                
            Debug.Log("Hit:" + other.transform.tag);
            }
            //Destroy(gameObject);
        }
            _PE.VFX();
    }
}
