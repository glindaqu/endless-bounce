using UnityEngine;
using UnityEngine.UI;

public class GamePreloader : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    [SerializeField] GameObject ball;

    [SerializeField] public Color[] colors;
    [SerializeField] public Sprite[] paddles;
    [SerializeField] public Sprite[] balls;

    void Start()
    {
        paddle.GetComponent<SpriteRenderer>().sprite = paddles[PlayerPrefs.GetInt("Paddle")];
        ball.GetComponent<SpriteRenderer>().sprite = balls[PlayerPrefs.GetInt("Ball")];

        ScoreUpdater.totalTime= 0;  
    }
}
