using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace INCLOUD.Pages
{
    /// <summary>
    /// MyADOHelper is a static class the wrap all DB methods in the web site
    /// In order to use the methods summit by calling MyADOHealper.<method_name>
    /// </summary>
    public static class MyADOHelper
    {
        // The rrror message, null if there's not error
        public static string errorMessage;
        // The SQL connection string
        public static SqlConnection connection =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Users.mdf;Integrated Security=True");
        // The SQL table
        private const string TABLE_NAME = "Users";

        public static DataSet GetDataSet(string sql)
        // input: receives a sql query
        // output: returns a DS reference to the sql result
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;

            SqlCommand cmd = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(cmd);
            try
            {
                connection.Open();
                adapter.Fill(ds);
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }
            return ds;
        }

        public static int GetDBSize()
        // input: N/A
        // output: returns number of users in DB
        {
            string sql = "SELECT * FROM " + TABLE_NAME;
            return GetDataSet(sql) != null ? GetDataSet(sql).Tables[0].Rows.Count : 0;
        }

        public static bool Exist(string key)
        // input: receives a table key
        // output: returns true if key in DB. Otherwise, returns false
        {
            string sql = "SELECT * FROM " + TABLE_NAME + " WHERE email = '" + key + "'";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Object obj = null;

            try
            {
                connection.Open();
                // Exceute the SQL command via the DB connection and save result reference in obj
                obj = cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }

            return obj != null ? true : false;
        }

        public static bool Authentication(string email, string password)
        // input: receives an id and a password
        // output: returns true if the given id and password appear as an entity in DB. Otherwise, returns false
        {
            string sqlAuth = "SELECT * FROM " + TABLE_NAME + " WHERE (email = '" + email + "') AND (password = '" + password + "')";
            SqlCommand cmd = new SqlCommand(sqlAuth, connection);
            Object obj = null;
            try
            {
                connection.Open();
                obj = cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }

            return obj != null;
        }

        public static void Insert(string email, string username, string firstName, string lastName, string password, int gender, string bdate, string country, char securequest, string secureans)
        // input: receives all relevant values to insert new user in DB
        // output: inserts new entity according to values given in method
        {
            string insert = "INSERT INTO " + TABLE_NAME + " VALUES ('" + email + "', '" + username + "', '" + firstName + "', '" + lastName + "', '" + password + "', '" + gender + "', '" + bdate + "', '" + country + "', '" + securequest + "', '" + secureans + "', '" + false + "')";
            SqlCommand cmd = new SqlCommand(insert, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }
        }

        public static Object Select(string id, string selected)
        // input: receives an id and field
        // output: returns the field of that id
        {
            string sql = "SELECT * FROM " + TABLE_NAME + " WHERE (email = '" + id + "')";
            DataSet ds = GetDataSet(sql);
            DataRow row = ds.Tables[0].Rows[0];
            return row[selected];
        }

        public static bool ShowIsAdmin(string key)
        // input: receives an id
        // output: returns true if the given id appear as an admin. Otherwise, returns false
        {
            string sqlAuth = "SELECT * FROM " + TABLE_NAME + " WHERE (email = '" + key + "') AND (isAdmin = '" + true + "')";
            SqlCommand cmd = new SqlCommand(sqlAuth, connection);
            Object obj = null;
            try
            {
                connection.Open();
                obj = cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }
            return obj != null;
        }

        public static bool IsRightAnswer(string key, string answer)
        // input: receives an id
        // output: returns true if the given id's answer to the security question is correct. Otherwise, returns false
        {
            string sqlAuth = "SELECT * FROM " + TABLE_NAME + " WHERE (email = '" + key + "') AND (secureans = '" + answer + "')";
            SqlCommand cmd = new SqlCommand(sqlAuth, connection);
            Object obj = null;
            try
            {
                connection.Open();
                obj = cmd.ExecuteScalar();
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }
            return obj != null;
        }

        public static void Update(string key, string whatToChange, object value)
        // input: receives a table key and, a field and a value
        // output: updates user's bool field accordingly
        {
            string update = "UPDATE " + TABLE_NAME + " SET " + whatToChange + " = '" + value + "' WHERE email = '" + key + "'";
            SqlCommand cmd = new SqlCommand(update, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }
        }

        public static string TableOfUsers(string email)
        // input: n/a
        // output: returns a string represents table of users
        {
            string sql = "";
            if (email == string.Empty)
                sql = "SELECT * FROM " + TABLE_NAME;
            else
                sql = "SELECT * FROM " + TABLE_NAME + " WHERE email LIKE '%" + email + "%'";
            DataSet ds = GetDataSet(sql);

            string resultStr = "";
            DataRow row;

            // Table logo and title      
            resultStr += "<h1> Table Of Users </h1>";

            // Setting table header
            resultStr += "<table border='0' align='center' class='table' id='usersTable'>";
            resultStr += "<tr><th>Email</th><th>Username</th><th>First Name</th><th>Last Name</th><th>Password</th><th>Gender</th><th>Birthday</th><th>Country</th><th>Security Question</th><th>Answer</th><th>Admin?</th><th>Delete?</th></tr>";

            // Scanning all rows of the 1st table in the DataSet (Tables[0])
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            //foreach (DataRow row in ds.Tables[0].Rows)
            {
                row = ds.Tables[0].Rows[k];
                resultStr += "<tr>";
                resultStr += "<td>" + row["email"] + "</td>";
                resultStr += "<td>" + row["username"] + "</td>";
                resultStr += "<td>" + row["firstname"] + "</td>";
                resultStr += "<td>" + row["lastname"] + "</td>";
                resultStr += "<td>" + row["password"] + "</td>";
                if ((int)row["gender"] == 1)
                    resultStr += "<td>Male</td>";
                else if ((int)row["gender"] == 2)
                    resultStr += "<td>Female</td>";
                else
                    resultStr += "<td>Other</td>";
                resultStr += "<td>" + ChangeDate(row["bdate"].ToString()) + "</td>";
                resultStr += "<td>" + row["country"] + "</td>";
                resultStr += "<td>" + row["securequest"] + " </td>";
                resultStr += "<td>" + row["secureans"] + "</td>";
                string isAdmin = "";
                if ((bool)row["isAdmin"])
                    isAdmin = "checked";
                resultStr += "<td><input type='checkbox' name='" + k + "' value='" + row["email"] + "' " + isAdmin + "><input type='hidden' name='" + k + "' value='@" + row["email"] + "' /></td>";
                resultStr += "<td><input type='checkbox' name='o" + k + "' value='" + row["email"] + "'></td>";
            }
            resultStr += "</table>";
            return resultStr;
        }


        private static string ChangeDate(string bdate)
        // input: receives a date string
        // output: returns the date string without the hour
        {
            return bdate.Remove(bdate.LastIndexOf('/') + 5);
        }

        public static void Delete(string key)
        // input: receives a table key and a new password
        // output: deletes user's field accordingly
        {
            string delete = "DELETE FROM " + TABLE_NAME + " WHERE email = '" + key + "'";
            SqlCommand cmd = new SqlCommand(delete, connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.ToString();
            }
        }
    }
}