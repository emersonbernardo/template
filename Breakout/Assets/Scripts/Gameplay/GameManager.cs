using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public delegate void PressPlayAction();
    public static event PressPlayAction OnStartGame;

    public static GameManager Instance { get; private set; }
    [SerializeField]
    private TextMeshProUGUI livesTxt;
    [SerializeField]
    private TextMeshProUGUI levelTxt;
    [SerializeField]
    private TextMeshProUGUI scoreTxt;
    [SerializeField]
    private TextMeshProUGUI promptTxt;
    [SerializeField]
    private GameObject playBtn;
    [SerializeField]
    private GameObject tryAgainBtn;

    //[SerializeField]
    //private LevelConfig level;

    [SerializeField]
    private int playerLives;
    //public int PlayerLives{
    //    get { return playerLives; }
    //    set { playerLives = value; }
    //}

    private int playerScore;
    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    private int curLevel;

    private void Awake()
    {
        InitValues();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: Multiple " + this +" in scene!");
        }
    }

    private void Start()
    {
        tryAgainBtn.SetActive(false);
    }

    public void OnPressPlay()
    {
        OnStartGame();
        playBtn.SetActive(false);
        tryAgainBtn.SetActive(false);
        promptTxt.gameObject.SetActive(false);
        InitValues();
    }

    public void InitValues()
    {
        playerLives = 3;
        curLevel = 1;
        PlayerScore = 0;

        livesTxt.text = "Lives: " + playerLives;
        scoreTxt.text = "Score: " + PlayerScore;
        levelTxt.text = curLevel.ToString();
    }

    public void AddPoints(int points)
    {
        PlayerScore += points;
        scoreTxt.text = "Score: " + PlayerScore;
    }

    public void DeductLives()
    {
        playerLives--;
        livesTxt.text = "Lives: " + playerLives;

        if (playerLives <= 0)
        {
            promptTxt.gameObject.SetActive(true);
            promptTxt.text = "GAME OVER!!!";
            tryAgainBtn.SetActive(true);
        }
    }



    //public GameObject brick;

    //private void Start()
    //{
    //    for (int i = 0; i < 11; i++)
    //    {
    //        Instantiate(brick, transform.position, Quaternion.identity);
    //    }
    //}
}
