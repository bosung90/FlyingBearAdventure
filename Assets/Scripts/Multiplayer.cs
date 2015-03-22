using UnityEngine;
using System.Collections;

public class Multiplayer : MonoBehaviour {

	public GameObject PlayerPrefab;
	public GameObject EnemyPrefab;
	public GameObject CardboardCamera;
	public GameObject ClientCamera;

	private const string typeName = "PrisonEscape";
	private const string gameName = "EscapeRoom1";
	private const int roomSize = 2;
	private const int port = 16876;

	private bool isServerStarted = false;

	private GameObject networkPlayer;

	//============================SERVER SIDE ===================================
	private void StartServer()
	{
		if(!isServerStarted)
		{
			Network.InitializeServer(roomSize, port, !Network.HavePublicAddress());
			MasterServer.RegisterHost(typeName, gameName);
			isServerStarted = true;
		}
	}

	void OnServerInitialized()
	{
		ClientCamera.SetActive (false);
		Debug.Log(string.Format("Server Initializied with GameName: {0} on port: {1}", typeName, port));
		//Spawn player and enemy upon server initialization.
		GameObject playerGenerated = Network.Instantiate(PlayerPrefab, PlayerPrefab.transform.position, Quaternion.identity, 0) as GameObject;
//		foreach (Transform child in playerGenerated.transform)     
//		{  
//			child.gameObject.SetActiveRecursively(false);   
//		} 

		CardboardCamera.transform.position = playerGenerated.transform.position + Vector3.up;
		CardboardCamera.transform.parent = playerGenerated.transform;

		Network.Instantiate(EnemyPrefab, EnemyPrefab.transform.position, Quaternion.identity, 0);
	}
	//====================================================================================

//	void OnGUI()
//	{
//		if (!Network.isClient && !Network.isServer)
//		{
//			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
//				StartServer();
//			
//			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
//				RefreshHostList();
//			
//			if (hostList != null)
//			{
//				for (int i = 0; i < hostList.Length; i++)
//				{
//					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
//						JoinServer(hostList[i]);
//				}
//			}
//		}
//	}

	//============================ CLIENT SIDE ===================================
	private HostData[] hostList;
	
	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();

		if(hostList != null  && hostList.Length >0)
		{
			JoinServer(hostList[0]);
		}
		else
		{
			StartServer();
		}
	}

	private void JoinServer(HostData hostData)
	{
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
		CardboardCamera.SetActive (false);
	}
	//==============================================================================

	// Use this for initialization
	void Start () {
		RefreshHostList ();
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
