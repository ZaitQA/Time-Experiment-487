using System.Collections;

using UnityEngine;

/*public class Sync : Photon.MonoBehaviour
{

	private Vector3 networkPosition;
	private Quaternion networkRotation;
	private PhotonView photonView;
	
	void Start ()
	{
		photonView = GetComponent<PhotonView>();
	}
	
	void Update () 
	{
		if (!photonView.isMine)
		{
			transform.position = Vector3.MoveTowards(transform.position, this.networkPosition, 200f);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, this.networkRotation, 200f);
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
}*/

public class Sync : Photon.MonoBehaviour
{
	public Vector3 realPosition = Vector3.zero;
	public Vector3 positionAtLastPacket = Vector3.zero;
	public double currentTime = 0.0;
	public double currentPacketTime = 0.0;
	public double lastPacketTime = 0.0;
	public double timeToReachGoal = 0.0;
     
	void Update ()
	{
		if (!photonView.isMine)
		{
			timeToReachGoal = currentPacketTime - lastPacketTime;
			currentTime += Time.deltaTime;
			transform.position = Vector3.Lerp(positionAtLastPacket, realPosition, (float)(currentTime / timeToReachGoal));
		}
	}
 
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext((Vector3)transform.position);
		}
		else
		{
			currentTime = 0.0;
			positionAtLastPacket = transform.position;
			realPosition = (Vector3)stream.ReceiveNext();
			lastPacketTime = currentPacketTime;
			currentPacketTime = info.timestamp;
		}
	}
}
