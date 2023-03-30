using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorCollision : MonoBehaviour
{
    [SerializeField] private string[] tags;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Array.FindAll(tags, x => x == collision.gameObject.tag).Length > 0)
        {
            FindObjectOfType<ScoreUpdater>().SetBest();
            SceneManager.LoadScene("GameOver");
        }
    }
}
