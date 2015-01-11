using UnityEngine;
using System.Collections;

public class MachineGun : Gun
{
	public GameObject defaultHitEffect;

	void Update()
	{
		if(Input.GetButton(fireButton) && _currentAmmo > 0 && _canFire)
		{
			Fire();
		}
	}

	protected override void Fire()
	{
		base.Fire();

		//Fire logic
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.forward,out hit))
		{
			hit.collider.SendMessage("Damage",damage,SendMessageOptions.DontRequireReceiver);

			HitEffect hitEffect = hit.collider.GetComponentInChildren<HitEffect>();

			if(hitEffect != null)
			{
				Instantiate(hitEffect.hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
			}
			else
			{
				Instantiate(defaultHitEffect,hit.point,Quaternion.LookRotation(hit.normal));
			}
		}
	}
}
