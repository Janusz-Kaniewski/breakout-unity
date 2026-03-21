using UnityEngine;

public class SceneScript : MonoBehaviour
{
    private int playerScore = 0;
    private int playerLives = 3;
    private BallScript ballScript;
    private PlayerPaddleScript playerPaddleScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        playerPaddleScript = GameObject.FindGameObjectWithTag("PlayerPaddle").GetComponent<PlayerPaddleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballScript.isBottomWallHit)
        {
            ballScript.ResetBall();
            playerPaddleScript.ResetPaddle();
            playerLives -= 1;
        }
    }
}
