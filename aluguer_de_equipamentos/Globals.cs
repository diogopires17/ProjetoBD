using System;
using System.Collections.Generic;
using Equipamentos;

public static class Globals
{
    private static string dbServer = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
    private static string dbName = "p7g1";
    private static string userName = "p7g1";
    private static string userPass = "-1683641040@BD2024";

    public static string strConn = "Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName + "; uid = " + userName + ";" + "password = " + userPass;
    //public static string strConn2 = "data source= DIOGOPIRES\\SQLEXPRESS;integrated security=true;initial catalog=aluguer_equipamentos";

    private static List<Equipamento> equipamentos = new List<Equipamento>();
}
