using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;

    public Vector2 CoinPos { get; private set; }

    private Bounds leftBounds;
    private Bounds rightBounds;

    // Start is called before the first frame update
    void Start()
    {
        leftBounds = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().bounds;
        rightBounds = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>().bounds;
        CoinPos = new Vector2(Random.Range(leftBounds.min.y, leftBounds.max.y), leftBounds.center.x);

        Instantiate(coin, CoinPos, Quaternion.identity);
    }
    public int count;
    // Update is called once per frame
    void Update()
    {
        CoinPos = new Vector2(Random.Range(leftBounds.min.y, leftBounds.max.y), leftBounds.center.x);
        //uninstantiate the coin if the bird flies into it


        //instantiate a coin in the new position
        if (count > 120)
        {
            count = 0;
            
            Instantiate(coin, CoinPos, Quaternion.identity);
        }
        count++;

    }

}
