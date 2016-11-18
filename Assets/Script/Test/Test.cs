using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    public int _exp = 0;

	void Start ()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Data");

        for (var i = 0; i < data.Count; i++)
        {
            Debug.Log("index" + (i).ToString() + " : " + data[i]["Scene"] + " : " + data[i]["Event"] + " : " + data[i]["Choice"] + " : " + data[i]["Speaker"] + " : " + data[i]["Korean"]) ;
        }

        //_exp = (int)data[0]["Scene"];

        Debug.Log(_exp);
	}

}
