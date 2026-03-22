using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddleScript : MonoBehaviour
{
    private InputAction moveAction;
    private BallScript ballScript;

    private bool isMovementDisabled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
    }

    public void ResetPaddle()
    {
        transform.position = new Vector3(0, -4.22f, 0);
        isMovementDisabled = false;
    }

    public void DisableMovement()
    {
        isMovementDisabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction.IsPressed() && !isMovementDisabled)
        {
            var value = moveAction.ReadValue<Vector2>();

            if (value.x == 0)
            {
                return;
            }

            var position = transform.position;
            var ballPos = ballScript.transform.position;
            var move = 0.1f;

            if (value.x < 0)
            {
                if (position.x > -7.36)
                {
                    position.x -= move;

                    if (ballScript.ballState == BallScript.BallState.Inactive)
                    {
                        ballPos.x -= move;
                        ballScript.transform.position = ballPos;
                    }
                }
            }
            else
            {
                if (position.x < 7.36)
                {
                    position.x += move;

                    if (ballScript.ballState == BallScript.BallState.Inactive)
                    {
                        ballPos.x += move;
                        ballScript.transform.position = ballPos;
                    }
                }
            }
            

            transform.position = position;
        }
    }
}
