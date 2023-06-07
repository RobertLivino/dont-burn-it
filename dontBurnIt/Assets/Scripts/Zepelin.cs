using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zepelin : MonoBehaviour
{
    RectTransform trsfrm;

    private void Start()
    {
        trsfrm = GetComponent<RectTransform>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        trsfrm.transform.localPosition += Vector3.left;
    }


}
