using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{

    MainTurret mainTurret;
    Game_Manager myManager;
    CancelButton myCancel;
    UpgradeValues myValues;

    [SerializeField]
    Text speedText;
    [SerializeField]
    Text rangeText;
    [SerializeField]
    Text damageText;
    [SerializeField]
    Text rateText;

    [SerializeField]
    bool isUpgradable;

    [SerializeField]
    GameObject sButton;
    [SerializeField]
    GameObject rButton;
    [SerializeField]
    GameObject dButton;
    [SerializeField]
    GameObject fButton;
    [SerializeField]
    GameObject cancelButton;


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

    [SerializeField]
    private Stats[] stat;

    [SerializeField]
    private SpeedLevel curSpeed = SpeedLevel.ONE;
    [SerializeField]
    private RangeLevel curRange = RangeLevel.ONE;
    [SerializeField]
    private DamageLevel curDamage = DamageLevel.ONE;
    [SerializeField]
    private FireRateLevel curFireRate = FireRateLevel.ONE;

    [SerializeField]
    float currentOil;
    [SerializeField]
    float speedCost;
    [SerializeField]
    float rangeCost;
    [SerializeField]
    float damageCost;
    [SerializeField]
    float rateCost;

    [SerializeField]
    float speedLevel;
    [SerializeField]
    float rangeLevel;
    [SerializeField]
    float damageLevel;
    [SerializeField]
    float rateLevel;



    // Use this for initialization
    void Awake()
    {
        isUpgradable = false;
        mainTurret = this.gameObject.transform.parent.GetComponent<MainTurret>();
        myManager = GameObject.FindObjectOfType<Game_Manager>().GetComponent<Game_Manager>();
        myValues = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<UpgradeValues>();

        cancelButton = GameObject.FindGameObjectWithTag("Cancel");
        myCancel = cancelButton.GetComponent<CancelButton>();
        sButton = GameObject.FindGameObjectWithTag("SpeedUp");
        rButton = GameObject.FindGameObjectWithTag("RangeUp");
        dButton = GameObject.FindGameObjectWithTag("DamageUp");
        fButton = GameObject.FindGameObjectWithTag("FireUp");

        speedText = sButton.transform.GetChild(0).GetComponent<Text>();
        rangeText = rButton.transform.GetChild(0).GetComponent<Text>();
        damageText = dButton.transform.GetChild(0).GetComponent<Text>();
        rateText = fButton.transform.GetChild(0).GetComponent<Text>();

        speedLevel = 1;
        rangeLevel = 1;
        damageLevel = 1;
        rateLevel = 1;

        speedCost = myValues.StartSpeed();
        rangeCost = myValues.StartRange();
        damageCost = myValues.StartDamage();
        rateCost = myValues.StartRate();

        currentOil = myManager.LevelOil();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentOil();
        myManager.OilAmount();

        SpeedCost();
        RangeCost();
        DamageCost();
        RateCost();

        SpeedCount();
        RangeCount();
        DamageCount();
        RateCount();

        //UpdateUI();
    }

    //Checks for current level to adjust stat
    public void UpdateSpeed()
    {
        if ((isUpgradable == true) && (curSpeed == SpeedLevel.ONE))
        {
            if (myManager.OilAmount() >= speedCost)
            {
                speedCost = 120f;
                speedLevel += 1;
                mainTurret.SpeedUp(stat[0].valueOne);
                curSpeed = SpeedLevel.TWO;
                myManager.MinusOil(speedCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < speedCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curSpeed == SpeedLevel.TWO))
        {
            if (myManager.OilAmount() >= speedCost)
            {
                speedCost = 200f;
                speedLevel += 1;
                mainTurret.SpeedUp(stat[0].valueTwo);
                curSpeed = SpeedLevel.THREE;
                myManager.MinusOil(speedCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < speedCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curSpeed == SpeedLevel.THREE))
        {
            if (myManager.OilAmount() >= speedCost)
            {
                speedCost = 300f;
                speedLevel += 1;
                mainTurret.SpeedUp(stat[0].valueThree);
                curSpeed = SpeedLevel.FOUR;
                myManager.MinusOil(speedCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < speedCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curSpeed == SpeedLevel.FOUR))
        {
            if (myManager.OilAmount() >= speedCost)
            {
                mainTurret.SpeedUp(stat[0].valueFour);
                myManager.MinusOil(speedCost);
                isUpgradable = false;
                myCancel.UpdateFalse();
            }

            if (myManager.OilAmount() < speedCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }
    }

    //Checks for current level to adjust stat
    public void UpdateRange()
    {
        if ((isUpgradable == true) && (curRange == RangeLevel.ONE))
        {
            if (myManager.OilAmount() >= rangeCost)
            {
                rangeCost = 80f;
                rangeLevel += 1;
                mainTurret.RangeUp(stat[1].valueOne);
                curRange = RangeLevel.TWO;
                myManager.MinusOil(rangeCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < rangeCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curRange == RangeLevel.TWO))
        {
            if (myManager.OilAmount() >= rangeCost)
            {
                rangeCost = 120f;
                rangeLevel += 1;
                mainTurret.RangeUp(stat[1].valueTwo);
                curRange = RangeLevel.THREE;
                myManager.MinusOil(rangeCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < rangeCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curRange == RangeLevel.THREE))
        {
            if (myManager.OilAmount() >= rangeCost)
            {
                rangeCost = 180f;
                rangeLevel += 1;
                mainTurret.RangeUp(stat[1].valueThree);
                curRange = RangeLevel.FOUR;
                myManager.MinusOil(rangeCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < rangeCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curRange == RangeLevel.FOUR))
        {
            if (myManager.OilAmount() >= rangeCost)
            {
                mainTurret.RangeUp(stat[1].valueFour);
                myManager.MinusOil(rangeCost);
                isUpgradable = false;
                myCancel.UpdateFalse();
            }

            if (myManager.OilAmount() < rangeCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }
    }

    //Checks for current level to adjust stat
    public void UpdateDamage()
    {
        if ((isUpgradable == true) && (curDamage == DamageLevel.ONE))
        {
            if (myManager.OilAmount() >= damageCost)
            {
                damageCost = 130f;
                damageLevel += 1;
                mainTurret.DamageUp(stat[2].valueOne);
                curDamage = DamageLevel.TWO;
                myManager.MinusOil(damageCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < damageCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curDamage == DamageLevel.TWO))
        {
            if (myManager.OilAmount() >= damageCost)
            {
                damageCost = 180f;
                damageLevel += 1;
                mainTurret.DamageUp(stat[2].valueTwo);
                curDamage = DamageLevel.THREE;
                myManager.MinusOil(damageCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < damageCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curDamage == DamageLevel.THREE))
        {
            if (myManager.OilAmount() >= damageCost)
            {
                damageCost = 240f;
                damageLevel += 1;
                mainTurret.DamageUp(stat[2].valueThree);
                curDamage = DamageLevel.FOUR;
                myManager.MinusOil(damageCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < damageCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curDamage == DamageLevel.FOUR))
        {
            if (myManager.OilAmount() >= damageCost)
            {
                mainTurret.DamageUp(stat[2].valueFour);
                myManager.MinusOil(damageCost);
                isUpgradable = false;
                myCancel.UpdateFalse();
            }

            if (myManager.OilAmount() < damageCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }
    }

    //Checks for current level to adjust stat
    public void UpdateFireRate()
    {
        if ((isUpgradable == true) && (curFireRate == FireRateLevel.ONE))
        {
            if (myManager.OilAmount() >= rateCost)
            {
                rateCost = 80f;
                rateLevel += 1;
                mainTurret.FireUp(stat[3].valueOne);
                curFireRate = FireRateLevel.TWO;
                myManager.MinusOil(rateCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < rateCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curFireRate == FireRateLevel.TWO))
        {
            if (myManager.OilAmount() >= rateCost)
            {
                rateCost = 130f;
                rateLevel += 1;
                mainTurret.FireUp(stat[3].valueTwo);
                curFireRate = FireRateLevel.THREE;
                myManager.MinusOil(rateCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < rateCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curFireRate == FireRateLevel.THREE))
        {
            if (myManager.OilAmount() >= rateCost)
            {
                rateCost = 190f;
                rateLevel += 1;
                mainTurret.FireUp(stat[3].valueThree);
                curFireRate = FireRateLevel.FOUR;
                myManager.MinusOil(rateCost);
                isUpgradable = false;
            }

            if (myManager.OilAmount() < rateCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

        if ((isUpgradable == true) && (curFireRate == FireRateLevel.FOUR))
        {
            if (myManager.OilAmount() >= rateCost)
            {
                mainTurret.FireUp(stat[3].valueFour);
                myManager.MinusOil(rateCost);
                isUpgradable = false;
                myCancel.UpdateFalse();
            }

            if (myManager.OilAmount() < rateCost)
            {
                isUpgradable = false;
                myCancel.UpdateFalse();
            }
        }

    }

    public void UpdateUI()
    {
        speedText.text = "Level: " + SpeedCount() + "\n" + SpeedCost();
        rangeText.text = "Level: " + RangeCount() + "\n" + RangeCost();
        damageText.text = "Level: " + DamageCount() + "\n" + DamageCost();
        rateText.text = "Level: " + RateCount() + "\n" + RateCost();
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

    public float SpeedCost()
    {
        return speedCost;
    }

    public float RangeCost()
    {
        return rangeCost;
    }

    public float DamageCost()
    {
        return damageCost;
    }

    public float RateCost()
    {
        return rateCost;
    }

    public float SpeedCount()
    {
        return speedLevel;
    }

    public float RangeCount()
    {
        return rangeLevel;
    }

    public float DamageCount()
    {
        return damageLevel;
    }

    public float RateCount()
    {
        return rateLevel;
    }



}
