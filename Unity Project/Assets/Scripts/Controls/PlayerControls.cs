// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""player_controls"",
            ""id"": ""c0a676a8-bac4-4654-b896-a878ac4429ab"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""fee02ede-8ef7-4000-9680-815ff8661ab5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8b4973f-2157-4b66-a34e-8c41b6a4e1d2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": []
        }
    ]
}");
        // player_controls
        m_player_controls = asset.FindActionMap("player_controls", throwIfNotFound: true);
        m_player_controls_Look = m_player_controls.FindAction("Look", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // player_controls
    private readonly InputActionMap m_player_controls;
    private IPlayer_controlsActions m_Player_controlsActionsCallbackInterface;
    private readonly InputAction m_player_controls_Look;
    public struct Player_controlsActions
    {
        private @PlayerControls m_Wrapper;
        public Player_controlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_player_controls_Look;
        public InputActionMap Get() { return m_Wrapper.m_player_controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_controlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_controlsActions instance)
        {
            if (m_Wrapper.m_Player_controlsActionsCallbackInterface != null)
            {
                @Look.started -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_Player_controlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public Player_controlsActions @player_controls => new Player_controlsActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IPlayer_controlsActions
    {
        void OnLook(InputAction.CallbackContext context);
    }
}
