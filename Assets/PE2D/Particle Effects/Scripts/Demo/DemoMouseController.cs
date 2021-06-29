﻿using UnityEngine;
using System.Collections;
using PE2D;

/// <summary>
/// Spawns a circular explosion of particles on mouse click. Example of how to procedurally create particles.
/// </summary>
public class DemoMouseController : MonoBehaviour
{
	[Header("Options")]
	public float speedOffset = .006f;
	public float lengthMultiplier = 40f;
	public int numToSpawn = 200;
	public WrapAroundType wrapAround;

	[Header("Color")]
	public bool useCustomColor;
	public Gradient effectColor;
	
	[Range(0, 1f)]
	public float colorTimer = .5f;

	[Header("Test")]
	public bool useToTest = false;

	private void Update ()
	{
		if (useToTest && Input.GetMouseButtonUp (0)) 
		{
			SpawnExplosion (Camera.main.ScreenToWorldPoint (Input.mousePosition));
		}
	}

	public void SpawnExplosion ()
	{
		SpawnExplosion(gameObject.transform.position);
	}

	private void SpawnExplosion (Vector2 position)
	{
		float hue1 = Random.Range (0, 6);
		float hue2 = (hue1 + Random.Range (0, 2)) % 6f;
		Color colour1 = StaticExtensions.Color.FromHSV (hue1, 0.5f, 1);
		Color colour2 = StaticExtensions.Color.FromHSV (hue2, 0.5f, 1);
		
		for (int i = 0; i < numToSpawn; i++) 
		{
			float speed = (18f * (1f - 1 / Random.Range (6f, 10f))) * speedOffset;
			
			var state = new ParticleBuilder ()
			{
				velocity = StaticExtensions.Random.RandomVector2(speed, speed), 
				wrapAroundType = wrapAround,
				lengthMultiplier = lengthMultiplier,
				velocityDampModifier = 0.94f,
				removeWhenAlphaReachesThreshold = true
			};
			
			Color colour;

			if (useCustomColor)
				colour = effectColor.Evaluate(colorTimer);
			else colour = Color.Lerp (colour1, colour2, Random.Range (0, 1));

			float duration = 320f;
			var initialScale = new Vector2 (2f, 1f);

			ParticleFactory.instance.CreateParticle (position, colour, duration, initialScale, state);
		}
	}
}
