using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public enum BrickState
    {
        UNTOUCHED,
        WEAKENED,
        DESTROYED
    }

    public BrickState currBrickState;
    public BrickConfig brickConfig;

    private int brickLife;

    private void Awake()
    {
        currBrickState = BrickState.UNTOUCHED;
        brickLife = brickConfig.brickLife;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            brickLife--;
        }
        ChangedState();
    }

    private void ChangedState()
    {
        if (brickLife < brickConfig.brickLife && brickLife != 0)
        {
            currBrickState = BrickState.WEAKENED;
        }
        else if (brickLife == 0)
        {
            currBrickState = BrickState.DESTROYED;
            
        }

        SetSprite();
    }

    private void SetSprite()
    {
        switch (currBrickState)
        {
            case BrickState.WEAKENED:
                GetComponent<SpriteRenderer>().sprite = brickConfig.weakenedSprite;
                break;
            case BrickState.DESTROYED:
                Destroy(this.gameObject);
                GameManager.Instance.AddPoints(brickConfig.brickPoints);
                break;
        }
    }
}
