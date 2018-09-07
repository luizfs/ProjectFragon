﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragonChallenge.Data
{
    public class CustomerData:ConfigData
    {
        public void DeleteById(int id)
        {
            string sql = "DELETE Customer WHERE CustomerId =@id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<Business.Customer> GetAllCustomer()
        {
            string sql = "SELECT CustomerId, FirsName, LastName, CPF, BirthDate, Age, Profession FROM Customer ORDER BY CustomerId DESC";
            var cmd = new SqlCommand(sql);
            List<Business.Customer> listCustomer = new List<Business.Customer>();
            Business.Customer cus = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        cus = new Business.Customer();
                        cus.CustomerId = (int)reader["CustomerId"];
                        cus.FirstName = reader["FirstName"].ToString();
                        cus.LastName = reader["LastName"].ToString();
                        cus.CPF = reader["CPF"].ToString();
                        cus.BirthDate = (DateTime)reader["BirthDate"];
                        cus.Age = (int)reader["Age"];
                        cus.Profession = (int)reader["Profession"];
                        listCustomer.Add(cus);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listCustomer;

        }

        public Business.Customer GetCustomerById(int id)
        {
            string sql = "SELECT CustomerId, FirsName, LastName, CPF, BirthDate, Age, Profession FROM Customer WHERE CustomerId=@id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);
            Business.Customer cus = null;
            try
            {
                conexao.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            cus = new Business.Customer();
                            cus.CustomerId = (int)reader["CustomerId"];
                            cus.FirstName = reader["FirstName"].ToString();
                            cus.LastName = reader["LastName"].ToString();
                            cus.CPF = reader["CPF"].ToString();
                            cus.BirthDate = (DateTime)reader["BirthDate"];
                            cus.Age = (int)reader["Age"];
                            cus.Profession = (int)reader["Profession"];
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return cus;


        }

        public int InsertCustomer(Business.Customer customer)
        {
            string sql = "INSERT INTO Customer (FirstName, LastName, CPF, BirthDate, Age, Profession) VALUES (@FirstName, @LastName, @CPF, @BirthDate, @Age, @Profession)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@CPF", customer.CPF);
            cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
            cmd.Parameters.AddWithValue("@Age", customer.Age);
            cmd.Parameters.AddWithValue("@Profession", customer.Profession);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;

        }

        public int UpdateCustomer(Business.Customer customer)
        {
            string sql = "UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, CPF=@CPF, BirthDate=@BirthDate, Age=@Age, Profession=@Profession WHERE CustomerId=@CustomerId";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@CPF", customer.CPF);
            cmd.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
            cmd.Parameters.AddWithValue("@Age", customer.Age);
            cmd.Parameters.AddWithValue("@Profession", customer.Profession);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }
    }
}