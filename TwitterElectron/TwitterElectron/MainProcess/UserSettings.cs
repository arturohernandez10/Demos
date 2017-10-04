﻿using System;
using System.Text;
using Bridge;
using Newtonsoft.Json;
using TwitterElectron.RendererProcess;

namespace TwitterElectron.MainProcess
{
    [ObjectLiteral]
    [Reflectable(true)]
    public class UserSettings
    {
        public TwitterCredentials Credentials { get; set; }

        public string Serialize()
        {
            var data = JsonConvert.SerializeObject(this);
            var dataArr = Encoding.Default.GetBytes(data);
            var obfuscatedData = Convert.ToBase64String(dataArr);

            return obfuscatedData;
        }

        public static UserSettings Deserialize(string data)
        {
            var deobfuscatedDataArr = Convert.FromBase64String(data);
            var serializedData = Encoding.Default.GetString(deobfuscatedDataArr);
            var obj = JsonConvert.DeserializeObject<UserSettings>(serializedData);
            return obj;
        }
    }
}