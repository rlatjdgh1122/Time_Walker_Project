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

        private static Camera _mainCam;
    }
}

