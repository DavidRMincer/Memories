using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Frame_Script : MonoBehaviour
{
    public float fadeDuration;
    public Renderer rend;
    public GameObject sceneSpawnPoint;
    public List<GameObject> listofScenes;

    private Material prevMat;
    private GameObject currentScene;

    private void Start()
    {
        prevMat = rend.material;

        //LoadScene(0);
    }

    public IEnumerator FadePhoto()
    {
        Debug.Log(true);
        //Color prevColour = rend.material.color,
        //    newColour = (rend.material.color.a == 1)
        //    ? new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0f)
        //    : new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1f);
        float counter = 0f,
            alpha = rend.material.color.a,
            prevAlpha = alpha,
            newAlpha = (alpha == 1f) ? 0f : 1f;

        //rend.material.Lerp(prevMat, invisibleMat, fadeDuration);

        while (counter < fadeDuration)
        {
            Debug.Log(alpha);
            counter = (counter > fadeDuration) ? fadeDuration : counter + Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);

            alpha = Mathf.Lerp(prevAlpha, newAlpha, counter / fadeDuration);
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);

            //rend.material.Lerp(prevMat, invisibleMat, counter / fadeDuration);
            //Material.Lerp(prevMat, invisibleMat, counter / fadeDuration);
        }
        Debug.Log(false);

        yield return null;
    }

    public void LoadScene(int sceneIndex)
    {
        Debug.Log("CLICKED");
        currentScene = Instantiate(listofScenes[sceneIndex], sceneSpawnPoint.transform);

        StartCoroutine(FadePhoto());
    }
}
