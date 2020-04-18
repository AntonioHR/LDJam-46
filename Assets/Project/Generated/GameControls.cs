// GENERATED AUTOMATICALLY FROM 'Assets/Project/Input/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Ingame"",
            ""id"": ""31f1c03f-860c-43ef-b01c-06a2ddb98661"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""7afb9b9b-4a7d-4f82-af8c-18757fb5d1a7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fe904fc6-dfc3-4107-966c-1393e2075be1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e9d8576f-89c5-4f88-bc45-6cdd482d17f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""b052d9e4-5510-4f58-ab05-b37a6030cc55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SuperFire"",
                    ""type"": ""Button"",
                    ""id"": ""7339c5a8-51b9-49b7-ae63-422ee3f588b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc1252f4-df6c-49f9-91a3-71a6980226d9"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""89d52e9e-9b63-4786-a372-6e795740ea2c"",
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
                    ""id"": ""7b7970f0-0bde-4c4c-b6bf-dd87c1a17054"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2240f048-a66e-4f41-856d-be81262c0cba"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8d6e9477-fef9-4020-9fd7-d5cdc0283013"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0663de05-63e8-4d74-8248-e2fd15c76a8b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6ce67f9e-dfa7-4b84-8884-6307eea4506f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02fea5a1-b6c9-4765-9f9e-8c3d96af07c5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6b7d8a1-4d2a-4362-ae99-eb1ad10b1937"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SuperFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ingame
        m_Ingame = asset.FindActionMap("Ingame", throwIfNotFound: true);
        m_Ingame_Aim = m_Ingame.FindAction("Aim", throwIfNotFound: true);
        m_Ingame_Move = m_Ingame.FindAction("Move", throwIfNotFound: true);
        m_Ingame_Jump = m_Ingame.FindAction("Jump", throwIfNotFound: true);
        m_Ingame_Fire = m_Ingame.FindAction("Fire", throwIfNotFound: true);
        m_Ingame_SuperFire = m_Ingame.FindAction("SuperFire", throwIfNotFound: true);
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

    // Ingame
    private readonly InputActionMap m_Ingame;
    private IIngameActions m_IngameActionsCallbackInterface;
    private readonly InputAction m_Ingame_Aim;
    private readonly InputAction m_Ingame_Move;
    private readonly InputAction m_Ingame_Jump;
    private readonly InputAction m_Ingame_Fire;
    private readonly InputAction m_Ingame_SuperFire;
    public struct IngameActions
    {
        private @GameControls m_Wrapper;
        public IngameActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Ingame_Aim;
        public InputAction @Move => m_Wrapper.m_Ingame_Move;
        public InputAction @Jump => m_Wrapper.m_Ingame_Jump;
        public InputAction @Fire => m_Wrapper.m_Ingame_Fire;
        public InputAction @SuperFire => m_Wrapper.m_Ingame_SuperFire;
        public InputActionMap Get() { return m_Wrapper.m_Ingame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(IngameActions set) { return set.Get(); }
        public void SetCallbacks(IIngameActions instance)
        {
            if (m_Wrapper.m_IngameActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnAim;
                @Move.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnFire;
                @SuperFire.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnSuperFire;
                @SuperFire.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnSuperFire;
                @SuperFire.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnSuperFire;
            }
            m_Wrapper.m_IngameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @SuperFire.started += instance.OnSuperFire;
                @SuperFire.performed += instance.OnSuperFire;
                @SuperFire.canceled += instance.OnSuperFire;
            }
        }
    }
    public IngameActions @Ingame => new IngameActions(this);
    public interface IIngameActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSuperFire(InputAction.CallbackContext context);
    }
}
