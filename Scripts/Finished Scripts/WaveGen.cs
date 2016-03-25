using UnityEngine;
using System.Collections;

public class WaveGen : MonoBehaviour {

	public enum WaveState
	{
		SPAWNING,
		STAND_BY,
		COUNTING
	};

	[System.Serializable]
	public class MyWaves
	{
		public string waveName;
		public Transform thisEnemy;
		public int enemyCount;
		public float spawnRate;
	}

	[SerializeField] private MyWaves[] waves;
	[SerializeField] private Transform[] spawners;

	[SerializeField] private int nextWave = 0;

	[SerializeField] private float waveTimer;
	[SerializeField] private float countDown;
	[SerializeField] private float searchTimer = 2f;

	[SerializeField] private WaveState curState = WaveState.COUNTING;

	// Use this for initialization
	void Start () {

		countDown = waveTimer;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (curState == WaveState.STAND_BY) 
		{
			if(WaveInProgres() == false)
			{
				Debug.Log("Wave Complete");
				return;
			}
			else
			{
				return;
			}
		}
	
		if (countDown <= 0) 
		{
			if (curState != WaveState.SPAWNING)
			{
				StartCoroutine(GenerateWave(waves[nextWave]));
			}
			else
			{
				countDown -= Time.deltaTime;
			}
		}
	}

	bool WaveInProgres()
	{
		searchTimer -= Time.deltaTime;

		if (searchTimer <= 0) 
		{
			searchTimer = 4f;
			if (GameObject.FindGameObjectsWithTag ("Enemy") == null) 
			{
				return false;
			}
		}

		return true;
	}

	IEnumerator GenerateWave(MyWaves _wave)
	{
		curState = WaveState.SPAWNING;

		for (int i = 0; i < _wave.enemyCount; i++) 
		{
			SpawnWave(_wave.thisEnemy);
			yield return new WaitForSeconds(1f/_wave.spawnRate);
		}

		curState = WaveState.STAND_BY;

		yield break;
	}

	void NextWave()
	{
		curState = WaveState.COUNTING;
		countDown = waveTimer;

		if (nextWave + 1 > waves.Length - 1) {
			nextWave = 0;
		} 
		else 
		{
			nextWave++;
		}
	}

	void SpawnWave(Transform _enemy)
	{
		Transform _spawn = spawners [Random.Range (0, spawners.Length)];
		Instantiate (_enemy, _spawn.position, _spawn.rotation);
		Debug.Log ("Spawned" + _enemy.name);
	}

}
