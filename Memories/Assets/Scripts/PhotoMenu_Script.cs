using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoMenu_Script : MonoBehaviour
{
    public Button[] buttons;
    public Sprite[] postSceneSprites;

    private int sceneCounter = 0;

    public void SetButtonVisited(int index)
    {
        buttons[index].interactable = false;
        buttons[index].image.sprite = postSceneSprites[index];

        ++sceneCounter;
        if (sceneCounter == 5)
        {
            buttons[5].gameObject.SetActive(true);
        }
    }
}
