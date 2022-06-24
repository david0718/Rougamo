﻿using BasicUsage.Attributes;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BasicUsage
{
    public class Issue8
    {
        [Log]
        public async Task Command()
        {
            await Task.Delay(500);
            throw new Exception("1231232");
        }

        [Log]
        public async void Command1()
        {
            await Task.Delay(500);
            throw new Exception("1231232");
        }

        [Log]
        public void Command2()
        {
            throw new Exception("1231232");
        }
    }
}
