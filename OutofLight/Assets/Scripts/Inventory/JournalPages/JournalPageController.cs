using System.Collections.Generic;
using System.Linq;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class JournalPageController : MonoBehaviour {

	public List<JournalPage> pagesInScene = new List<JournalPage>();
	public Journal journal;
	
	private void Start() {
		JournalBehavior[] all = FindObjectsOfType<JournalBehavior>();
		if(all.Length < 1)
			Destroy(gameObject);
		
		foreach (var page in all) {
			var journalPage = page.GetJournalPage();
			if (!journalPage.dontRespawn && !journal.Contains(journalPage))
				pagesInScene.Add(journalPage);
		}
	}

	public void SetPageRespawn(bool dontRespawn) {
		foreach (var page in pagesInScene.Where(page => journal.Contains(page))) {
			page.dontRespawn = dontRespawn;
		}
	}
	
	public void ResetJournalPage() {
		foreach (var page in pagesInScene) {
			SetPageRespawn(false);
			journal.Remove(page);
		}
	}
}
