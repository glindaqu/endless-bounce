using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    public void OnClick()
    {
        int cost = 0;
        int coins = PlayerPrefs.GetInt("Coins");
        int index = int.Parse(this.name.Split(' ')[1]);
        try
        {
            cost = int.Parse(this.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text.Split(' ')[1]);
        } 
        
        catch
        {

        }

        if (this.gameObject.CompareTag("BGItem") && coins - cost >= 0)
        {
            PlayerPrefs.SetInt("BG", index);
            PlayerPrefs.SetInt("Coins", coins - cost);
            PlayerPrefs.SetString("Staff", PlayerPrefs.GetString("Staff") + (cost == 0 ? "" : this.gameObject.name));
            setValue("ВЫБРАНО", this.GetComponentInChildren<Button>().GetComponentInChildren<Text>(), "BGItem");
            PlayerPrefs.SetInt("Coins", coins - cost);
        }

        else if (this.gameObject.CompareTag("PaddleItem") && coins - cost >= 0)
        {
            PlayerPrefs.SetInt("Paddle", index);
            PlayerPrefs.SetInt("Coins", coins - cost);
            PlayerPrefs.SetString("Staff", PlayerPrefs.GetString("Staff") + (cost == 0 ? "" : this.gameObject.name));
            setValue("ВЫБРАНО", this.GetComponentInChildren<Button>().GetComponentInChildren<Text>(), "PaddleItem");
            PlayerPrefs.SetInt("Coins", coins - cost);
        }

        else if (this.gameObject.CompareTag("BallItem") && coins - cost >= 0)
        {
            PlayerPrefs.SetInt("Ball", index);
            PlayerPrefs.SetInt("Coins", coins - cost);
            PlayerPrefs.SetString("Staff", PlayerPrefs.GetString("Staff") + (cost == 0 ? "" : this.gameObject.name));
            setValue("ВЫБРАНО", this.GetComponentInChildren<Button>().GetComponentInChildren<Text>(), "BallItem");
            PlayerPrefs.SetInt("Coins", coins - cost);
        }
        Camera.main.GetComponent<StorePreloader>().CoinsSetter();
        PlayerPrefs.Save();
    }

    private void setValue(string value, Text field, string tag)
    {
        reZero(tag);
        field.text = value;
    }

    private void reZero(string tag)
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag(tag))
        {
            if (PlayerPrefs.GetString("Staff").IndexOf(g.name) != -1)
            {
                g.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "ВЫБРАТЬ";
            }
        }
    }
}
