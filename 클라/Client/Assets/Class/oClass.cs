using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RayCastManager
{
    private static RayCastManager instance;

    public static RayCastManager GetInstance()
    {
        if (instance == null)
        {
            instance = new RayCastManager();
        }
        return instance;
    }

    GameObject RayCasting(Ray ray, float size)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, size))
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    public GameObject GetPointObject(Transform tr, float raySize)
    {
        Ray ray = new Ray(tr.position, tr.TransformDirection(Vector3.forward));
        return RayCasting(ray, raySize);
    }
}





public class oClass{}
