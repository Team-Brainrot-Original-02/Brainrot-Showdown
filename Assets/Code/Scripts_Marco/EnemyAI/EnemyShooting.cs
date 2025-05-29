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
        yield return new WaitForSeconds(missleCooldown);
        Instantiate(misslePrefab, missleMuzzle);
    }

    IEnumerator Bomb()
    {
        float cooldown = UnityEngine.Random.Range(minBombCool, maxBombCool);
        yield return new WaitForSeconds(cooldown);
        Instantiate(bombPrefab, bombMuzzle);
    }

    private void StopCorutines()
    {
        StopAllCoroutines();
    }
}
