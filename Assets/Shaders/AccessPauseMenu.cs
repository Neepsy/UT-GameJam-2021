// GENERATED AUTOMATICALLY FROM 'Assets/Shaders/AccessPauseMenu.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @AccessPauseMenu : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @AccessPauseMenu()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AccessPauseMenu"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""45b58ccd-f7ea-45a5-a934-9c5d4a29ef0f"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""8ab05291-eb20-4bf7-a715-c52d13a07a6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7f2555c5-a081-4e09-a8f7-5eea8123c02a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Menu = m_Game.FindAction("Menu", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Menu;
    public struct GameActions
    {
        private @AccessPauseMenu m_Wrapper;
        public GameActions(@AccessPauseMenu wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_Game_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Menu.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnMenu(InputAction.CallbackContext context);
    }
}
