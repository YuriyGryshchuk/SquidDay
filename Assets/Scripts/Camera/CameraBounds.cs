using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private RectangleBounds _rectBounds;
    private Camera _camera;

    public RectangleBounds RectBounds => _rectBounds;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        CalculateCameraBounds();
    }

    private void CalculateCameraBounds()
    {
        float vertExtent = _camera.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        _rectBounds.minX = -horzExtent;
        _rectBounds.maxX = horzExtent;
        _rectBounds.minY = -vertExtent;
        _rectBounds.maxY = vertExtent;
    }
}