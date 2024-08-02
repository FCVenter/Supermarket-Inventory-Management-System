using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace WoolworthsInventorySystem
{
    public static class DatabaseConstants
    {
        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WoolworthsDB.mdf;Integrated Security = True";
    }

    public class Customer
    {
        public int CustomerID { get; set; } // Primary Key
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Returns a string representation of the Customer object.
        /// </summary>
        /// <returns>A string containing the customer's details.</returns>
        public override string ToString()
        {
            return $"Customer ID: {CustomerID}\n" +
                   $"Name: {CustomerName}\n" +
                   $"Address: {CustomerAddress}\n" +
                   $"Phone Number: {CustomerPhoneNumber}\n" +
                   $"Email: {CustomerEmail}";
        }

        /// <summary>
        /// Inserts a new customer record into the database and returns the newly created CustomerID.
        /// </summary>
        /// <param name="customer">The customer object containing details to be inserted.</param>
        /// <returns>The ID of the newly created customer.</returns>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static int InsertCustomer(Customer customer)
        {
            try
            {
                // SQL command to insert a new customer record and return the newly created CustomerID
                string sql = "INSERT INTO CUSTOMER (Customer_Name, Customer_Address, Customer_Phone_Number, Customer_Email) " +
                             "VALUES (@CustomerName, @CustomerAddress, @CustomerPhoneNumber, @CustomerEmail); " +
                             "SELECT SCOPE_IDENTITY();"; // This will return the ID of the newly inserted record

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // Add parameters from the customer object to the SQL command
                        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                        command.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                        command.Parameters.AddWithValue("@CustomerPhoneNumber", customer.CustomerPhoneNumber);
                        command.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);

                        // Execute the SQL command and retrieve the newly created CustomerID
                        int newCustomerId = Convert.ToInt32(command.ExecuteScalar());
                        return newCustomerId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while inserting the customer.", ex);
            }
        }

        /// <summary>
        /// Retrieves all customer records from the database.
        /// </summary>
        /// <returns>A list of all customers.</returns>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM CUSTOMER", conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Construct customer objects from the retrieved records and add them to the list
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                CustomerID = Convert.ToInt32(reader["Customer_ID"]),
                                CustomerName = reader["Customer_Name"].ToString(),
                                CustomerAddress = reader["Customer_Address"].ToString(),
                                CustomerPhoneNumber = reader["Customer_Phone_Number"].ToString(),
                                CustomerEmail = reader["Customer_Email"].ToString()
                            };

                            customers.Add(customer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving all customers.", ex);
            }

            return customers;
        }

        /// <summary>
        /// Retrieves a customer record from the database based on their ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer to retrieve.</param>
        /// <returns>The customer object if found; otherwise, null.</returns>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static Customer GetCustomerById(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM CUSTOMER WHERE Customer_ID = @CustomerId", conn))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerID = Convert.ToInt32(reader["Customer_ID"]),
                                CustomerName = reader["Customer_Name"].ToString(),
                                CustomerAddress = reader["Customer_Address"].ToString(),
                                CustomerPhoneNumber = reader["Customer_Phone_Number"].ToString(),
                                CustomerEmail = reader["Customer_Email"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the customer by ID.", ex);
            }

            return null;
        }

        /// <summary>
        /// Updates a customer record in the database.
        /// </summary>
        /// <param name="customer">The customer object containing updated details.</param>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                // SQL command to update the customer record
                string sql = "UPDATE CUSTOMER SET Customer_Name = @CustomerName, Customer_Address = @CustomerAddress, Customer_Phone_Number = @CustomerPhone_Number, Customer_Email = @CustomerEmail WHERE Customer_ID = @CustomerId";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // Add parameters from the customer object to the SQL command
                        command.Parameters.AddWithValue("@CustomerId", customer.CustomerID);
                        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                        command.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                        command.Parameters.AddWithValue("@CustomerPhone_Number", customer.CustomerPhoneNumber);
                        command.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);

                        // Execute the SQL command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the customer.", ex);
            }
        }

        /// <summary>
        /// Deletes a customer record and its associated orders from the database based on their ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer to delete.</param>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static void DeleteCustomer(int customerId)
        {
            try
            {
                // Establish a connection to the database
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // Begin a transaction to ensure data integrity across multiple table operations
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Delete associated order products:
                            // This SQL command targets the Order_Product table and deletes records 
                            // that are associated with orders of the customer being deleted.
                            string deleteOrderProductsSql = "DELETE FROM Order_Product WHERE Order_ID IN (SELECT Order_ID FROM Product_Purchased WHERE Customer_ID = @CustomerId)";
                            using (SqlCommand command = new SqlCommand(deleteOrderProductsSql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@CustomerId", customerId);
                                command.ExecuteNonQuery();
                            }

                            // 2. Delete associated orders from Product_Purchased table:
                            // This SQL command targets the Product_Purchased table and deletes orders 
                            // that are associated with the customer being deleted.
                            string deleteOrdersSql = "DELETE FROM Product_Purchased WHERE Customer_ID = @CustomerId";
                            using (SqlCommand command = new SqlCommand(deleteOrdersSql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@CustomerId", customerId);
                                command.ExecuteNonQuery();
                            }

                            // 3. Delete the customer:
                            // This SQL command targets the CUSTOMER table and deletes the customer record.
                            string sql = "DELETE FROM CUSTOMER WHERE Customer_ID = @CustomerId";
                            using (SqlCommand command = new SqlCommand(sql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@CustomerId", customerId);
                                command.ExecuteNonQuery();
                            }

                            // Commit the transaction to finalize all the changes
                            transaction.Commit();
                        }
                        catch
                        {
                            // If any part of the transaction fails, roll back all changes to maintain data integrity
                            transaction.Rollback();
                            throw; // Re-throw the exception to be caught in the outer catch block
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the database operations and provide a detailed error message
                throw new ApplicationException("An error occurred while deleting the customer and associated records.", ex);
            }
        }

        /// <summary>
        /// Searches for customer records in the database based on their name.
        /// </summary>
        /// <param name="name">The name or part of the name to search for.</param>
        /// <returns>A list of customers matching the search criteria.</returns>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static List<Customer> SearchCustomersByName(string name)
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM CUSTOMER WHERE Customer_Name LIKE @Name", conn))
                    {
                        // Add the name parameter to the SQL command with wildcard characters for partial matching
                        command.Parameters.AddWithValue("@Name", "%" + name + "%");

                        SqlDataReader reader = command.ExecuteReader();

                        // Construct customer objects from the retrieved records and add them to the list
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerID = Convert.ToInt32(reader["Customer_ID"]),
                                CustomerName = reader["Customer_Name"].ToString(),
                                CustomerAddress = reader["Customer__Address"].ToString(),
                                CustomerPhoneNumber = reader["Customer_Phone_Number"].ToString(),
                                CustomerEmail = reader["Customer_Email"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while searching customers by name.", ex);
            }

            return customers;
        }

        /// <summary>
        /// Retrieves a customer from the database based on their email address.
        /// 
        /// This method performs the following steps:
        /// 1. Establishes a connection to the database.
        /// 2. Executes a SQL query to search for a customer with the provided email address.
        /// 3. If a match is found, constructs and returns a Customer object with the retrieved details.
        /// 4. If no match is found, returns null.
        /// 
        /// Exceptions:
        /// - Throws an ApplicationException if any database operation fails.
        /// 
        /// </summary>
        /// <param name="email">The email address of the customer to retrieve.</param>
        /// <returns>A Customer object if found; otherwise, null.</returns>
        public static Customer GetCustomerByEmail(string email)
        {
            try
            {
                // Step 1: Establish a connection to the database
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // Step 2: Execute a SQL query to search for a customer with the provided email address
                    using (SqlCommand command = new SqlCommand("SELECT * FROM CUSTOMER WHERE Customer_Email = @Email", conn))
                    {
                        // Add the email parameter to the SQL command
                        command.Parameters.AddWithValue("@Email", email);

                        SqlDataReader reader = command.ExecuteReader();

                        // Step 3: If a match is found, construct and return a Customer object with the retrieved details
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerID = Convert.ToInt32(reader["Customer_ID"]),
                                CustomerName = reader["Customer_Name"].ToString(),
                                CustomerAddress = reader["Customer_Address"].ToString(),
                                CustomerPhoneNumber = reader["Customer_Phone_Number"].ToString(),
                                CustomerEmail = reader["Customer_Email"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

            // Step 4: If no match is found, return null
            return null;
        }
    }

    public class Product
    {
        public int ProductID { get; set; } // Primary Key
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int StockLeft { get; set; }


        /// <summary>
        /// Returns a string representation of the Product object.
        /// </summary>
        /// <returns>A string containing the product's details.</returns>
        public override string ToString()
        {
            return $"Product ID: {ProductID}, Name: {ProductName}, Description: {ProductDescription}, Price: {ProductPrice:C}, Stock Left: {StockLeft}";
        }

        /// <summary>
        /// Inserts a new product into the database and returns the newly created ProductID.
        /// </summary>
        /// <param name="product">The product object to insert.</param>
        /// <returns>The ID of the newly created product.</returns>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static int InsertProduct(Product product)
        {
            try
            {
                string sql = "INSERT INTO PRODUCT (Product_Name, Product_Description, Product_Price, Stock_Left) " +
                             "OUTPUT INSERTED.Product_ID " +
                             "VALUES (@ProductName, @ProductDescription, @ProductPrice, @StockLeft)";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                        command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                        command.Parameters.AddWithValue("@StockLeft", product.StockLeft);

                        // Execute the SQL command and retrieve the newly created ProductID
                        int newProductID = (int)command.ExecuteScalar();
                        return newProductID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while inserting the product.", ex);
            }
        }

        /// <summary>
        /// Updates a product's details in the database.
        /// </summary>
        /// <param name="product">The product object with updated details.</param>
        public static void UpdateProduct(Product product)
        {
            try
            {
                string sql = "UPDATE PRODUCT SET Product_Name = @ProductName, Product_Description = @ProductDescription, " +
                             "Product_Price = @ProductPrice, Stock_Left = @StockLeft " +
                             "WHERE Product_ID = @ProductId";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                        command.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                        command.Parameters.AddWithValue("@StockLeft", product.StockLeft);
                        command.Parameters.AddWithValue("@ProductId", product.ProductID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while updating the product.", ex);
            }
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products.</returns>
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM PRODUCT", conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = Convert.ToInt32(reader["Product_ID"]),
                                ProductName = reader["Product_Name"].ToString(),
                                ProductDescription = reader["Product_Description"].ToString(),
                                ProductPrice = Convert.ToDecimal(reader["Product_Price"]),
                                StockLeft = Convert.ToInt32(reader["Stock_Left"])
                            };

                            products.Add(product);
                        }
                    }

                    return products;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while retrieving all products.", ex);
            }
        }

        /// <summary>
        /// Searches for products based on a maximum price.
        /// </summary>
        /// <param name="maxPrice">The maximum price to search for.</param>
        /// <returns>A list of products with a price less than or equal to the specified max price.</returns>
        public static List<Product> SearchProductsByPrice(decimal maxPrice)
        {
            List<Product> products = new List<Product>();

            try
            {
                string sql = "SELECT * FROM PRODUCT WHERE Product_Price <= @MaxPrice";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@MaxPrice", maxPrice);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductID = Convert.ToInt32(reader["Product_ID"]),
                                ProductName = reader["Product_Name"].ToString(),
                                ProductDescription = reader["Product_Description"].ToString(),
                                ProductPrice = Convert.ToDecimal(reader["Product_Price"]),
                                StockLeft = Convert.ToInt32(reader["Stock_Left"])
                            };

                            products.Add(product);
                        }
                    }
                }

                return products;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while searching products by price.", ex);
            }
        }

        /// <summary>
        /// Retrieves a list of products associated with a specific order.
        /// </summary>
        /// <param name="orderId">The ID of the order for which products are to be retrieved.</param>
        /// <returns>A list of OrderProduct objects representing each product and its quantity in the specified order.</returns>
        /// <exception cref="ApplicationException">Thrown when there's an error during database operations.</exception>
        public static List<OrderProduct> GetProductsForOrder(int orderId)
        {
            // Initialize a list to hold the products associated with the specified order.
            List<OrderProduct> productsForOrder = new List<OrderProduct>();

            try
            {
                // Establish a connection to the database.
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // SQL query to select all products associated with the given order ID.
                    string sql = "SELECT * FROM Order_Product WHERE Order_ID = @OrderID";

                    // Execute the SQL query.
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // Add the order ID parameter to the SQL command.
                        command.Parameters.AddWithValue("@OrderID", orderId);

                        // Execute the command and retrieve the results into a SqlDataReader.
                        SqlDataReader reader = command.ExecuteReader();

                        // Loop through each record in the result set.
                        while (reader.Read())
                        {
                            // Create an OrderProduct object for each record.
                            OrderProduct orderProduct = new OrderProduct
                            {
                                OrderID = Convert.ToInt32(reader["Order_ID"]),
                                ProductID = Convert.ToInt32(reader["Product_ID"]),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            };

                            // Add the OrderProduct object to the list.
                            productsForOrder.Add(orderProduct);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If there's an error during database operations, log the exception or handle it as needed.
                // For this example, we're throwing an ApplicationException with a detailed error message.
                throw new ApplicationException("An error occurred while retrieving products for the order.", ex);
            }

            // Return the list of products associated with the specified order.
            return productsForOrder;
        }

        /// <summary>
        /// Deletes a product and its associated records from the database based on its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static void DeleteProduct(int productId)
        {
            try
            {
                // Establish a connection to the database
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // Begin a transaction to ensure data integrity across multiple table operations
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Delete associated records from Order_Product table:
                            // This SQL command targets the Order_Product table and deletes records 
                            // that are associated with the product being deleted.
                            string deleteOrderProductsSql = "DELETE FROM Order_Product WHERE Product_ID = @ProductId";
                            using (SqlCommand command = new SqlCommand(deleteOrderProductsSql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@ProductId", productId);
                                command.ExecuteNonQuery();
                            }

                            // 2. Delete associated records from Product_Supplied table:
                            // This SQL command targets the Product_Supplied table and deletes records 
                            // that are associated with the product being deleted.
                            string deleteProductSuppliedSql = "DELETE FROM Product_Supplied WHERE Product_ID = @ProductId";
                            using (SqlCommand command = new SqlCommand(deleteProductSuppliedSql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@ProductId", productId);
                                command.ExecuteNonQuery();
                            }

                            // 3. Delete the product:
                            // This SQL command targets the PRODUCT table and deletes the product record.
                            string sql = "DELETE FROM PRODUCT WHERE Product_ID = @ProductId";
                            using (SqlCommand command = new SqlCommand(sql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@ProductId", productId);
                                command.ExecuteNonQuery();
                            }

                            // Commit the transaction to finalize all the changes
                            transaction.Commit();
                        }
                        catch
                        {
                            // If any part of the transaction fails, roll back all changes to maintain data integrity
                            transaction.Rollback();
                            throw; // Re-throw the exception to be caught in the outer catch block
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the database operations and provide a detailed error message
                throw new ApplicationException("An error occurred while deleting the product and associated records.", ex);
            }
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product object if found; otherwise, null.</returns>
        public static Product GetProductById(int productId)
        {
            try
            {
                string sql = "SELECT * FROM PRODUCT WHERE Product_ID = @ProductId";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductID = Convert.ToInt32(reader["Product_ID"]),
                                ProductName = reader["Product_Name"].ToString(),
                                ProductDescription = reader["Product_Description"].ToString(),
                                ProductPrice = Convert.ToDecimal(reader["Product_Price"]),
                                StockLeft = Convert.ToInt32(reader["Stock_Left"])
                            };
                        }
                    }
                }

                return null; // Return null if no product with the given ID is found
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while retrieving the product by ID.", ex);
            }
        }

        /// <summary>
        /// Retrieves a product from the database based on its name.
        /// </summary>
        /// <param name="productName">The name of the product to retrieve.</param>
        /// <returns>A Product object if found; otherwise, null.</returns>
        /// <exception cref="ApplicationException">Thrown when there's an error during database operations.</exception>
        public static Product GetProductByName(string productName)
        {
            try
            {
                // SQL query to select a product based on its name.
                string sql = "SELECT * FROM PRODUCT WHERE Product_Name = @ProductName";

                // Establish a connection to the database.
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // Execute the SQL query.
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // Add the product name parameter to the SQL command.
                        command.Parameters.AddWithValue("@ProductName", productName);

                        // Execute the command and retrieve the results into a SqlDataReader.
                        SqlDataReader reader = command.ExecuteReader();

                        // If a record is found, create a Product object and return it.
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductID = Convert.ToInt32(reader["Product_ID"]),
                                ProductName = reader["Product_Name"].ToString(),
                                ProductDescription = reader["Product_Description"].ToString(),
                                ProductPrice = Convert.ToDecimal(reader["Product_Price"]),
                                StockLeft = Convert.ToInt32(reader["Stock_Left"])
                            };
                        }
                    }
                }

                // If no product with the given name is found, return null.
                return null;
            }
            catch (Exception ex)
            {
                // If there's an error during database operations, log the exception or handle it as needed.
                // For this example, we're throwing an ApplicationException with a detailed error message.
                throw new ApplicationException("An error occurred while retrieving the product by name.", ex);
            }
        }

    }

    public enum PaymentMethod
    {
        Card = 1,
        Cash = 2,
        Paypal = 3
    }

    public class ProductPurchased
    {
        public int OrderID { get; set; } // Primary Key
        public int CustomerID { get; set; } // Foreign Key from Customer
        public DateTime OrderDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // A private list to hold the individual products purchased within an order
        private List<OrderProduct> OrderProducts = new List<OrderProduct>();

        /// <summary>
        /// Adds an OrderProduct to the list of orderProducts.
        /// </summary>
        /// <param name="orderProduct">The OrderProduct to add.</param>
        public void AddOrderProduct(OrderProduct orderProduct)
        {
            OrderProducts.Add(orderProduct);
        }

        /// <summary>
        /// Removes an OrderProduct from the list of orderProducts.
        /// </summary>
        /// <param name="orderProduct">The OrderProduct to remove.</param>
        public void RemoveOrderProduct(OrderProduct orderProduct)
        {
            OrderProducts.Remove(orderProduct);
        }

        /// <summary>
        /// Retrieves all OrderProducts for this ProductPurchased.
        /// </summary>
        /// <returns>A list of OrderProducts.</returns>
        public List<OrderProduct> GetOrderProducts()
        {
            return OrderProducts;
        }

        /// <summary>
        /// Places an order by inserting into the ProductPurchased table and updating the Product stock.
        /// </summary>
        /// <param name="order">The ProductPurchased order to place.</param>
        public static void PlaceOrder(ProductPurchased order)
        {
            try
            {
                List<OrderProduct> orderProducts = order.GetOrderProducts();

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        // Insert into ProductPurchased to create an order and get the generated OrderID
                        string insertOrderSql = "INSERT INTO Product_Purchased (Customer_ID, Order_Date, Payment_Method) VALUES (@CustomerID, @OrderDate, @PaymentMethod);" +
                            " SELECT SCOPE_IDENTITY();";
                        using (SqlCommand orderCommand = new SqlCommand(insertOrderSql, conn, transaction))
                        {
                            orderCommand.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                            orderCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                            orderCommand.Parameters.AddWithValue("@PaymentMethod", (int)order.PaymentMethod);

                            // ExecuteScalar retrieves the generated OrderID
                            int insertedOrderId = Convert.ToInt32(orderCommand.ExecuteScalar());
                            order.OrderID = insertedOrderId;

                            // Insert into OrderProduct and update Product stock for each product in the order
                            foreach (OrderProduct product in orderProducts)
                            {
                                product.OrderID = insertedOrderId;

                                // Check stock before placing order
                                string checkStockSql = "SELECT Stock_Left FROM Product WHERE Product_ID = @ProductID";
                                using (SqlCommand checkStockCommand = new SqlCommand(checkStockSql, conn, transaction))
                                {
                                    checkStockCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                                    int currentStock = Convert.ToInt32(checkStockCommand.ExecuteScalar());

                                    if (product.Quantity > currentStock)
                                    {
                                        // Rollback the transaction
                                        transaction.Rollback();

                                        // Throw a custom exception with a detailed message
                                        throw new ApplicationException($"Unable to place order. Not enough stock for product '{product.ProductID}'. Only {currentStock} items left in " +
                                            $"stock, but {product.Quantity} were requested.");
                                    }
                                }

                                // Insert into OrderProduct table
                                string insertOrderProductSql = "INSERT INTO Order_Product (Order_ID, Product_ID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                                using (SqlCommand orderProductCommand = new SqlCommand(insertOrderProductSql, conn, transaction))
                                {
                                    orderProductCommand.Parameters.AddWithValue("@OrderID", insertedOrderId);
                                    orderProductCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                                    orderProductCommand.Parameters.AddWithValue("@Quantity", product.Quantity);

                                    // ExecuteNonQuery to insert into OrderProduct
                                    orderProductCommand.ExecuteNonQuery();
                                }

                                // Update Product Stock_Left by subtracting the ordered quantity
                                string updateProductStockSql = "UPDATE Product SET Stock_Left = Stock_Left - @Quantity WHERE Product_ID = @ProductID";
                                using (SqlCommand updateProductStockCommand = new SqlCommand(updateProductStockSql, conn, transaction))
                                {
                                    updateProductStockCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
                                    updateProductStockCommand.Parameters.AddWithValue("@ProductID", product.ProductID);

                                    // ExecuteNonQuery to update Product stock
                                    updateProductStockCommand.ExecuteNonQuery();
                                }

                                // Check if stock is less than 50 after updating and order more products if necessary
                                string getUpdatedStockSql = "SELECT Stock_Left FROM Product WHERE Product_ID = @ProductID";
                                using (SqlCommand getUpdatedStockCommand = new SqlCommand(getUpdatedStockSql, conn, transaction))
                                {
                                    getUpdatedStockCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                                    int updatedStock = Convert.ToInt32(getUpdatedStockCommand.ExecuteScalar());

                                    if (updatedStock < 50)
                                    {
                                        OrderMoreProducts(product.ProductID, 100); // order 100 more of said product
                                    }
                                }
                            }

                            // Commit the transaction if everything is successful
                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while placing the order.", ex);
            }
        }

        /// <summary>
        /// Orders more products from the supplier when stock is low.
        /// 
        /// This method performs the following steps:
        /// 1. Identifies the primary supplier for the given product based on the most recent order.
        /// 2. Creates a new record in the ProductSupplied table to indicate a new order for the product.
        /// 3. Optionally notifies the supplier about the new order (this step is represented as a placeholder and needs to be implemented).
        /// 
        /// Note: This method assumes that each product has at least one supplier in the ProductSupplied table.
        /// 
        /// Exceptions:
        /// - Throws an ApplicationException if no supplier is found for the product.
        /// - Throws an ApplicationException if any database operation fails.
        /// 
        /// </summary>
        /// <param name="productId">The ID of the product that needs to be reordered.</param>
        public static void OrderMoreProducts(int productId, int amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // 1. Identify the supplier for the product
                    string getSupplierSql = "SELECT Supplier_ID FROM Product_Supplied WHERE Product_ID = @ProductID ORDER BY Date_Ordered DESC";
                    int supplierId;
                    using (SqlCommand getSupplierCommand = new SqlCommand(getSupplierSql, conn))
                    {
                        getSupplierCommand.Parameters.AddWithValue("@ProductID", productId);
                        supplierId = Convert.ToInt32(getSupplierCommand.ExecuteScalar());
                    }

                    if (supplierId == 0)
                    {
                        throw new ApplicationException("No supplier found for the product.");
                    }

                    // 2. Create a new ProductSupplied record
                    ProductSupplied newSupply = new ProductSupplied
                    {
                        ProductID = productId,
                        SupplierID = supplierId,
                        DateOrdered = DateTime.Now,
                        Quantity = amount, // Example quantity to order. Adjust as needed.
                        IsReceived = false
                    };

                    string insertSupplySql = "INSERT INTO Product_Supplied (Product_ID, Supplier_ID, Date_Ordered, Quantity, Is_Received) " +
                                             "VALUES (@ProductID, @SupplierID, @DateOrdered, @Quantity, @IsReceived)";
                    using (SqlCommand insertSupplyCommand = new SqlCommand(insertSupplySql, conn))
                    {
                        insertSupplyCommand.Parameters.AddWithValue("@ProductID", newSupply.ProductID);
                        insertSupplyCommand.Parameters.AddWithValue("@SupplierID", newSupply.SupplierID);
                        insertSupplyCommand.Parameters.AddWithValue("@DateOrdered", newSupply.DateOrdered);
                        insertSupplyCommand.Parameters.AddWithValue("@Quantity", newSupply.Quantity);
                        insertSupplyCommand.Parameters.AddWithValue("@IsReceived", newSupply.IsReceived);

                        insertSupplyCommand.ExecuteNonQuery();
                    }

                    // 3. Notify the supplier (Placeholder)
                    // This can be an email, an API call to the supplier's system, etc.
                    // For now, I'll just add a comment.
                    // NotifySupplier(supplierId, newSupply.Quantity);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while ordering more products.", ex);
            }
        }

        // METHOD TO BE IMPLEMENTED WITHIN THE FOLLOWING MONTHS
        private static void NotifySupplier(int supplierId, int quantity)
        {
            // Logic to notify the supplier about the new order
            // This can be an email, an API call to the supplier's system, etc.
        }

    }

    public class OrderProduct
    {
        public int OrderID { get; set; } // PK FK from ProductPurchased
        public int ProductID { get; set; } // PK FK from Product
        public int Quantity { get; set; } // Subtracted from Stock_Left in Product
    }

    public class Supplier
    {
        public int SupplierID { get; set; } // Primary Key
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhoneNumber { get; set; }

        /// <summary>
        /// Provides a string representation of the Supplier object, including the SupplierID.
        /// </summary>
        /// <returns>
        /// A string in the format: "ID: [SupplierID], Name: [SupplierName], Address: [SupplierAddress], Phone Number: [SupplierPhoneNumber]".
        /// </returns>
        public override string ToString()
        {
            return $"ID: {SupplierID}, Name: {SupplierName}, Address: {SupplierAddress}, Phone Number: {SupplierPhoneNumber}";
        }

        /// <summary>
        /// Inserts a new supplier record into the database and returns the newly created supplier ID.
        /// </summary>
        /// <param name="supplier">The supplier object containing details to be inserted.</param>
        /// <returns>The ID of the newly created supplier.</returns>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static int InsertSupplier(Supplier supplier)
        {
            try
            {
                // SQL command to insert a new supplier record and return the newly created ID
                string sql = "INSERT INTO SUPPLIER (Supplier_Name, Supplier_Address, Supplier_Phone_Number) " +
                             "VALUES (@SupplierName, @SupplierAddress, @SupplierPhoneNumber); " +
                             "SELECT CAST(SCOPE_IDENTITY() AS INT);";  // This line gets the newly created ID

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // Add parameters from the supplier object to the SQL command
                        command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("@SupplierAddress", supplier.SupplierAddress);
                        command.Parameters.AddWithValue("@SupplierPhoneNumber", supplier.SupplierPhoneNumber);

                        // Execute the SQL command and get the newly created supplier ID
                        int newSupplierID = (int)command.ExecuteScalar();
                        return newSupplierID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while inserting the supplier.", ex);
            }
        }

        /// <summary>
        /// Updates a supplier's details in the database.
        /// </summary>
        /// <param name="supplier">The supplier object with updated details.</param>
        public static void UpdateSupplier(Supplier supplier)
        {
            try
            {
                string sql = "UPDATE SUPPLIER SET Supplier_Name = @SupplierName, Supplier_Address = @SupplierAddress, " +
                             "Supplier_PhoneNumber = @SupplierPhoneNumber " +
                             "WHERE SupplierID = @SupplierID";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("@SupplierAddress", supplier.SupplierAddress);
                        command.Parameters.AddWithValue("@SupplierPhoneNumber", supplier.SupplierPhoneNumber);
                        command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while updating the supplier.", ex);
            }
        }

        /// <summary>
        /// Deletes a supplier and its associated records from the database based on its ID.
        /// </summary>
        /// <param name="supplierId">The ID of the supplier to delete.</param>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static void DeleteSupplier(int supplierId)
        {
            try
            {
                // Establish a connection to the database
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // Begin a transaction to ensure data integrity across multiple table operations
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Delete associated records from Product_Supplied table:
                            // This SQL command targets the Product_Supplied table and deletes records 
                            // that are associated with the supplier being deleted.
                            string deleteProductSuppliedSql = "DELETE FROM Product_Supplied WHERE Supplier_ID = @SupplierID";
                            using (SqlCommand command = new SqlCommand(deleteProductSuppliedSql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@SupplierID", supplierId);
                                command.ExecuteNonQuery();
                            }

                            // 2. Delete the supplier:
                            // This SQL command targets the SUPPLIER table and deletes the supplier record.
                            string sql = "DELETE FROM SUPPLIER WHERE Supplier_ID = @SupplierID";
                            using (SqlCommand command = new SqlCommand(sql, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@SupplierID", supplierId);
                                command.ExecuteNonQuery();
                            }

                            // Commit the transaction to finalize all the changes
                            transaction.Commit();
                        }
                        catch
                        {
                            // If any part of the transaction fails, roll back all changes to maintain data integrity
                            transaction.Rollback();
                            throw; // Re-throw the exception to be caught in the outer catch block
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the database operations and provide a detailed error message
                throw new ApplicationException("An error occurred while deleting the supplier and associated records.", ex);
            }
        }

        /// <summary>
        /// Retrieves all suppliers from the database.
        /// </summary>
        /// <returns>A list of all suppliers.</returns>
        public static List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM SUPPLIER", conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["Supplier_ID"]),
                                SupplierName = reader["Supplier_Name"].ToString(),
                                SupplierAddress = reader["Supplier_Address"].ToString(),
                                SupplierPhoneNumber = reader["Supplier_PhoneNumber"].ToString()
                            };

                            suppliers.Add(supplier);
                        }
                    }

                    return suppliers;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while retrieving all suppliers.", ex);
            }
        }

        /// <summary>
        /// Retrieves a supplier by its ID.
        /// </summary>
        /// <param name="supplierId">The ID of the supplier to retrieve.</param>
        /// <returns>The supplier object if found; otherwise, null.</returns>
        public static Supplier GetSupplierById(int supplierId)
        {
            try
            {
                string sql = "SELECT * FROM SUPPLIER WHERE Supplier_ID = @SupplierID";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@SupplierID", supplierId);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            return new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["Supplier_ID"]),
                                SupplierName = reader["Supplier_Name"].ToString(),
                                SupplierAddress = reader["Supplier_Address"].ToString(),
                                SupplierPhoneNumber = reader["Supplier_Phone_Number"].ToString()
                            };
                        }
                    }
                }

                return null; // Return null if no supplier with the given ID is found
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while retrieving the supplier by ID.", ex);
            }
        }

        /// <summary>
        /// Searches for suppliers by their name.
        /// </summary>
        /// <param name="name">The name or part of the name to search for.</param>
        /// <returns>A list of suppliers matching the search criteria.</returns>
        public static List<Supplier> SearchSuppliersByName(string name)
        {
            List<Supplier> suppliers = new List<Supplier>();

            try
            {
                string sql = "SELECT * FROM SUPPLIER WHERE Supplier_Name LIKE @Name";

                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@Name", "%" + name + "%");

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["Supplier_ID"]),
                                SupplierName = reader["Supplier_Name"].ToString(),
                                SupplierAddress = reader["Supplier_Address"].ToString(),
                                SupplierPhoneNumber = reader["Supplier_PhoneNumber"].ToString()
                            });
                        }
                    }
                }

                return suppliers;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while searching suppliers by name.", ex);
            }
        }

        /// <summary>
        /// Orders more products from the supplier when stock is low.
        /// 
        /// This method performs the following steps:
        /// 1. Identifies the primary supplier for the given product based on the most recent order.
        /// 2. Checks if a record already exists for the product and supplier combination.
        /// 3. If a record exists, updates the quantity. If not, creates a new record in the ProductSupplied table.
        /// 4. Optionally notifies the supplier about the new order (this step is represented as a placeholder and needs to be implemented).
        /// 
        /// Note: This method assumes that each product has at least one supplier in the ProductSupplied table.
        /// 
        /// Exceptions:
        /// - Throws an ApplicationException if no supplier is found for the product.
        /// - Throws an ApplicationException if any database operation fails.
        /// 
        /// </summary>
        /// <param name="productId">The ID of the product that needs to be reordered.</param>
        /// <param name="amount">The amount of the product to be ordered.</param>
        public static void OrderMoreProducts(int productId, int amount)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    // 1. Identify the supplier for the product
                    string getSupplierSql = "SELECT Supplier_ID FROM Product_Supplied WHERE Product_ID = @ProductID ORDER BY Date_Ordered DESC";
                    int supplierId;
                    using (SqlCommand getSupplierCommand = new SqlCommand(getSupplierSql, conn))
                    {
                        getSupplierCommand.Parameters.AddWithValue("@ProductID", productId);
                        supplierId = Convert.ToInt32(getSupplierCommand.ExecuteScalar());
                    }

                    if (supplierId == 0)
                    {
                        throw new ApplicationException("No supplier found for the product.");
                    }

                    // 2. Check if a record for this product and supplier already exists
                    string checkExistingSql = "SELECT COUNT(*) FROM Product_Supplied WHERE Product_ID = @ProductID AND Supplier_ID = @SupplierID";
                    using (SqlCommand checkExistingCommand = new SqlCommand(checkExistingSql, conn))
                    {
                        checkExistingCommand.Parameters.AddWithValue("@ProductID", productId);
                        checkExistingCommand.Parameters.AddWithValue("@SupplierID", supplierId);
                        int existingCount = Convert.ToInt32(checkExistingCommand.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            // Update the existing record (e.g., increase the quantity)
                            string updateSql = "UPDATE Product_Supplied SET Quantity = Quantity + @Quantity WHERE Product_ID = @ProductID AND Supplier_ID = @SupplierID";
                            using (SqlCommand updateCommand = new SqlCommand(updateSql, conn))
                            {
                                updateCommand.Parameters.AddWithValue("@ProductID", productId);
                                updateCommand.Parameters.AddWithValue("@SupplierID", supplierId);
                                updateCommand.Parameters.AddWithValue("@Quantity", amount);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Insert a new record
                            ProductSupplied newSupply = new ProductSupplied
                            {
                                ProductID = productId,
                                SupplierID = supplierId,
                                DateOrdered = DateTime.Now,
                                Quantity = amount,
                                IsReceived = false
                            };

                            string insertSupplySql = "INSERT INTO Product_Supplied (Product_ID, Supplier_ID, Date_Ordered, Quantity, Is_Received) " +
                                                     "VALUES (@ProductID, @SupplierID, @DateOrdered, @Quantity, @IsReceived)";
                            using (SqlCommand insertSupplyCommand = new SqlCommand(insertSupplySql, conn))
                            {
                                insertSupplyCommand.Parameters.AddWithValue("@ProductID", newSupply.ProductID);
                                insertSupplyCommand.Parameters.AddWithValue("@SupplierID", newSupply.SupplierID);
                                insertSupplyCommand.Parameters.AddWithValue("@DateOrdered", newSupply.DateOrdered);
                                insertSupplyCommand.Parameters.AddWithValue("@Quantity", newSupply.Quantity);
                                insertSupplyCommand.Parameters.AddWithValue("@IsReceived", newSupply.IsReceived);

                                insertSupplyCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // 3. Notify the supplier (Placeholder)
                    // This can be an email, an API call to the supplier's system, etc.
                    // For now, I'll just add a comment.
                    // NotifySupplier(supplierId, amount);
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while ordering more products.", ex);
            }
        }


    }


    public class ProductSupplied
    {
        public int ProductID { get; set; } // Composite Primary Key from Product
        public int SupplierID { get; set; } // Composite Primary Key from Supplier
        public DateTime DateOrdered { get; set; }
        public DateTime? DateReceived { get; set; } // Can be null
        public int Quantity { get; set; } // Added to Stock_Left in Product
        public bool IsReceived { get; set; } // Set to True if Received not null

        /// <summary>
        /// Updates the ProductSupplied record to indicate the supply has been received and updates the stock of the product.
        /// </summary>
        /// <param name="supply">The ProductSupplied object indicating the supply details.</param>
        public static void ReceiveSupply(ProductSupplied supply)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        // Update ProductSupplied record to indicate supply received
                        string updateSupplySql = "UPDATE Product_Supplied SET Date_Received = @DateReceived, IsReceived = 1 WHERE Product_ID = @ProductID AND Supplier_ID = @SupplierID AND Date_Ordered = @DateOrdered";
                        using (SqlCommand updateSupplyCommand = new SqlCommand(updateSupplySql, conn, transaction))
                        {
                            updateSupplyCommand.Parameters.AddWithValue("@DateReceived", DateTime.Now); // Set the current date
                            updateSupplyCommand.Parameters.AddWithValue("@ProductID", supply.ProductID);
                            updateSupplyCommand.Parameters.AddWithValue("@SupplierID", supply.SupplierID);
                            updateSupplyCommand.Parameters.AddWithValue("@DateOrdered", supply.DateOrdered);

                            // ExecuteNonQuery to update the supply record
                            updateSupplyCommand.ExecuteNonQuery();
                        }

                        // Update Product Stock_Left by adding the supplied quantity
                        string updateProductStockSql = "UPDATE Product SET Stock_Left = Stock_Left + @Quantity WHERE ProductID = @ProductID";
                        using (SqlCommand updateProductStockCommand = new SqlCommand(updateProductStockSql, conn, transaction))
                        {
                            updateProductStockCommand.Parameters.AddWithValue("@Quantity", supply.Quantity);
                            updateProductStockCommand.Parameters.AddWithValue("@ProductID", supply.ProductID);

                            // ExecuteNonQuery to update Product stock
                            updateProductStockCommand.ExecuteNonQuery();
                        }

                        // Commit the transaction if everything is successful
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while receiving the supply.", ex);
            }
        }
    }

    public static class DbOperations
    {
        public static void populateCombobox(ComboBox cbx, string sql) //isProduct determines the DisplayMember and ValueMember properties
        {
            try
            {
                SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString);

                // Extract column name using regular expression
                string columnName = Regex.Match(sql, @"(?<=SELECT\s)\w+").Value;

                // Extract table name using regular expression
                string tableName = Regex.Match(sql, @"(?<=FROM\s)\w+").Value;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                DataSet ds = new DataSet();

                SqlCommand command = new SqlCommand(sql, conn);

                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(ds, tableName);


                cbx.DisplayMember = columnName;
                cbx.ValueMember = columnName;
                cbx.DataSource = ds.Tables[tableName];
                cbx.SelectedIndex = -1;

                conn.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error: " + se.Message);
            }
            catch (Exception E)
            {
                MessageBox.Show("Error: " + E.Message);
            }
        }

        /// <summary>
        /// Displays the result of a SQL query in a DataGridView.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="dgv">The DataGridView in which to display the results.</param>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static void DisplaySql(string sql, DataGridView dgv)
        {
            try
            {
                // Establish a connection to the database
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // Create a DataTable to hold the results of the query
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        // Fill the DataTable with the results of the SQL query
                        dataAdapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dgv.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                throw new ApplicationException("An error occurred while displaying the SQL results in the DataGridView.", ex);
            }
        }

        /// <summary>
        /// Displays the result of a SQL query in a RichTextBox.
        /// </summary>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="rtb">The RichTextBox in which to display the results.</param>
        /// <exception cref="ApplicationException">Thrown if any error occurs during the database operation.</exception>
        public static void DisplaySql(string sql, RichTextBox rtb)
        {
            try
            {
                // Establish a connection to the database
                using (SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        StringBuilder sb = new StringBuilder();

                        // Append column names as headers to the StringBuilder
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sb.Append(reader.GetName(i).PadRight(20)); // padding for alignment
                        }
                        sb.AppendLine();

                        // Append each row of the result to the StringBuilder
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                sb.Append(reader[i].ToString().PadRight(20)); // padding for alignment
                            }
                            sb.AppendLine();
                        }

                        // Set the text of the RichTextBox to the constructed string
                        rtb.Text = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                throw new ApplicationException("An error occurred while displaying the SQL results in the RichTextBox.", ex);
            }
        }

        /// <summary>
        /// Generates a report based on the provided SQL query and displays it in the specified RichTextBox.
        /// </summary>
        /// <param name="rtxt">The RichTextBox control where the report will be displayed.</param>
        /// <param name="sql">The SQL query to fetch the report data.</param>
        public static void GenerateReport(RichTextBox rtxt, string sql)
        {
            SqlConnection conn = new SqlConnection(DatabaseConstants.ConnectionString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                rtxt.Clear();

                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader dataReader = command.ExecuteReader();

                int[] maxLengths = CalculateMaxLengths(dataReader);
                dataReader.Close();

                // Reset the data reader
                dataReader = command.ExecuteReader();

                AddReportHeader(rtxt);
                BuildAndAddHeader(dataReader, rtxt, maxLengths);
                BuildAndAddDataRows(dataReader, rtxt, maxLengths);

                // Add "End of Report" at the end
                rtxt.AppendText("End of Report");

                dataReader.Close();
                conn.Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error: " + se.Message);
            }
        }

        private static int[] CalculateMaxLengths(SqlDataReader dataReader)
        {
            int[] maxLengths = new int[dataReader.FieldCount];
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                maxLengths[i] = dataReader.GetName(i).Length;

                while (dataReader.Read())
                {
                    for (int j = 0; j < dataReader.FieldCount; j++)
                    {
                        int length;
                        if (dataReader[j] is decimal || dataReader[j] is double)
                        {
                            length = string.Format("{0:C}", dataReader[j]).Length;
                        }
                        else
                        {
                            length = dataReader[j].ToString().Length;
                        }

                        if (length > maxLengths[j])
                        {
                            maxLengths[j] = length;
                        }
                    }
                }
            }

            return maxLengths;
        }

        private static void AddReportHeader(RichTextBox rtxt)
        {
            // Add date at the start of the report
            rtxt.AppendText("REPORT:\nDate: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\n\n");
        }

        private static void BuildAndAddHeader(SqlDataReader dataReader, RichTextBox rtxt, int[] maxLengths)
        {
            StringBuilder header = new StringBuilder();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                header.Append(dataReader.GetName(i).PadRight(maxLengths[i] + 2));  // Added 2 for a little extra spacing
            }
            rtxt.AppendText(header.ToString() + "\n");
        }

        private static void BuildAndAddDataRows(SqlDataReader dataReader, RichTextBox rtxt, int[] maxLengths)
        {
            while (dataReader.Read())
            {
                StringBuilder sb = new StringBuilder();

                // Loop over the items in the row
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    string value = string.Empty;

                    // If the data type is decimal or double, format it as currency
                    if (dataReader[i] is decimal || dataReader[i] is double)
                    {
                        value = string.Format("{0:C}", dataReader[i]);
                    }
                    else
                    {
                        value = dataReader[i].ToString();
                    }

                    // Truncate the value if it exceeds the maximum length for the column
                    if (value.Length > maxLengths[i])
                    {
                        value = value.Substring(0, maxLengths[i] - 3) + "...";  // Truncate and add ellipsis
                    }

                    sb.Append(value.PadRight(maxLengths[i] + 2));  // Added 2 for a little extra spacing
                }

                // Add the string builder's string to the RichTextBox
                rtxt.AppendText(sb.ToString() + "\n");
            }
        }




    }

}


