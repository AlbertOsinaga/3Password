﻿using System;

namespace _3PwdLibrary
{
    public class Comando
    {
        public Comando()
        {
            Arg = "";
            Cmd = "";
            Ok = false;
        }

        public string Cmd { get; set; }
        public string Arg { get; set; }
        public bool Ok { get; set; }
    }
}
