using UnityEngine;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

public class GrabChildrenLocation : MonoBehaviour {

	/*
	void Start() 
	{
		/*
		print (Application.persistentDataPath);
		StreamWriter sw = File.CreateText (Application.persistentDataPath + "/" + gameObject.name + ".txt");

		foreach (Transform c in transform)
		{
			sw.WriteLine (c.transform.position);
		}

		sw.Close();

		StreamReader fs = File.OpenText (Application.persistentDataPath + "/" + gameObject.name + ".txt");
		string l;
		while ((l = fs.ReadLine()) != null)
		{
			MatchCollection splitUp = Regex.Matches (l, @"\d(?=\.)");

			Vector3 loc = new Vector3(int.Parse (splitUp[0].ToString()),
			                          int.Parse (splitUp[1].ToString()),
			                          int.Parse (splitUp[2].ToString()));
			GameObject next = GameObject.CreatePrimitive(PrimitiveType.Cube);
			next.transform.position = loc;

		}

		//Destroy (gameObject);
	}
*/
}
