using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached references
    Level level;
    GameStatus status;

    //state variables
    [SerializeField] int timesHit; //Serialized for debug

    private void Start()
    {
        countBreakableBlocks();
    }

    private void countBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        status = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
        {
            level.countBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("ERROR!!! BLOCK SPRITE MISSING FROM ARRAY ON gameObject." + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(0, 0, 0));
        Destroy(gameObject);
        TriggerBlockVFX();
        level.blockDestroyed();
        status.AddToScore();
    }

    private void TriggerBlockVFX()
    {
        GameObject sparkles = Instantiate(blockVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
