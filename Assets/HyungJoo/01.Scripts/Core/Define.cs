using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core{
    public class Define{
        public enum StateType{
            Normal = 0,
            Attack = 1,
        }

        public static Camera MainCam{
            get{
                if(_mainCam == null){
                    _mainCam = Camera.main;
                }
                return _mainCam;
            }
            set{
                _mainCam = value;
            }
        }
        public static LayerMask whatIsEnemy = LayerMask.NameToLayer("ENEMY");
        private static Camera _mainCam;

        private static Transform _player;
        public static Transform Player{
            get{
                if(_player == null){
                    _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                }
                return _player;
            }
        }
        public static PlayerActionData PlayerActionDataCompo{
            get{
                if(_playerActionData == null){
                    _playerActionData = Player.Find("ActionData").GetComponent<PlayerActionData>();
                }
                return _playerActionData;
            }
        }
        private static PlayerActionData _playerActionData;

        
    }
}

