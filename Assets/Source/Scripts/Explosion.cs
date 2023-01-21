using UnityEngine;
using UnityEngine.InputSystem;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _radius;

    private Ray _ray;
    private RaycastHit _hit;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Touch.started += ctx => Shoot(ctx);
    }

    private void OnDisable()
    {
        _playerInput.Player.Touch.started -= ctx => Shoot(ctx);
        _playerInput.Disable();
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        _ray = Camera.main.ScreenPointToRay(_playerInput.Player.Position.ReadValue<Vector2>());
        Physics.Raycast(_ray, out _hit);
        Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.red);
        Explode();
    }

    //private void Update()
    //{
    //    if (Touchscreen.current.wasUpdatedThisFrame)
    //    {
    //        _ray = Camera.main.ScreenPointToRay(Touchscreen.current.position.ReadValue());
    //        Physics.Raycast(_ray, out _hit);
    //        Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.red);
    //        Explode();
    //    }
    //}

    private void Explode()
    {
        foreach (Collider collider in Physics.OverlapSphere(_hit.point, _radius))
        {
            collider.TryGetComponent(out Shard shard);

            if (shard != null)
            {
                Rigidbody rb = shard.Detouch();

                if(rb != null)
                {
                    rb.AddExplosionForce(_explosionForce, _hit.point, _radius, 1, ForceMode.Impulse);
                    Debug.Log("Explode");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_hit.point, _radius);
    }
}
