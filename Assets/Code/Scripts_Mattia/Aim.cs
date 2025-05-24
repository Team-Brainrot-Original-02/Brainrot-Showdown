using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public Transform Sight;
    public Camera _MC;
    private Vector3 mousePosition;

    private void Update()
    {
        //Vector3 mousePos = Mouse.current.position.ReadValue();
        //ector3 screenPos = Camera.main.WorldToScreenPoint(Player.position);
        mousePosition = _MC.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //Vector3 direction = mousePos - screenPos;
        Vector3 direction = mousePosition - transform.position;
        //direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Sight.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}


