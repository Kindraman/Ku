using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data; //lib 1 BD
using System.IO; //lib 2 BD
using Mono.Data.Sqlite; //lib 3 BD
using System; //lib 4 BD (util)

public class SQLCommands : MonoBehaviour {

    string rutaDb;
    string strConexion;
    string DbFileName = "manu.db";
    //string sqlQuery;

    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader dataReader;

    public DbPartidas[] dbPartidas;
    //IData

    //for this instance:
    private string col1 = "id", col2 = "nombrePartida", col3 = "statePlayer", col4 = "fecha";


    void Start()
    {
        abrirDb();
        simple_select("partidas","*"); //(tableToSelect,item)
        // where("Camisas", "*", "marca","=" ,"SwingIt",true,"ASC","cantidad"); //(tableToSelect,item,column,value,isOrdered,orderType,orderCol)
        //insert("Camisas", "(7,'manunu','721EXP',1996)"); //(table,col1,...,col4,values) "(7,'manunu','721EXP',1996)"
        //updateBd("Camisas","7","12", "Manuelin", "900EXP", "25");//string table,string idRow, string val1, string val2, string val3, string val4
        //delete("Camisas", "12");
        cerrarDb();
    }

    private void abrirDb()
    {
        //1)Crear y abrir la conexión.
        rutaDb = Application.dataPath + "/StreamingAssets/" + DbFileName;
        strConexion = "URI=file:" + rutaDb;
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();
    }

    private void simple_select(string table, string item)
    {
        //2)Crear la consulta
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "select " + item + " from " + table;
        dbCommand.CommandText = sqlQuery;
        //string[] row;
        int i = 0;

        //3)Leer la Bd
        dataReader = dbCommand.ExecuteReader();

        string suma = "";
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

            //string resume = id+":"+nombrePartida+":"+statePlayer+":"+fecha;
            //dbPartidas[i] = new DbPartidas(id, nombrePartida, statePlayer, fecha);
            //i++;

            suma += id + "_" + nombrePartida + "_" + statePlayer + "_" + fecha+" -";
        }

    }

    private void where(string table, string item, string col,string comparador, string val, bool isOrdered, string orderType, string orderItem ){
        //2)Crear la consulta
        int n;
        if(!int.TryParse(val, out n)){ //verdadero
            //no es numerica (es string)
            val = "'"+val+"'";
        } 
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "select " + item + " from " + table + " where "+col+" "+comparador+" "+val;
        if(isOrdered){
            sqlQuery += " order by "+orderItem +" "+orderType;
             
        }
        dbCommand.CommandText = sqlQuery;

        //3)Leer la Bd
        dataReader = dbCommand.ExecuteReader();

        while (dataReader.Read())
        { //Mientras esté leyendo la BD

            //id
            int id = dataReader.GetInt32(0); //obtiene el dato tipo int de la casilla nº0 (columna)
            //marca
            string marca = dataReader.GetString(1);
            //color
            string color = dataReader.GetString(2);
            //cantidades
            //int cantidad = dataReader.GetInt32(3);

            Debug.Log(id + "-" + marca + "-" + color);


        }
    }

    private void insert(string table, string values){
        //values ya debe venir asi (val1,val2,val3,val4),.. (....)
        //este es un insert pensado en tablas de 4 columnas. (id,nombrePartida,EXPERIENCIA,fecha)
        //2)Crear la consulta
        dbCommand = dbConnection.CreateCommand();
        //values = "(7,'manunu','721EXP',1996)";
        string sqlQuery = "insert into " + table + "(" + col1 + "," + col2 + "," + col3 + "," + col4+")" +" values " + values;
            
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteScalar();
        Debug.Log("Insert GOOOD");
    }

    private void updateBd(string table,string idRow, string val1, string val2, string val3, string val4)
    {
        //UPDATE table_name
        // SET column1 = value1, column2 = value2...., columnN = valueN
        // WHERE[condition];
        dbCommand = dbConnection.CreateCommand();
        //values = "(7,'manunu','721EXP',1996)";
        string sqlQuery = "update " + table +" set "+col1+" = "+val1+", "+col2+" = '"+val2+"', "+col3+" = '"+val3+"',"+col4+" = "+val4
            + " where "+ col1 +" = "+ idRow;
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteScalar();
        Debug.Log("update GOOOD");
    }

    private void delete(string table,string idRow){
        dbCommand = dbConnection.CreateCommand();
        //values = "(7,'manunu','721EXP',1996)";
        string sqlQuery = "delete from "+table+" where "+col1+" = "+idRow;
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteScalar();
        Debug.Log("delete GOOOD");
    }

    private void cerrarDb(){
        dataReader.Close();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
    }

   

  }
