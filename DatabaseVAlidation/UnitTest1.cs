﻿using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseVAlidation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           // Console.WriteLine("Hello");
            //string connetionString = null;
            SqlDataReader rdr = null;

            SqlConnection conn = new SqlConnection("Data Source=CGBD014894\\QGBD019003;Initial Catalog=LoadTestUAT;Integrated Security=TRUE");
            SqlCommand cmd = new SqlCommand("select * from LoadTestNetworks", conn);

            try
            {

                // open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                rdr = cmd.ExecuteReader();

                // print a set of column headers
                Console.WriteLine(" LoadTestRunId   NetworkId   NetworkName");
                Console.WriteLine("---------------  ------------  -----_----- ");

                // 2. print necessary columns of each  record

                while (rdr.Read())
                {
                    // get the results of each column
                     string ID = rdr["LoadTestRunId"].ToString();
                    string NetworkId = rdr["NetworkId"].ToString();
                    string NetworkName = rdr["NetworkName"].ToString();

                    // print out the results
                    //Console.Write("{0,-25}", ID);
                    //Console.Write(ID);
                    Console.Write("{0,-25}", ID);
                    Console.Write("{0,-25}", NetworkId);
                    Console.Write("{0,-25}", NetworkName);
                    Console.WriteLine();
                }
            }
            finally
            {
                // 3. close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

