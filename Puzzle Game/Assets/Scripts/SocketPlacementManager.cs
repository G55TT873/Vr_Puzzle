using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketPlacementManager : MonoBehaviour
{
    [Header("Socket Interactors")]
    public XRSocketInteractor socket1;
    public XRSocketInteractor socket2;
    public XRSocketInteractor socket3;

    [Header("UI Panel to Show")]
    public GameObject uiPanel;

    private bool socket1Filled = false;
    private bool socket2Filled = false;
    private bool socket3Filled = false;

    private void Start()
    {
        if (uiPanel != null)
            uiPanel.SetActive(false);

        // Subscribe using correct event signature
        socket1.selectEntered.AddListener(OnSocket1Entered);
        socket1.selectExited.AddListener(OnSocket1Exited);

        socket2.selectEntered.AddListener(OnSocket2Entered);
        socket2.selectExited.AddListener(OnSocket2Exited);

        socket3.selectEntered.AddListener(OnSocket3Entered);
        socket3.selectExited.AddListener(OnSocket3Exited);
    }

    // Correct method signatures to match UnityAction<SelectEnterEventArgs>
    private void OnSocket1Entered(SelectEnterEventArgs args)
    {
        socket1Filled = true;
        CheckAllSocketsFilled();
    }

    private void OnSocket1Exited(SelectExitEventArgs args)
    {
        socket1Filled = false;
        HideUI();
    }

    private void OnSocket2Entered(SelectEnterEventArgs args)
    {
        socket2Filled = true;
        CheckAllSocketsFilled();
    }

    private void OnSocket2Exited(SelectExitEventArgs args)
    {
        socket2Filled = false;
        HideUI();
    }

    private void OnSocket3Entered(SelectEnterEventArgs args)
    {
        socket3Filled = true;
        CheckAllSocketsFilled();
    }

    private void OnSocket3Exited(SelectExitEventArgs args)
    {
        socket3Filled = false;
        HideUI();
    }

    private void CheckAllSocketsFilled()
    {
        if (socket1Filled && socket2Filled && socket3Filled)
        {
            ShowUI();
        }
    }

    private void ShowUI()
    {
        if (uiPanel != null)
            uiPanel.SetActive(true);
    }

    private void HideUI()
    {
        if (uiPanel != null)
            uiPanel.SetActive(false);
    }
}
