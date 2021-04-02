using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<Transform> SpawnPointLocation = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (PlayerController player in FindObjectsOfType<PlayerController>())
        {
            int randomPoint = Random.Range(0, SpawnPointLocation.Count);
            player.gameObject.transform.position = SpawnPointLocation[randomPoint].position;
            SpawnPointLocation.RemoveAt(randomPoint);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
