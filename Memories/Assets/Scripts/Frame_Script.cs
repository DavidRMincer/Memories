using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class Frame_Script : MonoBehaviour
{
    public float fadeDuration;
    public Renderer rend;
    public GameObject sceneSpawnPoint;
    public List<GameObject> listofScenes;
    public CameraManager_Script cameraManager;
    public Fungus.Flowchart flowchart;

    internal SceneControls_script currentSceneControls;

    private Material prevMat;
    private GameObject currentScene;

    private void Start()
    {
        prevMat = rend.material;

        //LoadScene(0);
    }

    public void FadePhoto(float duration)
    {
        StartCoroutine(FadePhotoIEnum(duration));
    }

    public IEnumerator FadePhotoIEnum(float duration)
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

        while (counter < duration)
        {
            Debug.Log(alpha);
            counter = (counter > duration) ? duration : counter + Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);

            alpha = Mathf.Lerp(prevAlpha, newAlpha, counter / duration);
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);

            //rend.material.Lerp(prevMat, invisibleMat, counter / fadeDuration);
            //Material.Lerp(prevMat, invisibleMat, counter / fadeDuration);
        }
        Debug.Log(false);

        yield return null;
    }

    public IEnumerator UnloadCurrentScene()
    {
        yield return new WaitForSeconds(fadeDuration + 1f);
        Destroy(currentScene);
    }

    public void LoadScene(int sceneIndex)
    {
        currentScene = Instantiate(listofScenes[sceneIndex], sceneSpawnPoint.transform);
        currentSceneControls = currentScene.GetComponent<SceneControls_script>();

        //StartCoroutine(FadePhotoIEnum(fadeDuration));
    }

    public void UnloadScene()
    {
        //StartCoroutine(FadePhotoIEnum(fadeDuration));
        //StartCoroutine(UnloadCurrentScene());
        Destroy(currentScene);
    }

    public void ActivateScenePhase(int index)
    {
        currentSceneControls.ActivatePhase(index);
    }

    public void DeactivateScenePhases()
    {
        currentSceneControls.DeactivateAllPhases();
    }

    public void TransisitionSceneCam(int index, float duration)
    {
        cameraManager.Transition(currentSceneControls.cameras[index], duration);
    }

    public void LoadFungusBlock(string blockName)
    {
        flowchart.ExecuteBlock(blockName);
    }
}
