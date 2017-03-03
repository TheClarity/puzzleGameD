using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

namespace Completed

{

	public class BoardManager : MonoBehaviour
	{
		[Serializable]
		public class Count
		{
			public int minimum;
			public int maximum;


			//Assignment constructor.
			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}


		public int columns = 8;
		public int rows = 8;
		public Count wallCount = new Count (5, 9);
		public Count foodCount = new Count (1, 5);
		public GameObject exit;
		public GameObject[] floorTiles;
		public GameObject[] wallTiles;
		public GameObject[] foodTiles;
		public GameObject[] sodaTiles;
		public GameObject[] enemyTiles;
		public GameObject[] outerWallTiles;
		public GameObject[] pushWallTiles;

		private Transform boardHolder;
		private List <Vector3> gridPositions = new List <Vector3> ();


		void InitialiseList ()
		{
			gridPositions.Clear ();

			for(int x = 1; x < columns-1; x++)
			{
				for(int y = 1; y < rows-1; y++)
				{
					gridPositions.Add (new Vector3(x, y, 0f));
				}
			}
		}


		void BoardSetup ()
		{
			boardHolder = new GameObject ("Board").transform;

			for(int x = -1; x < columns + 1; x++)
			{
				for(int y = -1; y < rows + 1; y++)
				{
					GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];

					if(x == -1 || x == columns || y == -1 || y == rows)
						toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];

					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

					instance.transform.SetParent (boardHolder);
				}
			}
		}


		Vector3 RandomPosition ()
		{
			Vector3 v = new Vector3 (1,0,0);
			gridPositions.RemoveAt (1);
			return v;
		}
    void walls(GameObject[] tileArray){
			GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
			Vector3 pos = new Vector3 (1,1,1);
			Instantiate(tileChoice, pos, Quaternion.identity);
			 tileChoice = tileArray[Random.Range (0, tileArray.Length)];
			 pos = new Vector3 (2,1,1);
			Instantiate(tileChoice, pos, Quaternion.identity);
			 tileChoice = tileArray[Random.Range (0, tileArray.Length)];
			 pos = new Vector3 (3,1,1);
			Instantiate(tileChoice, pos, Quaternion.identity);
			 tileChoice = tileArray[Random.Range (0, tileArray.Length)];
			 pos = new Vector3 (4,1,1);
			Instantiate(tileChoice, pos, Quaternion.identity);
			 tileChoice = tileArray[Random.Range (0, tileArray.Length)];
			 pos = new Vector3 (4,2,1);
			Instantiate(tileChoice, pos, Quaternion.identity);
			 tileChoice = tileArray[Random.Range (0, tileArray.Length)];
			 pos = new Vector3 (4,3,1);
			Instantiate(tileChoice, pos, Quaternion.identity);
		}
		void plus5(GameObject[] tileArray){
			GameObject tileChoice = tileArray[0];
			Vector3 pos = new Vector3 (1,2,1);
			Instantiate(tileChoice, pos, Quaternion.identity);
		}
		void set5(GameObject[] tileArray){
			GameObject tileChoice = tileArray[1];
			Vector3 pos = new Vector3 (1,3,2);
			Instantiate(tileChoice, pos, Quaternion.identity);
		}
		void pushWall(GameObject[] tileArray){
			GameObject tileChoice = tileArray[0];
			Vector3 pos = new Vector3 (1,4,2);
			Instantiate(tileChoice, pos, Quaternion.identity);
		}
		public void SetupScene (int level)
		{
			BoardSetup ();
			InitialiseList ();
			//LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
			walls(wallTiles);
			plus5(foodTiles);
			set5(foodTiles);
			pushWall(pushWallTiles);
			//LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);

			//Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
		}
	}
}
