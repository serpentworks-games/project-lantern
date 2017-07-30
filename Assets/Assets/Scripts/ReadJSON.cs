using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ReadJSON : MonoBehaviour {
    private string jsonString;
    private JsonData exampleData;

	// Use this for initialization
	void Start () {
        jsonString = File.ReadAllText(Application.dataPath + "/Resources/Test.json");
        exampleData = JsonMapper.ToObject(jsonString);

        //Debug.Log(jsonString);
        Debug.Log(exampleData["dialogue"][0]["cow_1"]);
        Debug.Log(GetDialogue(0)["cow_2"]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    JsonData GetDialogue(int iD)
    {
        for(int i = 0; i < exampleData[iD].Count; i++)
        {
            if (exampleData[iD][i]["iD"].ToString() == name)
                return exampleData[iD][i];

        }
        return null;
    }
}
