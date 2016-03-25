using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {

	MainTurret mainTurret;
	Game_Manager myManager;
	CancelButton myCancel;

	[SerializeField] bool isUpgradable;

//	[SerializeField] Button speedButton;
//	[SerializeField] Button rangeButton;
//	[SerializeField] Button damageButton;
//	[SerializeField] Button fireButton;

	[SerializeField] GameObject sButton;
	[SerializeField] GameObject rButton;
	[SerializeField] GameObject dButton;
	[SerializeField] GameObject fButton;
	[SerializeField] GameObject cancelButton;


//	#region Weapon Check
//
//	[SerializeField] bool isTurret;
//	[SerializeField] bool isFlameThrower;
//	[SerializeField] bool isCannon;
//	[SerializeField] bool isCatapult;
//	[SerializeField] bool isAcid;
//
//	#endregion

	#region Level Enums
	public enum SpeedLevel
	{
		ONE,
		TWO,
		THREE,
		FOUR
	};
		
	public enum RangeLevel
	{
		ONE,
		TWO,
		THREE,
		FOUR
	};

	public enum DamageLevel
	{
		ONE,
		TWO,
		THREE,
		FOUR
	};

	public enum FireRateLevel
	{
		ONE,
		TWO,
		THREE,
		FOUR
	};
	#endregion

	[System.Serializable]
	public class Stats
	{
		public string statName;
		public float valueOne;
		public float valueTwo;
		public float valueThree;
		public float valueFour;
	}

	[SerializeField] private Stats[] stat;

	[SerializeField] private SpeedLevel curSpeed = SpeedLevel.ONE;
	[SerializeField] private RangeLevel curRange = RangeLevel.ONE;
	[SerializeField] private DamageLevel curDamage = DamageLevel.ONE;
	[SerializeField] private FireRateLevel curFireRate = FireRateLevel.ONE;

	[SerializeField] float currentOil;

	// Use this for initialization
	void Awake () 
	{
		isUpgradable = false;
		mainTurret = this.gameObject.transform.parent.GetComponent<MainTurret>();
		myManager = GameObject.FindObjectOfType<Game_Manager>().GetComponent<Game_Manager>();
//		cancelButton = GameObject.FindGameObjectWithTag ("Cancel");
//		myCancel = cancelButton.GetComponent<CancelButton>();
//		speedButton = GameObject.FindGameObjectWithTag ("SpeedUp").GetComponent<Button>();
//		rangeButton = GameObject.FindGameObjectWithTag ("RangeUp").GetComponent<Button>();
//		damageButton = GameObject.FindGameObjectWithTag ("DamageUp").GetComponent<Button>();
//		fireButton = GameObject.FindGameObjectWithTag ("FireUp").GetComponent<Button>();
		sButton = GameObject.FindGameObjectWithTag ("SpeedUp");
		rButton = GameObject.FindGameObjectWithTag ("RangeUp");
		dButton = GameObject.FindGameObjectWithTag ("DamageUp");
		fButton = GameObject.FindGameObjectWithTag ("FireUp");

		currentOil = myManager.LevelOil ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CurrentOil ();
	}

	//Checks for current level to adjust stat
	public void UpdateSpeed()
	{
		if ((isUpgradable == true) && (curSpeed == SpeedLevel.ONE)) {
			mainTurret.SpeedUp (stat [0].valueOne);
			curSpeed = SpeedLevel.TWO;
			myManager.MinusOil(80);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curSpeed == SpeedLevel.TWO)) {
			mainTurret.SpeedUp (stat [0].valueTwo);
			curSpeed = SpeedLevel.THREE;
			myManager.MinusOil(120);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curSpeed == SpeedLevel.THREE)) {
			mainTurret.SpeedUp (stat [0].valueThree);
			curSpeed = SpeedLevel.FOUR;
			myManager.MinusOil(200);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curSpeed == SpeedLevel.FOUR)) {
			mainTurret.SpeedUp (stat [0].valueFour);
			myManager.MinusOil(300);
			isUpgradable = false;
			myCancel.StopCover();
		}
	}

	//Checks for current level to adjust stat
	public void UpdateRange()
	{
		if ((isUpgradable == true) && (curRange == RangeLevel.ONE)) {
			mainTurret.RangeUp (stat [1].valueOne);
			curRange = RangeLevel.TWO;
			myManager.MinusOil(60);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curRange == RangeLevel.TWO)) {
			mainTurret.RangeUp (stat [1].valueTwo);
			curRange = RangeLevel.THREE;
			myManager.MinusOil(80);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curRange == RangeLevel.THREE)) {
			mainTurret.RangeUp (stat [1].valueThree);
			curRange = RangeLevel.FOUR;
			myManager.MinusOil(120);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curRange == RangeLevel.FOUR)) {
			mainTurret.RangeUp (stat [1].valueFour);
			myManager.MinusOil(180);
			isUpgradable = false;
			myCancel.StopCover();
		}
	}

	//Checks for current level to adjust stat
	public void UpdateDamage()
	{
		if ((isUpgradable == true) && (curDamage == DamageLevel.ONE)) {
			mainTurret.DamageUp (stat [2].valueOne);
			curDamage = DamageLevel.TWO;
			myManager.MinusOil(90);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curDamage == DamageLevel.TWO)) {
			mainTurret.DamageUp (stat [2].valueTwo);
			curDamage = DamageLevel.THREE;
			myManager.MinusOil(130);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curDamage == DamageLevel.THREE)) {
			mainTurret.DamageUp (stat [2].valueThree);
			curDamage = DamageLevel.FOUR;
			myManager.MinusOil(180);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curDamage == DamageLevel.FOUR)) {
			mainTurret.DamageUp (stat [2].valueFour);
			myManager.MinusOil(240);
			isUpgradable = false;
			myCancel.StopCover();
		}
	}

	//Checks for current level to adjust stat
	public void UpdateFireRate()
	{
		if ((isUpgradable == true) && (curFireRate == FireRateLevel.ONE)) {
			mainTurret.FireUp (stat [3].valueOne);
			curFireRate = FireRateLevel.TWO;
			myManager.MinusOil(40);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curFireRate == FireRateLevel.TWO)) {
			mainTurret.FireUp (stat [3].valueTwo);
			curFireRate = FireRateLevel.THREE;
			myManager.MinusOil(80);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curFireRate == FireRateLevel.THREE)) {
			mainTurret.FireUp (stat [3].valueThree);
			curFireRate = FireRateLevel.FOUR;
			myManager.MinusOil(130);
			isUpgradable = false;
		}

		if ((isUpgradable == true) && (curFireRate == FireRateLevel.FOUR)) {
			mainTurret.FireUp (stat [3].valueFour);
			myManager.MinusOil(190);
			isUpgradable = false;
			myCancel.StopCover();
		}

	}

	//When weapon is tapped upgradable is true
	public void CanUpgrade(bool canDo)
	{
		isUpgradable = canDo;
	}

	public float CurrentOil()
	{
		return currentOil;
	}



}
