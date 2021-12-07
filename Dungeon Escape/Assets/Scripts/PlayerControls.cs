// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

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
            ""name"": ""PlayerMovement"",
            ""id"": ""bdbf05ad-4ac9-4193-92bc-37d1f5094db4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""731d36f6-a452-44d4-a9f2-c1e391a0a314"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""19229f82-a34c-41ff-b673-b6a4baff1c1f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""fa5c101d-d7ea-4b92-ab53-536e0e9b800f"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f021c299-6916-4198-8df9-5741ab84d5b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""67000a1b-1ba4-495d-95ea-d14af87007ae"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0d15dec3-ce64-49d7-9ff7-5b6617abf133"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0af5d271-720f-4efa-9d5e-02d3bc125b00"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ecfdcaec-2b63-42c1-a816-e1ac7707ccd3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb8ca7e5-83f3-467f-89bd-30591770bfbe"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerActions"",
            ""id"": ""5fef7e46-2d96-41e0-aeb6-d2a1a5710132"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""482da2ff-67d2-4cca-888d-a16474d26151"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""82524e2b-bb59-475e-9e11-02076f78f4d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""44471ddf-3e01-45dc-83aa-dacda3589cd4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F"",
                    ""type"": ""Button"",
                    ""id"": ""6b421ace-fd63-4b78-833d-65184c113a4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0a2eac34-dcde-4cbd-9514-058e9c391280"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""135eacde-938f-44ed-baaa-4cc73388edf4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e85924d3-ce29-4689-a774-5870bc31c346"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a7c5216-3b21-4c24-9c70-f0e74b7b7deb"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f63f61da-f9ef-44ab-aa15-3c98e3a6067b"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55a9f57a-75ca-4399-afb5-4c21149fb945"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21b7ecf1-c7b7-4dd9-b7c7-a545115877f6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b8fd606-c9de-422d-a1b7-bbb78b2e5c77"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""594b363f-9ff4-4ce1-b171-36a32fdcc22b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7aec16fc-9761-4f74-ac4b-d5d4b8782b0e"",
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
                    ""id"": ""7a9ef8d8-acf8-4d09-92fa-e7ec338bad94"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerInventory"",
            ""id"": ""5529c920-9adb-440a-ae99-5408c9e47c95"",
            ""actions"": [
                {
                    ""name"": ""UpArrow"",
                    ""type"": ""Button"",
                    ""id"": ""82f9d881-acd1-4ddf-891f-780bf902dd98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownArrow"",
                    ""type"": ""Button"",
                    ""id"": ""cf3b0d0f-e09b-48a7-8c50-39114e09e236"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftArrow"",
                    ""type"": ""Button"",
                    ""id"": ""b2042e00-1f04-465f-a27f-b3ad3b6e531e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightArrow"",
                    ""type"": ""Button"",
                    ""id"": ""055fb00c-041a-4a0a-af06-35a5e46bec30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""823c37e9-d82b-4365-bb4a-464e082cb201"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed32958e-b38b-494c-9e5c-6fdeccc88155"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dcb659b-243a-4053-8574-8e1115d94731"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a211b85-bf89-4441-9fa2-b8c46aec9fda"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        m_PlayerActions_Roll = m_PlayerActions.FindAction("Roll", throwIfNotFound: true);
        m_PlayerActions_RB = m_PlayerActions.FindAction("RB", throwIfNotFound: true);
        m_PlayerActions_RT = m_PlayerActions.FindAction("RT", throwIfNotFound: true);
        m_PlayerActions_F = m_PlayerActions.FindAction("F", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActions_Inventory = m_PlayerActions.FindAction("Inventory", throwIfNotFound: true);
        // PlayerInventory
        m_PlayerInventory = asset.FindActionMap("PlayerInventory", throwIfNotFound: true);
        m_PlayerInventory_UpArrow = m_PlayerInventory.FindAction("UpArrow", throwIfNotFound: true);
        m_PlayerInventory_DownArrow = m_PlayerInventory.FindAction("DownArrow", throwIfNotFound: true);
        m_PlayerInventory_LeftArrow = m_PlayerInventory.FindAction("LeftArrow", throwIfNotFound: true);
        m_PlayerInventory_RightArrow = m_PlayerInventory.FindAction("RightArrow", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Roll;
    private readonly InputAction m_PlayerActions_RB;
    private readonly InputAction m_PlayerActions_RT;
    private readonly InputAction m_PlayerActions_F;
    private readonly InputAction m_PlayerActions_Jump;
    private readonly InputAction m_PlayerActions_Inventory;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_PlayerActions_Roll;
        public InputAction @RB => m_Wrapper.m_PlayerActions_RB;
        public InputAction @RT => m_Wrapper.m_PlayerActions_RT;
        public InputAction @F => m_Wrapper.m_PlayerActions_F;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputAction @Inventory => m_Wrapper.m_PlayerActions_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @RB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @F.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnF;
                @F.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnF;
                @F.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnF;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Inventory.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @F.started += instance.OnF;
                @F.performed += instance.OnF;
                @F.canceled += instance.OnF;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // PlayerInventory
    private readonly InputActionMap m_PlayerInventory;
    private IPlayerInventoryActions m_PlayerInventoryActionsCallbackInterface;
    private readonly InputAction m_PlayerInventory_UpArrow;
    private readonly InputAction m_PlayerInventory_DownArrow;
    private readonly InputAction m_PlayerInventory_LeftArrow;
    private readonly InputAction m_PlayerInventory_RightArrow;
    public struct PlayerInventoryActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerInventoryActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpArrow => m_Wrapper.m_PlayerInventory_UpArrow;
        public InputAction @DownArrow => m_Wrapper.m_PlayerInventory_DownArrow;
        public InputAction @LeftArrow => m_Wrapper.m_PlayerInventory_LeftArrow;
        public InputAction @RightArrow => m_Wrapper.m_PlayerInventory_RightArrow;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInventoryActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInventoryActions instance)
        {
            if (m_Wrapper.m_PlayerInventoryActionsCallbackInterface != null)
            {
                @UpArrow.started -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnUpArrow;
                @UpArrow.performed -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnUpArrow;
                @UpArrow.canceled -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnUpArrow;
                @DownArrow.started -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnDownArrow;
                @DownArrow.performed -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnDownArrow;
                @DownArrow.canceled -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnDownArrow;
                @LeftArrow.started -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.performed -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.canceled -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnLeftArrow;
                @RightArrow.started -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnRightArrow;
                @RightArrow.performed -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnRightArrow;
                @RightArrow.canceled -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnRightArrow;
            }
            m_Wrapper.m_PlayerInventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpArrow.started += instance.OnUpArrow;
                @UpArrow.performed += instance.OnUpArrow;
                @UpArrow.canceled += instance.OnUpArrow;
                @DownArrow.started += instance.OnDownArrow;
                @DownArrow.performed += instance.OnDownArrow;
                @DownArrow.canceled += instance.OnDownArrow;
                @LeftArrow.started += instance.OnLeftArrow;
                @LeftArrow.performed += instance.OnLeftArrow;
                @LeftArrow.canceled += instance.OnLeftArrow;
                @RightArrow.started += instance.OnRightArrow;
                @RightArrow.performed += instance.OnRightArrow;
                @RightArrow.canceled += instance.OnRightArrow;
            }
        }
    }
    public PlayerInventoryActions @PlayerInventory => new PlayerInventoryActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnF(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
    public interface IPlayerInventoryActions
    {
        void OnUpArrow(InputAction.CallbackContext context);
        void OnDownArrow(InputAction.CallbackContext context);
        void OnLeftArrow(InputAction.CallbackContext context);
        void OnRightArrow(InputAction.CallbackContext context);
    }
}
