using System.Collections;
using System.Collections.Generic;
using System.Data; //lib 1 BD
using System.IO; //lib 2 BD
using Mono.Data.Sqlite; //lib 3 BD
using System; //lib 4 BD (util)
using UnityEngine;

public class ConexDB : MonoBehaviour {

    string rutaDb;
    string strConexion;
    string DbFileName = "RopaMarianoDB.sqlite";
    
    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader dataReader;

	
	void Start () {
        abrirDb();
	}

    private void abrirDb(){
        //1)Crear y abrir la conexión.
        rutaDb = Application.dataPath + "/StreamingAssets/" + DbFileName;
        strConexion = "URI=file:" + rutaDb;
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();

        //2)Crear la consulta
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "select * from Camisas";
        dbCommand.CommandText = sqlQuery;

        //3)Leer la Bd
        dataReader = dbCommand.ExecuteReader();

        while(dataReader.Read()){ //Mientras esté leyendo la BD

            //id
            int id = dataReader.GetInt32(0); //obtiene el dato tipo int de la casilla nº0 (columna)
            //marca
            string marca = dataReader.GetString(1);
            //color
            string color = dataReader.GetString(2);
            //cantidades
            int cantidad = dataReader.GetInt32(3);

            Debug.Log(id + "-" + marca + "-" + color + "-" + cantidad);


        }

        dataReader.Close();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }
	
}
