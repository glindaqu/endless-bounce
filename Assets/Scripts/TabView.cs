using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabView : MonoBehaviour
{
    public GameObject current;

    [SerializeField] private GameObject[] tabs;

    public void DisableList(GameObject exp)
    {
        foreach (var tab in tabs)
        {
            tab.SetActive(false);
        }
        exp.SetActive(true);
    }
}
