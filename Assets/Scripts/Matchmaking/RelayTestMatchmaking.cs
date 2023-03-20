using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using System.Threading.Tasks;
using TMPro;


public class RelayTestMatchmaking : MonoBehaviour
{
    [SerializeField] private TMP_Text joinCodeText;
    [SerializeField] private TMP_InputField joinInput;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject setButton;
    [SerializeField] private GameObject modelTarget;

    private UnityTransport transport;
    private const int mxplayer = 5;


    private async void Awake()
	{
        transport = FindObjectOfType<UnityTransport>();

        buttons.SetActive(false);

        await Authenticate();

        buttons.SetActive(true);
	}

    private static async Task Authenticate()
	{
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
	}

    public async void CreateHost()
	{
        buttons.SetActive(false);
        joinInput.gameObject.SetActive(false);

        Allocation a = await RelayService.Instance.CreateAllocationAsync(mxplayer);
        joinCodeText.text = await RelayService.Instance.GetJoinCodeAsync(a.AllocationId);

        transport.SetHostRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData);

        NetworkManager.Singleton.StartHost();

        SceneController.Instance.Cameras();
    }

    public async void JoinToHost()
	{
        buttons.SetActive(false);
        setButton.SetActive(false);
        joinCodeText.gameObject.SetActive(false);
        joinInput.gameObject.SetActive(false);

        JoinAllocation a = await RelayService.Instance.JoinAllocationAsync(joinInput.text);

        transport.SetClientRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key,a.ConnectionData, a.HostConnectionData);

        NetworkManager.Singleton.StartClient();

        modelTarget.gameObject.SetActive(true);
    }

    public void ExitTheApp()
    {
        NetworkManager.Singleton.Shutdown();

        Application.Quit();
    }
}
