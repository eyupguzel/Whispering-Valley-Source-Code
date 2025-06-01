using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform clampMin, clampMax;
    private Transform target;

    private Camera cam;

    private float halfWidth, halfHeight;

    private void Start()
    {
        target = PlayerController.Instance.transform;

        clampMin.SetParent(null);
        clampMax.SetParent(null);

        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }
    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = ClampedPosition();
    }

    public Vector3 ClampedPosition()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampMin.position.y + halfHeight, clampMax.position.y - halfHeight);
        return clampedPosition;
    }
}
