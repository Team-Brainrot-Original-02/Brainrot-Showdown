using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // missile (periodic 3s) || bomb (5/10 s + gravity)

    [Header("--- Missle ---")]
    [SerializeField] private float missleCooldown = 3f;
    [SerializeField] private GameObject misslePrefab;
    [SerializeField] private Transform missleMuzzle;

    [Header("--- Bomb ---")]
    [SerializeField] private float minBombCool = 5f;
    [SerializeField] private float maxBombCool = 10f;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform bombMuzzle;
    [Header("--- Ref ---")]
    [SerializeField] private Transform _Target;

    private void Awake()
    {
        EnemyDeath.OnDeath -= StopCorutines;
        EnemyDeath.OnDeath += StopCorutines;
    }

    private void Start()
    {
        StartCoroutine(Missle());
        StartCoroutine(Bomb());
    }

    IEnumerator Missle()
    {
        while (true)
        {
            yield return new WaitForSeconds(missleCooldown);
            GameObject missile = Instantiate(misslePrefab, missleMuzzle.position, Quaternion.identity);
            missile.GetComponent<Rigidbody>().AddForce((_Target.transform.position - this.transform.position).normalized * 10);
        }    
    }

    IEnumerator Bomb()
    {
        while (true) { 
        float cooldown = UnityEngine.Random.Range(minBombCool, maxBombCool);
        yield return new WaitForSeconds(cooldown);
        Instantiate(bombPrefab, bombMuzzle).SetActive(true);
        }
    }

    private void StopCorutines()
    {
        StopAllCoroutines();
    }
}
