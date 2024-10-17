using MySql.Data;
using MySql.Data.MySqlClient;

namespace BookSales;

public class ClassConnection{
  public static MySqlConnection mySqlConnection;
  public static string strCon = "Host=localhost; Database=BookSales; uid=root; pwd=123456";
  
  public static void Open(){
    try{
      mySqlConnection = new MySqlConnection(strCon);
      mySqlConnection.Open();
      System.Console.WriteLine("Connect successfully");
    }catch(Exception ex){
      System.Console.WriteLine(ex.Message);
    }
  }

  public static void Close(){
    mySqlConnection.Close();
  }
}