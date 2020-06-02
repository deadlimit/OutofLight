using UnityEngine;

public class IndependentTorch : InteractableTorch {

	public bool on;
	public Light light;
	public GameEvent LightTorch, PutOutTorch;
	public override void Use() {
		var targetValue = on ? 0 : 1000;

		if (on)
			LightTorch.Raise();
		else {
			PutOutTorch.Raise();
		}
		on = !on;

		light.intensity = on ? 2 : 0;
		
		
		for (int i = 0; i < 5; i++) {
			StartCoroutine(ChangeLight(targetValue, i));
		}
	}
	
	public override string GetPrompt() {
		return on ? "Put out torch" : "Light torch";
	}
}
