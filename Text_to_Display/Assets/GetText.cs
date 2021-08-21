using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class GetText : MonoBehaviour
{
	// where to place the text lines when spawned in 3d space
	public Transform contentWindow;

	public GameObject recallTextObject;

	void Start()
	{
		// get the file from its directory or path
		string readFromFilePath = Application.streamingAssetsPath + "/RecallChat/" + "Chat" + ".txt";

		List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

		foreach (string line in fileLines)
		{
			Instantiate(recallTextObject, contentWindow);
			recallTextObject.GetComponent<Text>().text = line;
		}
	}

}