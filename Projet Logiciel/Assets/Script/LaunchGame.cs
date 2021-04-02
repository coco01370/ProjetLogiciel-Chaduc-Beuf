using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    [SerializeField] float timeBeforeGame = 10;
    TMP_Text tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<PlayerController>().Length > 1)
        {
            timeBeforeGame -= Time.deltaTime;

            if (timeBeforeGame <= 0)
            {
                GameManager.instance.CanFight = true;
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            timeBeforeGame = 10;
        }
        tmp.text = $"Seconde before the game : {(int)timeBeforeGame }";

    }
}
