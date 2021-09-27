using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Delay : MonoBehaviour
{

	private SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine("RunFadeOut");
	}

	void Update()
	{

	}

	IEnumerator RunFadeOut()
	{
		Color color = spriteRenderer.color;
		while (color.a > 0.0f)
		{
			color.a -= 0.1f;
			spriteRenderer.color = color;
			yield return new WaitForSeconds(0.1f);
		}
	}

}



