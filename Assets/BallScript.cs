using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsShape;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private float velocityX;
    private float velocityY;

    public bool isBottomWallHit;

    public enum BallState
    {
        Inactive,
        Active,
        Frozen
    }

    public BallState ballState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballState = BallState.Inactive;
        
        rigidbody = GetComponent<Rigidbody2D>();

        velocityX = 5;
        velocityY = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBallAsActive()
    {
        if (ballState == BallState.Inactive)
        {
            ballState = BallState.Active;
            rigidbody.linearVelocity = new Vector2(velocityX, velocityY);
        }
    }

    public void ResetBall()
    {
        ballState = BallState.Inactive;
        transform.position = new Vector3(0, -3.73f, 0);
        isBottomWallHit = false;
        velocityX = 5;
        velocityY = 2;
        rigidbody.linearVelocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballState == BallState.Active)
        {
            if (collision.gameObject.CompareTag("BottomWall"))
            {
                ballState = BallState.Frozen;
                rigidbody.linearVelocity = new Vector2(0, 0);
                isBottomWallHit = true;
                return;
            }

            //if (collision.gameObject.CompareTag("TopWall") || collision.gameObject.CompareTag("PlayerPaddle"))
            //{
            //    velocityY *= -1;
            //}

            //if (collision.gameObject.CompareTag("LeftWall") || collision.gameObject.CompareTag("RightWall"))
            //{
            //    velocityX *= -1;
            //}

            if (collision.gameObject.CompareTag("PlayerPaddle"))
            {
                var contactPoint = collision.GetContact(0);
                print(contactPoint.collider.name + " hit " + contactPoint.otherCollider.name);
                Vector2 localPoint = transform.InverseTransformPoint(contactPoint.point);
                float normalized = localPoint.x / (collision.collider.bounds.extents.x);
                print(normalized);
            }

            //rigidbody.linearVelocity = new Vector2(velocityX, velocityY);
        }
    }
}
