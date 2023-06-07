using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCamera : MonoBehaviour
{
    bool isActive;
    [SerializeField] private Camera mainCamera;
    public float time;

    private void Start()
    {
        isActive = false;
    }

    public void ToggleCamera()
    {
        isActive = true;

        mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = .8f;
        gameObject.SetActive(isActive);

        StartCoroutine(turnOffCamera());
    }

    IEnumerator turnOffCamera()
    {
        yield return new WaitForSeconds(time);
        isActive = false;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(time);
        mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0;
    }

}
