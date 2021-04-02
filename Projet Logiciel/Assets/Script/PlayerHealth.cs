using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] SpriteRenderer[] heartDisplay;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Sprite fillHeart;
    [SerializeField] Transform hearHolder;
    [SerializeField] float invicibilityTime;

    float invicibilityCounter;
    int currentHealth;

    public float InvicibilityCounter { get => invicibilityCounter; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    


    private void LateUpdate()
    {
        hearHolder.transform.rotation = Quaternion.Euler(0,0,0);

        if(InvicibilityCounter > 0)
        {
            invicibilityCounter -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            hearHolder.gameObject.SetActive(false);
        }

        if(InvicibilityCounter< 0)
        {
            invicibilityCounter = 0;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            hearHolder.gameObject.SetActive(true);
        }
    }
    public void UpdateHealthDisplay()
    {
        switch (currentHealth)
        {
            case 3:
                heartDisplay[0].sprite = fillHeart;
                heartDisplay[1].sprite = fillHeart;
                heartDisplay[2].sprite = fillHeart;
                break;
            case 2:
                heartDisplay[2].sprite = emptyHeart;
                break;
            case 1:
                heartDisplay[1].sprite = emptyHeart;
                break;
            case 0:
                heartDisplay[0].sprite = emptyHeart;
                break;
        }
    }

    public void DamagePlayer(int damageToTake)
    {
        currentHealth -= damageToTake;
        invicibilityCounter = invicibilityTime;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthDisplay();

        if(currentHealth == 0)
        {
            print("joueur éliminé");
        }
    }

}
