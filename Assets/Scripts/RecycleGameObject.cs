using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycle{
	void Restart ();
	void ShutDown ();

}
public class RecycleGameObject : MonoBehaviour {

	private List<IRecycle> recycleComponents;

	void Awake(){
		var conponents = GetComponents<MonoBehaviour> ();
		recycleComponents = new List<IRecycle> ();
		foreach (var component in conponents) {
			if (component is IRecycle) {
				recycleComponents.Add (component as IRecycle);
			}
		
		}
		//Debug.Log (name + "found" + recycleComponents.Count + "components");
	}
	public void Restart () {
		gameObject.SetActive (true);

		foreach (var component in recycleComponents) {
			component.Restart ();
		}
	}
	

	public void ShutDown () {
		gameObject.SetActive (false);
		foreach (var component in recycleComponents) {
			component.ShutDown ();
		}
	}
}
