using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    public GameObject cube01,cube03,sphere02,cylinder04;
    public TextMeshProUGUI answerText;
    Vector3 CubePosition = new Vector3(0, 0, 0);

    public void onCorrectAns()
    {
        cube01.SetActive(false);
        cylinder04.SetActive(false);
        cube03.SetActive(true);
        sphere02.SetActive(false);
        answerText.text = "Correct Answer";
    }
    public void onIncorrectAns()
    {
        answerText.text = "Incorrect Answer";
        cube01.transform.position = CubePosition;
    }
}

public enum objects
    {
    cube01,
    cube03,
    sphere02,
    cylinder04
}