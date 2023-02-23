using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerate : MonoBehaviour
{
    [SerializeField] private Transform Character;
    [SerializeField] private Coin[] coinPrefabs;
    [SerializeField] private Coin firstCoin;
    [SerializeField] private int coinCount = 8;
    [SerializeField] private float playerCoinDistance = 45;
    public PlatformGenerate _generator;

    public List<Coin> coinSpawned = new List<Coin>();
    private int countCoin = 0;
    enum Pos { Left, Center, Right };
    void Start()
    {
        coinSpawned.Add(firstCoin);

        // StartCoroutine(Create());

    }


    void FixedUpdate()
    {

        //pawned();
        if (Character.localPosition.z > coinSpawned[coinSpawned.Count - 1].End.transform.position.z - playerCoinDistance)
        {
            Spawned();
        }

        SpawnPos();

        // Spawned();


    }



    private void Spawned()
    {



        var pos = (Pos)Random.Range(0, 3);

        switch (pos)
        {

            case Pos.Left:
                for (int i = 0; i < coinPrefabs.Length; i++)
                {
                    Coin newCoin = Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Length)]);



                    countCoin++;
                    //1.25
                    // var previousEndPos = new Vector3(0, 0, coinSpawned[coinSpawned.Count].End.position.z);//0.51

                    // coinSpawned[coinSpawned.Count - 1].transform.position = newCoin.End.position;
                    // newCoin.transform.position = coinSpawned[coinSpawned.Count].transform.position + previousEndPos ;
                    if (countCoin > 1)
                    {
                        var previousEndPos = new Vector3(-1.75f, 0, coinSpawned[coinSpawned.Count - 1].End.position.z);
                        var endPos = newCoin.End.position;
                        newCoin.transform.position = previousEndPos + endPos;
                    }

                    coinSpawned.Add(newCoin);

                    //newCoin.transform.position = Vector3.zero;
                }
                break;

            case Pos.Center:
                {
                    for (int i = 0; i < coinPrefabs.Length; i++)
                    {


                        Coin newCoin = Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Length)]);
                        countCoin++;
                        if (countCoin > 1)
                        {
                            var previousEndPos = new Vector3(0, 0, coinSpawned[coinSpawned.Count - 1].End.position.z);
                            var endPos = newCoin.End.position;
                            newCoin.transform.position = previousEndPos + endPos;
                        }
                        coinSpawned.Add(newCoin);
                    }
                }
                break;

            case Pos.Right:
                {
                    for (int i = 0; i < coinPrefabs.Length; i++)
                    {

                        Coin newCoin = Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Length)]);
                        countCoin++;
                        if (countCoin > 1)
                        {
                            var previousEndPos = new Vector3(1.75f, 0, coinSpawned[coinSpawned.Count - 1].End.position.z);
                            var endPos = newCoin.End.position;
                            newCoin.transform.position = previousEndPos + endPos;
                        }
                        coinSpawned.Add(newCoin);
                    }
                }
                break;



        }


    }



    void SpawnPos()
    {
        if (coinSpawned.Count > coinCount)
        {

            Destroy(coinSpawned[1],1f);
            coinSpawned.RemoveAt(0);

        }
        else if (coinSpawned == null)
        {
            coinSpawned.RemoveAt(0);
            Destroy(coinSpawned[1].gameObject);
            return;
        }


    }

    private IEnumerator Create()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Spawned();
        }


    }




}
