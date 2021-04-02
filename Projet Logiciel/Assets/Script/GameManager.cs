using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //public
    public static GameManager instance;
    public bool CanFight;

    //serializeField
    [SerializeField] int maxPlayer = 2;
    
    //private
    List<PlayerController> activePlayer = new List<PlayerController>();
    
    //encapsulation
    public int MaxPlayer { get => maxPlayer; }
    public List<PlayerController> ActivePlayer { get => activePlayer; }
    
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(PlayerController newPlayer)
    {
        if (activePlayer.Count < maxPlayer)
        {
            ActivePlayer.Add(newPlayer);
        }

        if (activePlayer.Count >= maxPlayer)
        {
            FindObjectOfType<PlayerInputManager>().enabled = false;
            FindObjectOfType<JoinPlayerKeyboard2>().enabled = false;
        }
    }
}
