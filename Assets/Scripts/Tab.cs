using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{    
    public void OnClick()
    {
        FindObjectOfType<TabView>().current = this.gameObject;
        FindObjectOfType<TabView>().DisableList(this.gameObject);
    }
}
