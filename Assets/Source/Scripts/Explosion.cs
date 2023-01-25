using JetBrains.Rider.Unity.Editor;
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
        _playerInput.Player.Touch.started += _ => Shoot();
    }

    private void OnDisable()
    {
        _playerInput.Player.Touch.started -= _ => Shoot();
        _playerInput.Disable();
    }

    private void Shoot()
    {
        _ray = Camera.main.ScreenPointToRay(_playerInput.Player.Position.ReadValue<Vector2>());
        Physics.Raycast(_ray, out _hit);
        Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.red);
        Explode();
    }

    private void Explode()
    {
        foreach (Collider collider in Physics.OverlapSphere(_hit.point, _radius))
        {
            if (collider.TryGetComponent(out IDestroyable destroyable))
            {
                destroyable.WakeUp();
                destroyable.ExplosionImpact(_explosionForce, _hit.point, _radius);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_hit.point, _radius);
    }
}
