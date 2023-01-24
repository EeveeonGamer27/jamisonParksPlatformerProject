//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Controller/Controllers.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controllers : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controllers()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controllers"",
    ""maps"": [
        {
            ""name"": ""Test"",
            ""id"": ""6c116c22-c852-4aee-9a9f-fd677a77ef80"",
            ""actions"": [
                {
                    ""name"": ""Pressing"",
                    ""type"": ""Button"",
                    ""id"": ""cc9e7c00-3acd-4de8-a034-de43e8f946cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sticking"",
                    ""type"": ""Value"",
                    ""id"": ""9f6e8500-cd4c-44b0-bdfe-23d6e1da7d88"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""63e66816-60b7-407a-bd8b-afb37fc28b54"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pressing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c00491ee-a260-4cf7-b90f-4910d9b9afba"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sticking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_Pressing = m_Test.FindAction("Pressing", throwIfNotFound: true);
        m_Test_Sticking = m_Test.FindAction("Sticking", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_Pressing;
    private readonly InputAction m_Test_Sticking;
    public struct TestActions
    {
        private @Controllers m_Wrapper;
        public TestActions(@Controllers wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pressing => m_Wrapper.m_Test_Pressing;
        public InputAction @Sticking => m_Wrapper.m_Test_Sticking;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @Pressing.started -= m_Wrapper.m_TestActionsCallbackInterface.OnPressing;
                @Pressing.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnPressing;
                @Pressing.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnPressing;
                @Sticking.started -= m_Wrapper.m_TestActionsCallbackInterface.OnSticking;
                @Sticking.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnSticking;
                @Sticking.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnSticking;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pressing.started += instance.OnPressing;
                @Pressing.performed += instance.OnPressing;
                @Pressing.canceled += instance.OnPressing;
                @Sticking.started += instance.OnSticking;
                @Sticking.performed += instance.OnSticking;
                @Sticking.canceled += instance.OnSticking;
            }
        }
    }
    public TestActions @Test => new TestActions(this);
    public interface ITestActions
    {
        void OnPressing(InputAction.CallbackContext context);
        void OnSticking(InputAction.CallbackContext context);
    }
}
