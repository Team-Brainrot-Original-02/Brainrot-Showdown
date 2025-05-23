using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(Player.position);
        Vector3 direction = mousePos - screenPos;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Player.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}


