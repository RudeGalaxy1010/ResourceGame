using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _pointerIcon;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 rayDirection = transform.position - _player.transform.position;
        Ray ray = new Ray(_player.transform.position, rayDirection);

        float minDistance = GetMinDistance(ray, rayDirection.magnitude, out int planeIndex);

        Vector3 worldPosition = ray.GetPoint(minDistance);
        _pointerIcon.transform.position = _camera.WorldToScreenPoint(worldPosition);
        RotateIcon(planeIndex);
    }

    private float GetMinDistance(Ray ray, float rayDistance, out int planeIndex)
    {
        // Left, Right, Down, Up
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera).Take(4).ToArray();
        float minDistance = float.MaxValue;
        planeIndex = 0;

        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    planeIndex = i;
                }
            }
        }

        if (minDistance >= rayDistance)
        {
            planeIndex = -1;
        }

        return Mathf.Clamp(minDistance, 0, rayDistance);
    }

    private void RotateIcon(int planeIndex)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 180f);

        switch (planeIndex)
        {
            case 0:
                rotation = Quaternion.Euler(0, 0, 90f);
                break;
            case 1:
                rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 2:
                rotation = Quaternion.Euler(0, 0, 180f);
                break;
            case 3:
                rotation = Quaternion.Euler(0, 0, 0);
                break;
        }

        _pointerIcon.rotation = rotation;
    }
}
