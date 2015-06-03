﻿using UnityEngine;
using System.Collections;

public class flamethrowerDamage : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
	}
}
