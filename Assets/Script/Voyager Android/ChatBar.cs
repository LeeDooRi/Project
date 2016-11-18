using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatBar : MonoBehaviour
{
    private ChatList parentChatList;

    private UILabel text;

    public int dataCnt = 0;
    void Awake()
    {
        //Transform textTrans = this.transform.FindChild("Chatting");
        //if(textTrans != null)
        //{
          //  text = GetComponentInChildren<UILabel>();
        //}
    }
    
    void Start()
    {
       // parentChatList = this.GetComponentInParent<ChatList>();

       // List<Dictionary<string, object>> data = CSVReader.Read("Data");

       // int dataCnt = data.Count;

       //for (var i = 0; i < dataCnt; i++)
       // {
       //     // Debug.Log("index" + (i).ToString() + " : " + data[i]["Scene"] + " " + data[i]["Event"] + " " + data[i]["Choice"] + data[i]["Speaker"] + data[i]["Korean"]);
       //     //text.text = "12345";
       //     Debug.Log("1");

       //     text.text = (i).ToString() + data[i]["Scene"]+ data[i]["Speaker"];

       //     Debug.Log(data[i]["Scene"]);
       //     //dataCnt = (int)data[1]["Scene"];
       //     //Debug.Log(dataCnt);

       //     //text.text = dataCnt;
       // }

        //_exp = (int)data[0]["Scene"];

        //Debug.Log(_exp);
    }
    // Update is called once per frame

    public void SetTextInfo()
    {
    }
	void Update ()
    {
	
	}
}
