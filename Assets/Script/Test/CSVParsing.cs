﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CSVParsing : MonoBehaviour
{

    public TextAsset csvFile; // Reference of CSV file
    public InputField rollNoInputField;// Reference of rollno input field
    public InputField nameInputField; // Reference of name input filed
    public Text contentArea; // Reference of contentArea where records are displayed

    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ','; // It defines field seperate chracter
                                       // Use this for initialization
    void Start ()
    {
        //readData();
	}
	
    private void readData()
    {
        string[] records = csvFile.text.Split(lineSeperater);

        foreach(string record in records)
        {
            string[] fields = record.Split(fieldSeperator);

            foreach(string field in fields)
            {
                contentArea.text += field + "\t";
            }
            contentArea.text += '\n';
        }
    }
    public void addData()
    {
        File.AppendAllText(getPath() + "/Assets/Resources/Data.csv", lineSeperater + rollNoInputField.text + fieldSeperator + nameInputField.text);

        rollNoInputField.text = "";
        nameInputField.text = "";
        contentArea.text = "";

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
        readData();
    }

    private static string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath;
#elif UNITY_ANDROID
return Application.persistentDataPath;// +fileName;
#elif UNITY_IPHONE
return GetiPhoneDocumentsPath();// +"/"+fileName;
#else
return Application.dataPath;// +"/"+ fileName;
#endif
    }

    // Get the path in iOS device
    private static string GetiPhoneDocumentsPath()
    {
        string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
        path = path.Substring(0, path.LastIndexOf('/'));
        return path + "/Documents";
    }

    // Following lines refresh the edotor and print data


}
