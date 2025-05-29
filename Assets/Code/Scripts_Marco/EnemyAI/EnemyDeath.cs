using System;
using UnityEngine;

[System.Serializable]
public class EnemyDeath : EnemyState
{
    public static event Action OnDeath;

    public override void OnEnter(EnemyController _controller)
    {
        Debug.Log("Death invoked");
        OnDeath?.Invoke();
    }

    public override void OnUpdate(EnemyController _controller)
    {
        
    }

    public override void OnExit(EnemyController _controller)
    {

    }

    public override void OnCollision(EnemyController _controller, Collider _collision)
    {

    }

    public override void DrawGizmo(EnemyController _controller)
    {

    }
}
