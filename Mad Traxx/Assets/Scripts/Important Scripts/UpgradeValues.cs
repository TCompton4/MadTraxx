using UnityEngine;
using System.Collections;

public class UpgradeValues : MonoBehaviour {

    [SerializeField]
    private float startSpeed;

    [SerializeField]
    private float startRange;

    [SerializeField]
    private float startDamage;

    [SerializeField]
    private float startRate;

    // Use this for initialization
    void Start ()
    {
        StartSpeed();
        StartRange();
        StartDamage();
        StartRate();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public float StartSpeed()
    {
        return startSpeed;
    }

    public float StartRange()
    {
        return startRange;
    }

    public float StartDamage()
    {
        return startDamage;
    }

    public float StartRate()
    {
        return startRate;
    }
}
