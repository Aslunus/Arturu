using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public void firePistol(GameObject fire)
    {
        fire.SetActive(!fire.activeSelf);
    }
}
