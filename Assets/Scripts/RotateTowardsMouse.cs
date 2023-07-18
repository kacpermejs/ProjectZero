using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAngleProvider
{
    float GetAngle();

    Vector2 GetPointingVector();
}

public class RotateTowardsMouse : MonoBehaviour, IAngleProvider
{
    private Camera _mainCamera;
    private Vector3 _mouseWorld;

    float _angle;
    Vector2 _normalizedPointerVector;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {

        _mouseWorld = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        var rotationRoot = _mouseWorld - transform.position;

        _angle = Mathf.Atan2(rotationRoot.y, rotationRoot.x) * Mathf.Rad2Deg;

        _normalizedPointerVector = new Vector2(rotationRoot.x, rotationRoot.y).normalized;

        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }

    public float GetAngle()
    {
        return _angle;
    }

    public Vector2 GetPointingVector()
    {
        return _normalizedPointerVector;
    }
}
