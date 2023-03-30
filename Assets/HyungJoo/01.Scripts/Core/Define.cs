using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public class Define
    {
        public static Camera MainCam
        {
            get
            {
                if(_mainCam == null)
                {
                    _mainCam = Camera.main;
                }
                return _mainCam;
            }
        }

        private static Camera _mainCam;

    }
}

