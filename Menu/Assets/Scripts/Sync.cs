using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync : Photon.MonoBehaviour
{

	private Vector3 networkPosition;
	private Quaternion networkRotation;
	private PhotonView photonView;
	
	// Use this for initialization
	void Start ()
	{
		photonView = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, networkPosition, Time.fixedDeltaTime * 20);
			transform.rotation = Quaternion.Lerp(transform.rotation, networkRotation, Time.fixedDeltaTime * 20);
		}
	}
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else
		{
			networkPosition = (Vector3) stream.ReceiveNext();
			networkRotation = (Quaternion) stream.ReceiveNext();
		}
	}
}
