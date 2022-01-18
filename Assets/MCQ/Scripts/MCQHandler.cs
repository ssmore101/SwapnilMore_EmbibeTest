using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MCQHandler : MonoBehaviour
{

    public TextMeshProUGUI[] textFields;

    public List<QAClass> recievedQAs;
    QAClass currentQa;
    public bool isQAListSetup;
    public int currentQuestion;
    public TextMeshProUGUI statusText;
    
    // Start is called before the first frame update
    void Start()
    {
       // isQAListSetup = false;
        currentQuestion = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpQuestionList(List<QAClass> qAClasses)
    {
        recievedQAs = qAClasses;
        if (recievedQAs != null && recievedQAs.Count > 0)
        {
            isQAListSetup = true;
            Debug.Log("MCQHandler: QA List ready for use");
            DisplayQuestion(1);
        }

    }


    public void DisplayQuestion(int index)
    {
        if (isQAListSetup)
        {
            
            currentQa = recievedQAs.Find(x => x.QNo == index);
            if (currentQa == null)
                return;
            if (textFields != null && textFields.Length > 0)
            {
                //currentQuestion = index;
                textFields[0].text = currentQa.Question;
                textFields[1].text = currentQa.OptionA;
                textFields[2].text = currentQa.OptionB;
                textFields[3].text = currentQa.OptionC;
                textFields[4].text = currentQa.OptionD;
            }
        }
    }

    bool IsAnswerCorrect(string AnsKey, QAClass qa)
    {
        if (AnsKey == qa.AnsKey)
            return true;
        else
            return false;
    }

    void CheckAnswerAndDisplayNext(string AnsKey)
    {
        if(IsAnswerCorrect(AnsKey, currentQa))
        {
            Debug.Log("Correct Answer!");
            StartCoroutine(DisplayTextWithDelay("Correct Answer!"));
            if (currentQuestion <= recievedQAs.Count)
            {
                currentQuestion += 1;
                DisplayQuestion(currentQuestion);
            }
            else
            {
                Debug.Log("All Questions Done!");
                
            }
           
            //Navigate to next Question
        }
        else
        {
            Debug.Log("Wrong Answer!");
            StartCoroutine(DisplayTextWithDelay("Wrong Answer!"));
            
        }
    }

    IEnumerator DisplayTextWithDelay(string text)
    {
        statusText.text = text;

        yield return new WaitForSeconds(3f);

        statusText.text = "";
    }



    
}
