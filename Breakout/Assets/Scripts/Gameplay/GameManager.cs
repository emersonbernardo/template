using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject brick;

    private void Start()
    {
        for (int i = 0; i < 11; i++)
        {
            Instantiate(brick, transform.position, Quaternion.identity);
        }
    }
}
