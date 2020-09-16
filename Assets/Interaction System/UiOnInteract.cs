using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }
    private const float maxRange = 5f;

    public GameObject interactTextUi;
    public float speed;
    public float currentAmount;
    public Image interactProgressImage;
    public bool isProgressImageOn = false;
    public PlayerUi playerUiscript;

    private void Update()
    {
        if (isProgressImageOn == true && Input.GetKeyUp(KeyCode.E)) // if the player lets go if e 
        {
            interactProgressImage.fillAmount = 0.0f; // resets circle to 0 
            currentAmount = 0.0f;
        }
    }


    public void OnStartHover()
    {
        interactTextUi.SetActive(true);
        isProgressImageOn = true;
        
    }

    public void OnInteract()
    {
        UpdateinteractProgressImage();
    }

    private void UpdateinteractProgressImage()
    {
         if(currentAmount < 100 )
        {
            currentAmount += speed * Time.deltaTime; // more speed makes it go faster

        }
        interactProgressImage.fillAmount = currentAmount / 100;
        if (currentAmount >= 100)
        {
            playerUiscript.armor_Icon.enabled = true;
        }


    }
    public void OnEndHover()
    {
        interactTextUi.SetActive(false);
        isProgressImageOn = false;
        interactProgressImage.fillAmount = 0.0f;
        currentAmount = 0.0f;

    }

}
