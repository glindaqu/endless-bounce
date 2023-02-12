using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    [SerializeField] Text coins;

    public void OnClick()
    {
        var text = "0";

        try
        {
            text = GetComponentInChildren<Button>().GetComponentInChildren<Text>().text.Split(' ')[1];
        }
        catch
        {

        }
        if (PlayerPrefs.GetInt("money") - int.Parse(text) >= 0)
        {
            var color = GetComponentInChildren<Button>().GetComponentInChildren<Image>().color;
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - int.Parse(text));
            PlayerPrefs.SetString("bg", $"{color.ToString().Split('(')[1].Split(')')[0]}");
            PlayerPrefs.SetString("allStaff", PlayerPrefs.GetString("allStaff") + this.name);
            PlayerPrefs.SetString("currentBG", this.name);

            selectionDelete();
            GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Selected";
            coins.text = "COINS: " + (PlayerPrefs.GetInt("money") - int.Parse(text)).ToString();
        }
    }

    private void selectionDelete()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("StoreItem"))
        {
            if (PlayerPrefs.GetString("allStaff").IndexOf(g.name) != -1)
                g.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Select";
        }
    }
}
