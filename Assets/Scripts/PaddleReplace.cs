using UnityEngine;
using UnityEngine.EventSystems;

public class PaddleReplace : MonoBehaviour, IDragHandler
{
    [SerializeField] Transform paddle;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void OnDrag(PointerEventData e)
    {
        paddle.position = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, paddle.position.y, 0);
    }
}
