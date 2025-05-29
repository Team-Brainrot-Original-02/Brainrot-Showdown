using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distanceToTarget = 0.5f;

    private void Update()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) > distanceToTarget)
        {
            this.transform.position += (target.transform.position - this.transform.position).normalized * speed * Time.deltaTime;
            this.transform.LookAt(target.transform);
        }
    }
}
