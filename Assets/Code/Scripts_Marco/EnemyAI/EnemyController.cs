using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private EnemyState _currentState;

    [Header("Movement Settings")]
    [field: SerializeField] public EnemyMovement EnemyMovement { get; private set; }

    [Header("Death")]
    [field: SerializeField] public EnemyDeath EnemyDeath { get; private set; }

    private void Awake()
    {
        SetState(EnemyMovement);
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnUpdate(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_currentState != null) _currentState.OnCollision(this, other);
    }

    public void SetState(EnemyState _state)
    {
        if (_state == null) return;

        if (_currentState != null)
            _currentState.OnExit(this);

        _currentState = _state;

        _currentState.OnEnter(this);
    }

    private void OnDrawGizmos()
    {
        if (_currentState != null) _currentState.DrawGizmo(this);
    }
}
