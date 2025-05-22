using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    private Rigidbody Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Rigidbody.AddForce(transform.forward * bulletSpeed);
    }
}
