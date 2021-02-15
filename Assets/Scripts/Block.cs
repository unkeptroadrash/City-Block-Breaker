using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // configuration parameters
    [SerializeField] AudioClip breakSound;
    Level level;
    GameStatus status;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
        status = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(0,0,0));
        Destroy(gameObject);
        level.blockDestroyed();
        status.AddToScore();
    }
}
