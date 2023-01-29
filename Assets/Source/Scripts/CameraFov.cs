using UnityEngine;

public class CameraFov : MonoBehaviour
{
    private Camera _camera;
    private float _initialVerticalFov;
    private float _targetAspect;
    private float _horizontalFov;

    [SerializeField] private Vector2 _refResolution;
    [SerializeField] private float _refHorizonralFov = 60f;
    [SerializeField] private float _cameraZoom;

    [SerializeField]
    [Range(0f, 1f)] private float _matchWidthOrHeight;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        _targetAspect = _refResolution.x / _refResolution.y;
        _initialVerticalFov = _camera.fieldOfView;
        _horizontalFov = CalculateFov(_initialVerticalFov, 1 / _targetAspect);
    }

    private void OnEnable()
    {
        SetCameraFov();
    }

    private void SetCameraFov()
    {
        float constWidthFoV = CalculateFov(_horizontalFov, _camera.aspect);
        _camera.fieldOfView = Mathf.Lerp(constWidthFoV, _initialVerticalFov, _matchWidthOrHeight) * _cameraZoom;

        float currentHorizontalFov = GetCurrentHorizontalFov();
        SetCameraPosition(currentHorizontalFov);
    }

    private void SetCameraPosition(float currentHorizontalFow)
    {
        float cameraStep = currentHorizontalFow - _refHorizonralFov;

        Vector3 nextPosition = transform.position;
        nextPosition.y -= cameraStep;
        transform.position = nextPosition;
    }

    private float CalculateFov(float cameraFov, float aspect)
    {
        var horizontalFovInRad = cameraFov * Mathf.Deg2Rad;
        var verticalFovInRad = 2 * Mathf.Atan(Mathf.Tan(horizontalFovInRad / 2) / aspect);

        return verticalFovInRad * Mathf.Rad2Deg;
    }

    private float GetCurrentHorizontalFov()
    {
        var angleInRad = _camera.fieldOfView * Mathf.Deg2Rad;
        var horizontalFoVInRad = 2 * Mathf.Atan(Mathf.Tan(angleInRad / 2) * _camera.aspect);

        return horizontalFoVInRad * Mathf.Rad2Deg;
    }
}
