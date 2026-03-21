using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneScript : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI ballsLeftText;
    public TextMeshProUGUI playInfoText;

    private InputAction jumpAction;

    private int playerScore = 0;
    private int playerLives = 2;
    private BallScript ballScript;
    private PlayerPaddleScript playerPaddleScript;

    public enum GameState
    {
        Begin,
        Game,
        GameOver
    }

    public GameState gameState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameState.Begin;
        
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
        playerPaddleScript = GameObject.FindGameObjectWithTag("PlayerPaddle").GetComponent<PlayerPaddleScript>();

        jumpAction = InputSystem.actions.FindAction("Jump");

        ballsLeftText.text = $"Balls: {playerLives}";
        playerScoreText.text = $"Score: {playerScore}";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Begin)
        {
            if (jumpAction.WasPressedThisFrame())
            {
                ballScript.SetBallAsActive();
                gameState = GameState.Game;
                playInfoText.alpha = 0;
            }
        }

        if (gameState == GameState.Game)
        {
            if (ballScript.isBottomWallHit)
            {
                ballScript.ResetBall();
                playerPaddleScript.ResetPaddle();

                if (playerLives > 0)
                {
                    playerLives -= 1;

                    ballsLeftText.text = $"Balls: {playerLives}";

                    playInfoText.alpha = 1;
                    gameState = GameState.Begin;
                }
                else
                {
                    gameState = GameState.GameOver;
                }
            }
        }

        if (gameState == GameState.GameOver)
        {
            
        }
    }
}
