using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGeneration : MonoBehaviour
{
	[SerializeField] int width, height;
	[SerializeField] Tile dirt, grass, stone;
	[SerializeField] int minStoneHeight, maxStoneHeight;
	public Tilemap tiles;
	[SerializeField] private GameObject aStar;
	public Tile objectToCreate;
	public GameObject test, therapist;
	public GameObject [] items = new GameObject [10];
	private int [] itemsPositions = new int [10];
	private int [] enemiesPositions = new int [10];
	private GameObject [] enemies;

    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    // Update is called once per frame
    void Generation()
    {
		int currentObjectCounter = 0;
		int currentEnemyCounter = 0;
		bool checkValidity = false;
		int checkBounce = (int) (width - 20) / items.Length;
		int platformPosition1 = (int)Random.Range(1, 8);
		int collectibleCounter = 0;
		Debug.Log(checkBounce);
		for (int counter = 0; counter < items.Length; counter++) {
			int tempValue = 10 + (int)Random.Range((checkBounce * counter), ((checkBounce * counter) + checkBounce));
			/*checkValidity = false;
			for (int innerCounter = 0; innerCounter < currentObjectCounter; innerCounter++) {
				if ((itemsPositions[innerCounter] - tempValue > ) && (itemsPositions[innerCounter] - tempValue < 3)) {
					checkValidity = true;
					counter--;
					break;
				}
			}
			if (!checkValidity) {*/
			itemsPositions[counter] = tempValue;
			
		}

        for (int x = 0; x < width; x++) {
			int minHeight = height - 1;
			int maxHeight = height + 2;
			height = Random.Range(minHeight, maxHeight);
			int minStoneSpawnDistance = height - minStoneHeight;
			int maxStoneSpawnDistance = height - maxStoneHeight;
			int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);
			for (int y = 0; y < height; y++) {
				if (y < totalStoneSpawnDistance) {
					tiles.SetTile(new Vector3Int(x, y, 0), stone);
				} else {
					tiles.SetTile(new Vector3Int(x, y, 0), dirt);
				}
			}
			if (totalStoneSpawnDistance == height) {
				tiles.SetTile(new Vector3Int(x, height, 0), stone);
			} else {
				tiles.SetTile(new Vector3Int(x, height, 0), grass);
			}
			for (currentObjectCounter = 0; currentObjectCounter < items.Length; currentObjectCounter++) {
				if (x == itemsPositions[currentObjectCounter]) {
					if (items[currentObjectCounter].tag == "Platform") {
						Instantiate(items[currentObjectCounter], new Vector3Int(itemsPositions[currentObjectCounter], height + 2, 0), Quaternion.identity);
					}
					/*if (items[currentObjectCounter].tag == "Collectible") {
						collectibleCounter++;
						Instantiate(items[currentObjectCounter], new Vector3Int(itemsPositions[currentObjectCounter], height + 1, 0), Quaternion.identity);
					}*/
					Instantiate(items[currentObjectCounter], new Vector3Int(itemsPositions[currentObjectCounter], height + 1, 0), Quaternion.identity);
					if (items[currentObjectCounter].tag == "Box") {
						Instantiate(items[currentObjectCounter], new Vector3Int(itemsPositions[currentObjectCounter], height + 2, 0), Quaternion.identity);
					}
					currentObjectCounter++;
				}
			}
			if (x == width - 5) {
				Instantiate(therapist, new Vector3Int(x, height + 1, 0), Quaternion.identity);
			}
		}
		//int tempValue = (int)Random.Range(10f, (float)(width - 10));
		//Instantiate(test, new Vector3Int(tempValue, height + 1, 0), Quaternion.identity);
		//RandomPositions();
		StartCoroutine(ExampleCoroutine());
    }

	IEnumerator ExampleCoroutine() {
		yield return new WaitForSeconds(1);
		if (!aStar.activeSelf) {
			aStar.SetActive(true);
		}
	}
}
