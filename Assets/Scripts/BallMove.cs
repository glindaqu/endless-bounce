using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed = 500;

    [SerializeField] public Rigidbody2D rb;

    private void Start()
    {
        setRandomVector();
    }

    private void setRandomVector()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1, 1);
        force.y = -1;

        rb.AddForce(force.normalized * speed);
    }
}