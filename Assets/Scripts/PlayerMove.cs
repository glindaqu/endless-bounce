using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //getting mouse pos in word coords
    private Vector3 getMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //player move
    private void OnMouseDrag()
    {
        transform.position = new Vector3(getMousePos().x, transform.position.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bounce b = collision.gameObject.GetComponent<Bounce>();

        if (b != null) 
        {
            Vector3 pPos = this.transform.position;
            Vector2 conactPoint = collision.GetContact(0).point;

            float offset = pPos.x - conactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float curAngle = Vector2.SignedAngle(Vector2.up, b.rb.velocity);
            float bounceAngle = (offset / width) * 75f;
            float newAngle = Mathf.Clamp(curAngle + bounceAngle, -75f, 75f);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            b.rb.velocity = rotation * Vector2.up * b.rb.velocity.magnitude;
        }
    }
}
