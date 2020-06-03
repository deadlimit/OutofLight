using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCheatScript : MonoBehaviour {

	public Journal journal;
	public BoolVariable one, two, three;

	public void Awake() {
		for (int i = 0; i < 3; i++) {
			if (journal.journal[i] == null)
				break;
			one.ChangeValue(true);
			two.ChangeValue(true);
			three.ChangeValue(true);
		}
	}


}
