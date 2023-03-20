using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONReader : MonoBehaviour
{
	public static JSONReader Instance { get; private set; }

	public CoordinateData data;

	private string persistentPath = "";

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		SetPath();
		LoadData();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			LoadData();
		}
	}

	private void SetPath()
	{
		persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
	}

	public void LoadData()
	{
		using StreamReader reader = new StreamReader(persistentPath);
		string json = reader.ReadToEnd();

		data = JsonUtility.FromJson<CoordinateData>(json);

		Debug.Log(data.ToString());
	}
}
