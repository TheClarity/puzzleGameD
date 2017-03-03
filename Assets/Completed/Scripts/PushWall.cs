using UnityEngine;
using System.Collections;

namespace Completed
{
	public class PushWall : MonoBehaviour
	{


		private SpriteRenderer spriteRenderer;		//Store a component reference to the attached SpriteRenderer.


		void Awake ()
		{
			//Get a component reference to the SpriteRenderer.
			spriteRenderer = GetComponent<SpriteRenderer> ();
		}


		//DamageWall is called when the player attacks a wall.
		public static void MoveWall ()
		{
			//Call the RandomizeSfx function of SoundManager to play one of two chop sounds.
			//SoundManager.instance.RandomizeSfx (chopSound1, chopSound2);

			//Set spriteRenderer to the damaged wall sprite.
			//spriteRenderer.sprite = dmgSprite;

			//Subtract loss from hit point total.


			//If hit points are less than or equal to zero:
		}
	}
}
