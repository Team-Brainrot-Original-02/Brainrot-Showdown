using UnityEngine;

[System.Serializable, RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : EnemyState
{
    private Rigidbody rb;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float minDistanceToPlayer = 4f;
    [SerializeField] private float maxDistanceToPlayer = 6f;
    private Vector3 waypoint;
    [SerializeField] private Transform playerPosition;

    public override void OnEnter(EnemyController _controller /* context -> _contr.GO ho tutti i dati*/)
    {
        Debug.Log("Movement started");
        // generate Waypoint
        //rb = getcomponent();
        rb = _controller.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;

        //BossHealth.OnDeath -= IAmDead;
        //BossHealth.OnDeath += IAmDead;
        //private void IAmDead() => change state machine
    }

    public override void OnUpdate(EnemyController _controller)
    {
        // move to Waypoint
        waypoint = new Vector3(playerPosition.transform.position.x, rb.transform.position.y, 0);
        // if -> at the W || IsOnPlayer
        Vector3 direction = Vector3.Normalize(playerPosition.position - rb.transform.position);
        float currentDistance = Vector3.Distance(playerPosition.position, rb.transform.position);

        Debug.Log($"CurrentDist {currentDistance} {currentDistance < minDistanceToPlayer} {currentDistance > maxDistanceToPlayer}");

        if (currentDistance < minDistanceToPlayer)
        {
            rb.MovePosition(rb.position - direction * Time.deltaTime * speed);
        }
        else if (currentDistance > maxDistanceToPlayer)
        {
            rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
        }
        else
        {
            //rb.MovePosition(Vector3.zero);
            //rb.MovePosition(new Vector3(0, 0, 0));
        }

        /*
        if (currentDistance <= distanceToPlayer)
        {
            rb.MovePosition(rb.position -  direction * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + direction * Time.deltaTime);
            //rb.linearVelocity = new Vector2(direction.x * speed * Time.deltaTime, rb.linearVelocity.y);
        }
        */
    }

    public override void OnExit(EnemyController _controller)
    {
        
    }

    public override void OnCollision(EnemyController _controller, Collider _collision)
    {
        
    }

    public override void DrawGizmo(EnemyController _controller)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_controller.gameObject.transform.position, waypoint);
    }
}
