﻿using System;
using System.Data;
using System.Data.SqlClient;

public class DBConnection
{
    private string connectionString;

    // Constructor, truyền vào chuỗi kết nối
    public DBConnection(string connectionString)
    {
        this.connectionString = connectionString;

    }

    // Mở kết nối
    private SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    // Thực hiện Create (INSERT)
    public bool ExecuteInsert(string query, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có bản ghi được thêm
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }

    // Thực hiện Read (SELECT)
    public DataTable ExecuteSelect(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt); // Đổ kết quả vào DataTable
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }

    // Thực hiện Update (UPDATE)
    public bool ExecuteUpdate(string query, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có bản ghi được cập nhật
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }

    // Thực hiện Delete (DELETE)
    public bool ExecuteDelete(string query, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có bản ghi bị xóa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }

    // Kiểm tra sự tồn tại của bảng
    public bool IsTableExist(string tableName)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Trả về true nếu bảng tồn tại
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }

    // Lấy số lượng bản ghi
    public int GetRecordCount(string tableName)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM {tableName}";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }
    }

    // Thực hiện giao dịch (Transaction)
    public bool ExecuteTransaction(string[] queries, SqlParameter[][] parametersArray)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                for (int i = 0; i < queries.Length; i++)
                {
                    using (SqlCommand cmd = new SqlCommand(queries[i], conn, transaction))
                    {
                        if (parametersArray[i] != null)
                        {
                            cmd.Parameters.AddRange(parametersArray[i]);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit(); // Commit transaction nếu mọi thứ thành công
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Transaction Error: " + ex.Message);
                transaction.Rollback(); // Rollback nếu có lỗi
                return false;
            }
        }
    }

    // Gọi stored procedure (thủ tục lưu trữ)
    public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt); // Đổ kết quả vào DataTable
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }

    // Thực hiện lệnh SQL và trả về giá trị từ hàm
    public object ExecuteFunction(string functionName, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();

                // Xây dựng câu lệnh SELECT để gọi hàm
                string query = $"SELECT dbo.{functionName}(";

                // Nếu có tham số, thêm các tham số vào câu lệnh
                if (parameters != null && parameters.Length > 0)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (i > 0) query += ", ";
                        query += $"@param{i}"; // Tạo tham số
                    }
                }
                query += ")"; // Đóng câu lệnh gọi hàm

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số vào SqlCommand nếu có
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue($"@param{i}", parameters[i].Value);
                        }
                    }

                    // Thực thi câu lệnh và trả về giá trị scalar
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }


    // Thực hiện lệnh SQL và trả về một giá trị duy nhất
    public object ExecuteScalar(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar(); // Trả về giá trị đầu tiên (scalar)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }

    // Thực hiện Bulk Insert (chèn nhiều bản ghi)
    public bool BulkInsert(DataTable dataTable, string destinationTableName)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = destinationTableName;
                    bulkCopy.WriteToServer(dataTable); // Chuyển dữ liệu từ DataTable vào CSDL
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bulk Insert Error: " + ex.Message);
                return false;
            }
        }
    }

    // Thực hiện lệnh SQL với con trỏ
    public void ExecuteCursor(string procedureName)
    {
        using (SqlConnection conn = GetConnection())
        {
            try
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thực hiện lệnh
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
