using UnityEngine;
using UnityEngine.UI;

public class StorePreloader : MonoBehaviour
{
    [SerializeField] public Text coins;
    void Start()
    {
        foreach (var g in GameObject.FindGameObjectsWithTag("StoreItem"))
        {
            if (PlayerPrefs.GetString("allStaff").IndexOf(g.name) != -1)
            {
                if (PlayerPrefs.GetString("currentBG") == g.name)
                    g.gameObject.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Selected";
                else
                    g.gameObject.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Select";
            }
        }

        coins.text = "COINS: " + PlayerPrefs.GetInt("money").ToString();
    }
}
