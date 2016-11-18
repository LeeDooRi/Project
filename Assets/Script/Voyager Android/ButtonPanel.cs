using UnityEngine;
using System.Collections;

public class ButtonPanel : MonoBehaviour
{
    public GameObject buttonObj;

    public GameObject[] btns;

    private UIPanel buttonPanel;
    //private UIGrid uiGrid;

    // Use this for initialization
    void Awake ()
    {
        btns = new GameObject[4];
        for(int i = 0; i < 4; i++)
        {
            btns[i] = Instantiate(this.buttonObj, this.transform.position, Quaternion.identity) as GameObject;
            btns[i].transform.SetParent(this.transform);
            btns[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void makeButton(int count, string[] buttonName, string[] events)
    {
        //SetButtonInactivate();
        for (int i = 0;i < count;i++)
        {
            //GameObject newButtonObj = Instantiate(
            //     this.buttonObj,
            //     this.transform.position + (i - 1) * (new Vector3(0.2f, 0, 0)),
            //     Quaternion.identity) as GameObject;
            
            btns[i].SetActive(true);
            btns[i].transform.position = this.transform.position + (i - 1) * (new Vector3(0.25f, 0, 0));
            UILabel text = btns[i].GetComponentInChildren<UILabel>();
            text.text = buttonName[i];

            //btns[i].SetActive(false);

            btns[i].GetComponent<ButtonInfo>().sceneName = events[i];

            //btns[i].transform.SetParent(this.transform);
            btns[i].transform.localScale = new Vector3(1, 1, 1);

            //button onclick
        }
    }
    public void makeButton(int count, string[] buttonName)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newButtonObj = Instantiate(
                 this.buttonObj,
                 this.transform.position + (i-1)*(new Vector3(0.2f,0,0)),
                 Quaternion.identity) as GameObject;

            UILabel text = newButtonObj.GetComponentInChildren<UILabel>();
            text.text = buttonName[i];

            newButtonObj.transform.SetParent(this.transform);
            newButtonObj.transform.localScale = new Vector3(1, 1, 1);

            //this.uiGrid.Reposition();
            //button onclick
        }
    }

    public void makeButtons()
    {

            GameObject newButtonObj = Instantiate(
                 this.buttonObj,
                 this.transform.position,
                 Quaternion.identity) as GameObject;

            UILabel text = newButtonObj.GetComponent<UILabel>();
            //text.text = buttonName[i];

            newButtonObj.transform.SetParent(this.transform);
            newButtonObj.transform.localScale = new Vector3(1, 1, 1);

            //button onclick
        
    }

    public void SetButtonInactivate()
    {
        if (btns[0].activeSelf == false)
        {
            print("btns are inactive");
            return;
        }

        for(int i = 0; i < 4; i++)
        {
            btns[i].SetActive(false);
        }
    }

}
