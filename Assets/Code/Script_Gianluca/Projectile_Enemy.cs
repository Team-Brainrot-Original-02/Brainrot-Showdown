using UnityEngine;

public class Projectile_Enemy: MonoBehaviour
{

    [SerializeField] private GameObject _VFX;

    private void OnTriggerEnter(Collider other)
    {
        
    }


    public void VFX()
    {
        Instantiate(_VFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
