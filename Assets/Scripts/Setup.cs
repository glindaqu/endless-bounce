using UnityEngine;

public class Setup : MonoBehaviour
{
    //btn restart
    [SerializeField] GameObject restart;
    //btn menu
    [SerializeField] GameObject menu;

    void Start()
    {
        restart.SetActive(false);
        menu.SetActive(false);

        if (PlayerPrefs.GetString("bg") != "")
        {
            Color color = Color.white;
            string[] colorText = PlayerPrefs.GetString("bg").Split(',');
            color.r = float.Parse(colorText[0]);
            color.g = float.Parse(colorText[1]);
            color.b = float.Parse(colorText[2]);
            color.a = float.Parse(colorText[3]);
            Camera.main.backgroundColor = color;
        }
    }
}
