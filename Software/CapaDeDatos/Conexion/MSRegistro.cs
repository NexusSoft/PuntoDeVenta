using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace CapaDeDatos
{
    class MSRegistro
    {
        public string GetSetting(string appName, string section, string key, string sDefault)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\" + appName + "\\" + section);
            string s = sDefault;
            if (rk != null) s = (string)rk.GetValue(key);
            return s;
        }
        public string GetSetting(string appName, string section, string key)
        {
            return GetSetting(appName, section, key, "");
        }
        public void SaveSetting(string appName, string section, string key, string setting)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\" + appName + "\\" + section);
            rk.SetValue(key, setting);
        }
    }
}
