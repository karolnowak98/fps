using UnityEngine;
using Zenject;
using TMPro;
using FPS.Core.UI;
using FPS.Game.Input.Logic;

namespace FPS.Game.Input.UI
{
    public class ControlsPanel : Panel
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private TextMeshProUGUI _moveTmp;
        [SerializeField] private TextMeshProUGUI _jumpTmp;
        [SerializeField] private TextMeshProUGUI _shootTmp;
        [SerializeField] private TextMeshProUGUI _reloadTmp;
        [SerializeField] private TextMeshProUGUI _changeWeapon;

        private InputManager _inputManager;

        [Inject]
        private void Construct(InputManager inputManager)
        {
            _inputManager = inputManager;
            _inputManager.OnPPressed += TogglePanel;
        }
        
        private void Start()
        {
            UpdateControlsPanel();
        }
        
        private void TogglePanel()
        {
            _panel.SetActive(!_panel.activeSelf);
        }

        private void UpdateControlsPanel()
        {
            _moveTmp.text = "Move: WASD and Arrows";
            _jumpTmp.text = "Jump: Space";
            _shootTmp.text = "Shoot: LMB";
            _reloadTmp.text = "Reload: R";
            _changeWeapon.text = "Change weapons: Scroll and slot number (1, 2, 3)";
        }
    }
}