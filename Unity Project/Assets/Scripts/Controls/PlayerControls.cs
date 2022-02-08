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
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b39ddea8-7c89-4c93-97fb-8d122d954c83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e571d7c9-2108-4314-aa68-15e45b84aedc"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""bde3f972-b1df-41b0-99d7-1272c4f23131"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6a987b02-bbbd-41d2-8837-8e1105ed9dc3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""75bbdd29-077b-4a76-aea9-8d1baa7b8617"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f047dd07-c516-4d2c-8285-4b69ec2289c2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9ec8c8e2-f1d3-47bf-ad82-93650148a208"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fb8bdd5b-1003-4ba4-92af-fb6d3de108e1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        m_player_controls_Jump = m_player_controls.FindAction("Jump", throwIfNotFound: true);
        m_player_controls_Move = m_player_controls.FindAction("Move", throwIfNotFound: true);
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
    private readonly InputAction m_player_controls_Jump;
    private readonly InputAction m_player_controls_Move;
    public struct Player_controlsActions
    {
        private @PlayerControls m_Wrapper;
        public Player_controlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look => m_Wrapper.m_player_controls_Look;
        public InputAction @Jump => m_Wrapper.m_player_controls_Jump;
        public InputAction @Move => m_Wrapper.m_player_controls_Move;
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
                @Jump.started -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player_controlsActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_Player_controlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
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
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
