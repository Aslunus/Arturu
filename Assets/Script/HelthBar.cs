using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HelthBar : MonoBehaviour
{
    public void Addhealth(int value)
    {
        GetComponent<Slider>().value += value;
    }
}
