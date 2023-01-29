// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""65a49e4d-5227-4fa2-9925-a29bea670599"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ea84a3d-5ca9-4686-91c2-424dc1da92ba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""741e4bc0-86d5-4a4f-9481-916a2bcdbcb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NewResolution"",
                    ""type"": ""Button"",
                    ""id"": ""f60bf925-0fdd-4e22-ac8d-033e071b1502"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58d9b65a-6f6d-4b33-b630-06994df49977"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f18edbb-fb39-404f-b38b-c95d66d44cf9"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27e31a02-84e8-41bd-9480-a5efb8a370f7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NewResolution"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Position = m_Player.FindAction("Position", throwIfNotFound: true);
        m_Player_Touch = m_Player.FindAction("Touch", throwIfNotFound: true);
        m_Player_NewResolution = m_Player.FindAction("NewResolution", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Position;
    private readonly InputAction m_Player_Touch;
    private readonly InputAction m_Player_NewResolution;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_Player_Position;
        public InputAction @Touch => m_Wrapper.m_Player_Touch;
        public InputAction @NewResolution => m_Wrapper.m_Player_NewResolution;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPosition;
                @Touch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
                @NewResolution.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewResolution;
                @NewResolution.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewResolution;
                @NewResolution.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewResolution;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @NewResolution.started += instance.OnNewResolution;
                @NewResolution.performed += instance.OnNewResolution;
                @NewResolution.canceled += instance.OnNewResolution;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
        void OnNewResolution(InputAction.CallbackContext context);
    }
}
