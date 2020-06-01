using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JournalPageController : MonoBehaviour {

	public List<JournalPage> pagesInScene = new List<JournalPage>();
	public Journal journal;
	
	private void Awake() {
		JournalBehavior[] all = FindObjectsOfType<JournalBehavior>();

		foreach (var page in all) {
			var journalPage = page.GetJournalPage();
			if (!journalPage.dontRespawn)
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
