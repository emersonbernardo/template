using UnityEngine;

public class BrickConfig : ScriptableObject {

    public enum BrickState
    {
        UNTOUCHED,
        WEAKENED,
        DESTROYED
    }

    public BrickState currBrickState;
    public Sprite weakenedSprite;
    public Sprite untouchedSprite;

    private void OnEnable()
    {
        currBrickState = BrickState.UNTOUCHED;
    }
}
