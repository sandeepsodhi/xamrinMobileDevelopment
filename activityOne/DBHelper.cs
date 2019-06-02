using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;  // Step: 1 - 0
using Android.Database.Sqlite; // Step: 1 - 1
using Android.Database;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace activityOne
{
    [Activity(Label = "DBHelper")]
    public class DBHelper : SQLiteOpenHelper
    {
        private static string _DatabaseName = "mydatabase.db";
        private const string TableName = "user";
        private const string ColumnID = "id";
        private const string ColumnfName = "fname";
        private const string ColumnlName = "lname";
        private const string ColumnEmail = "emails";
        private const string columnAge = "age";
        private const string columnPassword = "password";
        
        public const string createTable = "create table " +
      TableName + "( " + ColumnID + " INTEGER PRIMARY KEY AUTOINCREMENT,"
          + ColumnfName + " text,"
          + ColumnlName + " TEXT,"
          + ColumnEmail + " TEXT,"
          + columnAge + " INT,"
          + columnPassword + " TEXT);";

        SQLiteDatabase myDBObj; // Step: 1 - 5
        Context myContext; // Step: 1 - 6

        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase; // Step:3 create a DB objects
        }


        public override void OnCreate(SQLiteDatabase db)
        {
            System.Console.WriteLine("---------------\n\n\n\n\ncreate table query is: " + createTable);

            db.ExecSQL(createTable);  //Step: 4

        }

        public void selectMyValues()
        {

            String sqlQuery = "Select * from " + TableName;

            ICursor result = myDBObj.RawQuery(sqlQuery, null);

            while (result.MoveToNext())
            {

                var IDfromDB = result.GetInt(result.GetColumnIndexOrThrow(ColumnID));
                var fNameFromDb  = result.GetString(result.GetColumnIndexOrThrow(ColumnfName));
                var lNameFromDb = result.GetString(result.GetColumnIndexOrThrow(ColumnlName));
                var emailFromDb = result.GetString(result.GetColumnIndexOrThrow(ColumnEmail));
                var ageFromDb = result.GetString(result.GetColumnIndexOrThrow(columnAge));
                var passwordFromDb = result.GetString(result.GetColumnIndexOrThrow(columnPassword));

                System.Console.WriteLine(" Value fROM DB --> " + IDfromDB + "  " + fNameFromDb + "  " + lNameFromDb + "  " + emailFromDb + "  " + ageFromDb + "  " + passwordFromDb);

            }
        }

        public bool validateLogin(string email, string password)
        {
            string loginStmt = "Select " + ColumnEmail + " from " + TableName + " where " +ColumnEmail + "=" + "'" + email + "' and "+ columnPassword + "= '"+  password +"'";

            ICursor result = myDBObj.RawQuery(loginStmt, null);

            if (result.Count > 0)
            {
                System.Console.WriteLine("Email found");
                return true;
            }
            else
            {
                System.Console.WriteLine("Not Email found");
                return false;
            }
        }

        public void insertMyValue(string vfname, string vlname, string vemail, string vage, string vpassword)
        {

            String insertSQL = "insert into " + TableName + "(" + ColumnfName + "," + ColumnlName + "," + ColumnEmail + "," + columnAge + ","  + columnPassword + ") values ('" + vfname + "'" + "," + "'" + vlname + "'," + "'" + vemail + "',"  +  vage  + ",'" + vpassword + "'" +   ");";

            System.Console.WriteLine("Insert SQL " + insertSQL);
            myDBObj.ExecSQL(insertSQL);

        }


        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }
}