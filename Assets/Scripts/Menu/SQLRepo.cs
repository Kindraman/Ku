using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data; //lib 1 BD
using System.IO; //lib 2 BD
using Mono.Data.Sqlite; //lib 3 BD
using System; //lib 4 BD (util)

public class SQLRepo : GenericRepo {

    public dataManagerPartidaUI dataManagerPartidaUI;

    private IDbConnection dbConnection;
    private IDbCommand dbCommand;
    private IDataReader dataReader;

    string rutaDb;
    string strConexion;
    string DbFileName = "manu2.db";
    private string table = "partidas";
    private string col1 = "id", col2 = "nombrePartida", col3 = "statePlayer", col4 = "fecha";
    private string values = "";



   

    public override void load(){
        rutaDb = Application.dataPath + "/StreamingAssets/" + DbFileName;
        strConexion = "URI=file:" + rutaDb;
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();

        Debug.Log("FlagL1");
        loadHelper("*");
        Debug.Log("FlagL2");
        dataManagerPartidaUI.loadHelper(); //dataManagerPartidaUI
        Debug.Log("FlagL3");

        //Cerrando DB...
        dataReader.Close();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;


    }


    public override void save()
    {

        //Se Crea y abre la conexión con la BD.
        rutaDb = Application.dataPath + "/StreamingAssets/" + DbFileName;
        strConexion = "URI=file:" + rutaDb;
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();

        Debug.Log("Flag1");

        //Obteniendo valores de la partida actual (DbPartidas).
        DbPartidas dbp = GameObject.FindWithTag("loadedData").GetComponent<DbPartidas>();
        this.values = "('" + dbp.nombrePartida + "','" + dbp.playerState + "','" + dbp.fecha + "')";

        Debug.Log("Flag2");
        //Guardando datos..
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "insert into " + table + " (" + col2 + "," + col3 + "," + col4 + ")" + " values " + this.values;
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteScalar();

        Debug.Log("Flag3");
        //Cerrando DB...
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
        Debug.Log("Saved");
    }

    protected void loadHelper(string item)
    {
        //2)Crear la consulta
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "select " + item + " from " + table;
        dbCommand.CommandText = sqlQuery;
        //string[] row;
        int i = 0;

        //3)Leer la Bd
        dataReader = dbCommand.ExecuteReader();

        //string suma = "";
        while (dataReader.Read())
        { //Mientras esté leyendo la BD

            //id
            int id = dataReader.GetInt32(0); //obtiene el dato tipo int de la casilla nº0 (columna)
            //marca
            string nombrePartida = dataReader.GetString(1);
            //color
            string statePlayer = dataReader.GetString(2);
            //cantidades
            string fecha = dataReader.GetString(3);

            //var dbp = new DbPartidas(id, nombrePartida, statePlayer, fecha);
            DbPartidas dbp = dataManagerPartidaUI.partidasBox[i].GetComponent<DbPartidas>();
            dbp.construct(id, nombrePartida, statePlayer, fecha);
            dbp.ready = true;
            if (i < 2)
            {
                Debug.Log(i);
                i++;

            }

        }
    }

}
