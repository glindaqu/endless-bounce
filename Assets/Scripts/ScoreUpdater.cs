using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public static float totalTime = 0;
    [SerializeField] private Text score;
    [SerializeField] private Text bestScore;

    void Update()
    {
        totalTime += Time.deltaTime;
        score.text = ((int)totalTime).ToString();
        bestScore.text = "ЛУЧШЕЕ: " + (((int)totalTime) > PlayerPrefs.GetInt("Best") ? (int)totalTime : PlayerPrefs.GetInt("Best")).ToString();
    }

    public void SetBest()
    {
        PlayerPrefs.SetInt("Best", int.Parse(score.text));
    }
}
