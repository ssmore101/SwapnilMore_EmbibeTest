using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionClickHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnswerClicked()
    {
        GameObject.Find("MCQCanvas").SendMessage("CheckAnswerAndDisplayNext", tag);
    }
}
