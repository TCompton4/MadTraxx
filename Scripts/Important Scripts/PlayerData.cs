using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour {

	public static PlayerData playerData;

	public float baseDef;
	public float waterResource;
	public int upgradeOne;
	public int upgradeTwo;
	public int upgradeThree;
	public int upgradeFour;

	// Use this for initialization
	void Awake () 
	{
		if (playerData == null) {
			DontDestroyOnLoad (gameObject);
			playerData = this;
		} else if (playerData != null) 
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerData.dat");

		SaveData data = new SaveData ();
		data.baseDef = baseDef;
		data.waterResource = waterResource;
		data.upgradeOne = upgradeOne;
		data.upgradeTwo = upgradeTwo;
		data.upgradeThree = upgradeThree;
		data.upgradeFour = upgradeFour;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerData.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);

			SaveData data = (SaveData)bf.Deserialize(file);
			file.Close();

			baseDef = data.baseDef;
			waterResource = data.waterResource;
			upgradeOne = data.upgradeOne;
			upgradeTwo = data.upgradeTwo;
			upgradeThree = data.upgradeThree;
			upgradeFour = data.upgradeFour;

		}
	}
}

[Serializable]
class SaveData
{
	public float baseDef;
	public float waterResource;
	public int upgradeOne;
	public int upgradeTwo;
	public int upgradeThree;
	public int upgradeFour;
}
