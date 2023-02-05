using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.left, Space.World);
    }
}
