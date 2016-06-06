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
    
    class ConexionSQL
    {
        const string NombreProyecto = "Loreal_Profesional";
        static public string LeerConexion()
        {
            try 
            {
                string StrConexion;
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();

                ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Server"));
                ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBase"));
                ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "User"));
                ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Password"));
                

                StrConexion = "Data Source="+ValServer+";Initial Catalog="+ValDBase+";Persist Security Info=True;User ID="+ValUser+";Password="+ ValPass;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string LeerConexionL()
        {
            try
            {
                string StrConexion;
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Server"));
                ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBase"));
                ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "User"));
                ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Password"));


                StrConexion = "Data Source=" + ValServer + ";Initial Catalog=" + ValDBase + ";Persist Security Info=True;User ID=" + ValUser + ";Password=" + ValPass;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string LeerConexionR()
        {
            try
            {
                string StrConexion;
                string ValServerR;
                string ValDBaseR;
                string ValUserR;
                string ValPassR;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                ValServerR = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "ServerR"));
                ValDBaseR = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBaseR"));
                ValUserR = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "UserR"));
                ValPassR = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "PasswordR"));


                StrConexion = "Data Source=" + ValServerR + ";Initial Catalog=" + ValDBaseR + ";Persist Security Info=True;User ID=" + ValUserR + ";Password=" + ValPassR;
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean ValidaConexion()
        {
            try
            {
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                try
                {
                    ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Server"));
                    ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBase"));
                    ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "User"));
                    ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Password"));
                }
                catch
                {
                    ValServer = string.Empty;
                    ValDBase = string.Empty;
                    ValUser = string.Empty;
                    ValPass = string.Empty;
                }

                if (ValServer != string.Empty && ValDBase != string.Empty && ValUser != string.Empty && ValPass != string.Empty)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection("Data Source=" + ValServer + ";Initial Catalog=" + ValDBase + ";Persist Security Info=True;User ID=" + ValUser + ";Password=" + ValPass);
                        conn.Open();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                { 
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        
    }
}
