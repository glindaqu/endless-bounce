using UnityEngine;
using UnityEngine.UI;

public class StorePreloader : MonoBehaviour
{
    [SerializeField] GameObject[] list;
    [SerializeField] Text coins;

    private void Start()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString() + "$";

        foreach (GameObject g in list)
        {
            int index = int.Parse(g.name.Split(' ')[1]);

            int BGIndex = PlayerPrefs.GetInt("BG");
            int PaddleIndex = PlayerPrefs.GetInt("Paddle");
            int BallIndex = PlayerPrefs.GetInt("Ball");

            if (PlayerPrefs.GetString("Staff").IndexOf(g.name) != -1)
            {
                if (BGIndex == index && g.CompareTag("BGItem") || PaddleIndex == index && g.CompareTag("PaddleItem") || BallIndex == index && g.CompareTag("BallItem"))
                {
                    g.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "ВЫБРАНО";   
                }

                else
                {
                    g.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "ВЫБРАТЬ";
                }
            }
        }
    }

    public void CoinsSetter()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString() + "$";
    }
}
