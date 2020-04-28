using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager_Script : MonoBehaviour
{
    public Camera mainCam;
    public AnimationCurve camAccelerationCurve;
    public Camera[] cameras;
    public GameObject photoMenu;
    public Animator trainAnimator;

    private void Start()
    {
        //Transition(cameras[7], 6);
        trainAnimator.enabled = false;
    }

    public void Transition(Camera newCam, float duration)
    {
        StartCoroutine(TransitionIEnum(newCam, duration));
    }

    /// <summary>
    /// Lerps transformation and FOV of camera
    /// </summary>
    /// <param name="newCam"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator TransitionIEnum(Camera newCam, float duration)
    {
        if (duration == 0f)
        {
            mainCam.transform.position = newCam.transform.position;
            mainCam.transform.rotation = newCam.transform.rotation;
            mainCam.fieldOfView = newCam.fieldOfView;
        }
        else
        {
            float timer = 0f,
                prevFOV = mainCam.fieldOfView;
            Vector3 prevPos = mainCam.transform.position;
            Quaternion prevRot = mainCam.transform.rotation;

            do
            {
                timer = (timer + Time.deltaTime > duration) ? duration : timer + Time.deltaTime;


                float lerpVal = camAccelerationCurve.Evaluate(timer / duration);

                mainCam.transform.position = Vector3.Lerp(prevPos, newCam.transform.position, lerpVal);
                mainCam.transform.rotation = Quaternion.Lerp(prevRot, newCam.transform.rotation, lerpVal);
                mainCam.fieldOfView = Mathf.Lerp(prevFOV, newCam.fieldOfView, lerpVal);

                yield return new WaitForSeconds(Time.deltaTime);

            } while (timer < duration);
        }
        
        yield return null;
    }

    public void SetPhotoMenuActive(bool active)
    {
        photoMenu.SetActive(active);
    }

    public void PlayTrain()
    {
        trainAnimator.enabled = true;
    }
}
