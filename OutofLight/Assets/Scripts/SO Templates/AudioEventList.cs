﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioEventList : ScriptableObject
{
    public List<GameEvent> events = new List<GameEvent>();
    public AudioClip assosiatedSound;
	public bool ContainsEvent(GameEvent audioEvent)
	{
		return events.Contains(audioEvent);
	}
}
