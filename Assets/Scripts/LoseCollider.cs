using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        loadGameOver("Game Over");
    }

    public void loadGameOver(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
