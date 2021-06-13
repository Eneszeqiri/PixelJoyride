using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Rigidbody body;
    public GameObject Ceiling;
    public GameObject Floor;
    public GameObject PrevCeiling;
    public GameObject PrevFloor;

    public GameObject Player;

    public GameObject rocket1;
    public GameObject rocket2;
    public GameObject rocket3;
    public GameObject rocket4;

    public GameObject rocketPrefab;

    public GameObject Coins1;
    public GameObject Coins2;
    public GameObject Coins3;
    public GameObject Coins4;

    public GameObject Coins;

    public float minRocketY;
    public float maxRocketY;

    public float minRocketSpacing;
    public float maxRocketSpacing;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        rocket1 = GenerateRocket(Player.transform.position.x + 10);

        rocket2 = GenerateRocket(rocket1.transform.position.x);

        rocket3 = GenerateRocket(rocket2.transform.position.x);

        rocket4 = GenerateRocket(rocket3.transform.position.x);

        Coins1 = GenerateCoin(Player.transform.position.x + 10);

        Coins2 = GenerateCoin(Coins1.transform.position.x);

        Coins3 = GenerateCoin(Coins2.transform.position.x);

        Coins4 = GenerateCoin(Coins3.transform.position.x);

    }
    GameObject GenerateRocket(float RocketReferenceX)
    {
        GameObject rocket = GameObject.Instantiate(rocketPrefab);
        setTransformRockets(rocket, RocketReferenceX);
        return rocket;
    }

    GameObject GenerateCoin(float CoinReferenceX)
    {
        GameObject coins = GameObject.Instantiate(Coins);
        setTransformCoins(coins, CoinReferenceX);
        return coins;
    }

    void setTransformRockets(GameObject rocket, float referenceX)
    {
        rocket.transform.position =
            new Vector2(
                referenceX + 10f + Random.Range(minRocketSpacing, maxRocketSpacing),
                Random.Range(minRocketY, maxRocketY));
    }

    void setTransformCoins(GameObject coins, float referenceX)
    {
        coins.transform.position =
            new Vector2(
                referenceX + 38f + Random.Range(minRocketSpacing, maxRocketSpacing),
                Random.Range(minRocketY, maxRocketY));
    }
    // Update is called once per frame
    void Update()
    {
        //Generating map
        if (Player.transform.position.x > Floor.transform.position.x)//if the position of the player passes the middle of the "floor"
        {
            var tempCeiling = PrevCeiling; // we put the previous ceiling in a temporary variable
            var tempFloor = PrevFloor; // same as the temporary floor,
            PrevCeiling = Ceiling; // because we will put the "Ceiling" in the previous ceiling,
            PrevFloor = Floor; // And the floor in the previous floor
            PrevCeiling.transform.position += new Vector3(40, 0, 0); //and we will move the ceiling and
            PrevFloor.transform.position += new Vector3(40, 0, 0); // the floor +40 in the x-axis to generate the new field for walking;
            Ceiling = tempCeiling; //then we put the original previous-ceiling in the first-ceiling
            Floor = tempFloor; // and the same with the floors
        }

        //generating Rockets
        if (Player.transform.position.x > rocket2.transform.position.x)
        {
            var tempRocket = rocket1;
            rocket1 = rocket2;
            rocket2 = rocket3;
            rocket3 = rocket4;
            setTransformRockets(tempRocket, rocket3.transform.position.x);
            rocket4 = tempRocket;
        }

        //generating coins
        if (Player.transform.position.x > Coins2.transform.position.x)
        {
            var tempCoin = Coins1;
            Coins1 = Coins2;
            Coins2 = Coins3;
            Coins3 = Coins4;
            setTransformCoins(tempCoin, Coins3.transform.position.x);
            Coins4 = tempCoin;
        }
    }
}
