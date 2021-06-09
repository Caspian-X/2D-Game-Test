using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;

    public Vector2 CoinPos { get; private set; }

    private Bounds leftBounds;
    private Bounds rightBounds;
    private Bird bird;
    private bool coinSide; //true = right, false = lefts

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<Bird>();

        coinSide = true;

        leftBounds = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().bounds;
        rightBounds = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>().bounds;
        CoinPos = new Vector2(rightBounds.center.x, Random.Range(rightBounds.min.y, rightBounds.max.y));

        Instantiate(coin, CoinPos, Quaternion.identity);
    }

    void Update()
    {
        //uninstantiate the coin if the bird flies into it
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            //instantiate a coin in the new position
            if (!coinSide)
                CoinPos = new Vector2(rightBounds.center.x, Random.Range(rightBounds.min.y, rightBounds.max.y));
            else if (coinSide)
                CoinPos = new Vector2(leftBounds.center.x, Random.Range(leftBounds.min.y, leftBounds.max.y));
            coinSide = !coinSide;
            Instantiate(coin, CoinPos, Quaternion.identity);
        }

    }

}
