using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance {get; private set;}

    void Start()
    {
        Instance = this;
    }
    public void SwitchViews()
    {
        this.transform.Rotate(new Vector3(0, 180, 0));
    }
}
