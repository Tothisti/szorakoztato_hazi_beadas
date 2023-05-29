using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTeleport : MonoBehaviour
{
	public float minX = -23.5f;
	public float maxX = 23.5f;
	public float minY = -23.5f;
	public float maxY = 23.5f;
	private Vector3 randomPosition;

	public float playerRange = 9.0f;
	public float buildingRange = 5.0f;

	public GameObject player;

	private List<GameObject> buildings;

	void Start()
	{
		buildings = new List<GameObject>(GameObject.FindGameObjectsWithTag("Building")); 
		InvokeRepeating("TeleportRandomlyCoroutine", 0f, 5.0f);
	}

	private Vector3 GetRandomPosition()
	{
		
		bool isValidPosition = false;

		while (!isValidPosition)
		{
			float randomX = Random.Range(minX, maxX);
			float randomY = Random.Range(minY, maxY);
			randomPosition = new Vector3(randomX, randomY, transform.position.z);

			float distanceToPlayer = Vector3.Distance(randomPosition, player.transform.position);
			if (distanceToPlayer <= playerRange)
				continue;

			bool isWithinBuildingRange = false;
			for (int i = 0; i < buildings.Count; i++)
			{
				float distanceToBuilding = Vector3.Distance(randomPosition, buildings[i].transform.position);
				if (distanceToBuilding <= buildingRange)
				{
					isWithinBuildingRange = true;
					break;
				}
			}
			if (isWithinBuildingRange)
				continue;

			isValidPosition = true;
		}

		return randomPosition;
	}

	private void TeleportRandomlyCoroutine()
	{
		Vector3[] originalPositions = new Vector3[buildings.Count];
		for (int i = 0; i < buildings.Count; i++)
		{
			originalPositions[i] = buildings[i].transform.position;
		}

		for (int i = 0; i < buildings.Count; i++)
		{
			buildings[i].SetActive(false);
		}

		for (int i = 0; i < buildings.Count; i++)
		{
			Vector3 randomPosition = GetRandomPosition();
			buildings[i].transform.position = randomPosition;
			buildings[i].SetActive(true);
		}
	}


}
