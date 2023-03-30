using UnityEngine;
using UnityEngine.UI;

public class CoinsViewer : MonoBehaviour
{
    [SerializeField] Text t;

    void Start()
    {
        t.text = "YOU GOT " + ((int)ScoreUpdater.totalTime).ToString() + " COINS";
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + (int)ScoreUpdater.totalTime);
    }
}
