using UnityEngine;
using System.Collections;

public class BasicGun : Gun
{
	protected override void Fire()
	{
		base.Fire();

		//Fire logic
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.forward,out hit))
		{
			hit.collider.SendMessage("Damage",damage,SendMessageOptions.DontRequireReceiver);;
		}
	}
}
