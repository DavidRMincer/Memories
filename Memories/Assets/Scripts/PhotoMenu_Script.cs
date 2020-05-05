using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoMenu_Script : MonoBehaviour
{
    public Button[] buttons;
    public Sprite[] postSceneSprites;
    public TMPro.TextMeshProUGUI mainText;
    public Image whiteOut,
        introText;

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

    private IEnumerator FadeTextIEnum(Color newColour, float duration)
    {
        Color oldColour = mainText.color;
        float counter = 0f;

        do
        {
            counter = (counter + Time.deltaTime > duration) ? duration : counter + Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);

            mainText.color = Color.Lerp(oldColour, newColour, counter / duration);
        } while (counter < duration);
    }

    public void FadeText(Color newColour, float duration)
    {
        StartCoroutine(FadeTextIEnum(newColour, duration));
    }

    private IEnumerator FadeImgEnum(Image img, Color newColour, float duration)
    {
        Color oldColour = img.color;
        float counter = 0f;

        do
        {
            counter = (counter + Time.deltaTime > duration) ? duration : counter + Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);

            img.color = Color.Lerp(oldColour, newColour, counter / duration);
        } while (counter < duration);
    }

    public void FadeWhiteOut(Color newColour, float duration)
    {
        StartCoroutine(FadeImgEnum(whiteOut, newColour, duration));
    }

    public void FadeIntroText(Color newColour, float duration)
    {
        StartCoroutine(FadeImgEnum(introText, newColour, duration));
    }
}
