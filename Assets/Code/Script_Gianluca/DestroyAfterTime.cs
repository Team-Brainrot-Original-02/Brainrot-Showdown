using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]private float _LifeTime;
    private float _Timer;
    private void Awake()
    {
        _Timer = _LifeTime;
    }

    private void Update()
    {
        if (_Timer > 0)
        {
            _Timer -= Time.deltaTime;
        }
        else
        { 
            Destroy(gameObject);
        }
    }
}
