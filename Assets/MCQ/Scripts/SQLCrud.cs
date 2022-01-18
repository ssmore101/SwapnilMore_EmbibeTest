using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;

public class SQLCrud : MonoBehaviour
{
    [SerializeField]
    public List<QAClass> QuestionAnswers;

    public GameObject MCQHandler;

    string connectionString;

    [System.Obsolete]
    void Start()
    {
        QuestionAnswers = new List<QAClass>();
        ConnectionDB();     
        IDbConnection dbcon = new SqliteConnection(connectionString);
        dbcon.Open();
        IDbCommand dbcmd;
        IDataReader reader;
        IDbCommand cmnd_read = dbcon.CreateCommand();
       
        string query = "SELECT * FROM QuestionAnswers";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read())
        {
            QAClass qa = new QAClass();
            qa.QNo = int.Parse(reader[0].ToString());
            qa.Question = reader[1].ToString();
            qa.OptionA = reader[2].ToString();
            qa.OptionB = reader[3].ToString();
            qa.OptionC = reader[4].ToString();
            qa.OptionD = reader[5].ToString();
            qa.AnsKey = reader[6].ToString();
            QuestionAnswers.Add(qa);
            Debug.Log(qa.ToString());
            
        }
        if(QuestionAnswers!=null && QuestionAnswers.Count>0)
        {
            MCQHandler.SendMessage("SetUpQuestionList", QuestionAnswers, SendMessageOptions.DontRequireReceiver);      
        }
        dbcon.Close();
    }

    [System.Obsolete]
    public void ConnectionDB()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            connectionString = "URI=file:"+Application.streamingAssetsPath + "/MCQDB.db";
        }
        else
        {

            if (File.Exists(connectionString))
            {
                File.Delete(connectionString);
            }

            connectionString = "URI=file:"+Application.persistentDataPath + "/MCQDB.db";

            try
            {
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/MCQDB.db"); //Streaming assets path
                while (!load.isDone)
                {
                    Debug.Log("Loading File...");
                }
                Debug.Log("Load Done");
                File.WriteAllBytes(Application.persistentDataPath + "/MCQDB.db", load.bytes);
            }
            catch(Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }

    }
}
