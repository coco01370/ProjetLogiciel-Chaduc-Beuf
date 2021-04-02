using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayerKeyboard2 : MonoBehaviour
{
    public GameObject playerToLoad;
    private bool hasLoadedPlayer = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLoadedPlayer && GameManager.instance.ActivePlayer.Count< GameManager.instance.MaxPlayer)
        {
            if (Keyboard.current.jKey.wasPressedThisFrame ||
               Keyboard.current.lKey.wasPressedThisFrame ||
               Keyboard.current.rightShiftKey.wasPressedThisFrame ||
               Keyboard.current.kKey.wasPressedThisFrame)
            {
                Instantiate(playerToLoad, transform.position, transform.rotation);
                hasLoadedPlayer = true;

            }
        }
    }
}
