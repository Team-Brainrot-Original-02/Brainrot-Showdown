using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform _Player;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_Player);
    }
}
